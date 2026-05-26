using Albiflora.API.Data;
using Albiflora.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class ShopsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ShopsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
    {
        return await _context.Shops.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Shop>> CreateShop(Shop shop)
    {
        // 1. Автоматически генерируем уникальный ключ, если он не пришел
        if (string.IsNullOrEmpty(shop.LicenseKey))
        {
            shop.LicenseKey = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        // 2. Устанавливаем дату регистрации
        shop.CreatedAt = DateTime.UtcNow;

        // 3. По умолчанию ставим активную подписку на 14 дней (пробный период)
        shop.IsSubscriptionActive = true;
        shop.SubscriptionEndDate = DateTime.UtcNow.AddDays(14);

        _context.Shops.Add(shop);
        await _context.SaveChangesAsync();

        return Ok(shop);
    }

    // Добавим метод для проверки ключа (например, при входе в систему)
    [HttpGet("verify/{key}")]
    public async Task<ActionResult<Shop>> VerifyLicense(string key)
    {
        var shop = await _context.Shops
            .FirstOrDefaultAsync(s => s.LicenseKey == key);

        if (shop == null) return NotFound("Неверный лицензионный ключ");

        return Ok(shop);
    }
    // GET: api/Shops/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> GetShop(int id)
    {
        var shop = await _context.Shops.FindAsync(id);

        if (shop == null)
        {
            return NotFound(new { message = "Магазин не найден" });
        }

        return Ok(shop);
    }
}
