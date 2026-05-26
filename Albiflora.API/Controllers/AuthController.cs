using Albiflora.API.Data;
using Albiflora.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Albiflora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // 1. МЕТОД РЕГИСТРАЦИИ (Добавили дефолтные значения тарифа)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return BadRequest(new { message = "Пользователь с таким Email уже существует" });
            }

            var newUser = new User
            {
                Email = request.Email,
                PasswordHash = request.Password, // Передаем чистый пароль для тестов
                Role = "User",
                ShopId = null,
                TariffPlan = 0,                 // По умолчанию базовый тариф
                IsSubscriptionActive = false,   // Подписка изначально выключена
                SubscriptionEndDate = null
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Регистрация успешна" });
        }

        // 2. ОБНОВЛЕННЫЙ МЕТОД ВХОДА (Передает данные подписки на фронтенд)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || user.PasswordHash != request.Password)
            {
                return Unauthorized(new { message = "Неверный логин или пароль" });
            }

            var token = GenerateJwtToken(user);

            // Возвращаем все данные, которые теперь ждет AdminPanel.jsx в localStorage
            return Ok(new
            {
                token = token,
                role = user.Role,
                shopId = user.ShopId,
                tariffPlan = user.TariffPlan,                     // Отдаем тариф (0 или 1)
                isSubscriptionActive = user.IsSubscriptionActive   // Отдаем статус (true или false)
            });
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "SuperSecretKeyForAlbifloraProject2026"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                
                // Добавляем данные тарифа прямо в JWT токен для безопасности
                new Claim("tariffPlan", user.TariffPlan.ToString()),
                new Claim("isSubscriptionActive", user.IsSubscriptionActive.ToString().ToLower())
            };

            if (user.ShopId.HasValue)
            {
                claims.Add(new Claim("shopId", user.ShopId.Value.ToString()));
            }

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Модели для запросов
    public record LoginRequest(string Email, string Password);
    public record RegisterRequest(string Email, string Password);
}
