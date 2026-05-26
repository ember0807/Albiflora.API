using Albiflora.API.Data;
using Albiflora.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Albiflora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // В будущем сюда можно добавить [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Получить всех пользователей (чтобы директор видел, кого назначать)
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.Role,
                    u.ShopId,
                    ShopName = u.Shop != null ? u.Shop.Name : "Не назначен"
                })
                .ToListAsync();

            return Ok(users);
        }

        // 2. Назначить роль и магазин сотруднику
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound(new { message = "Пользователь не найден" });

            // Если привязываем к магазину, проверяем, существует ли он
            if (request.ShopId.HasValue)
            {
                var shopExists = await _context.Shops.AnyAsync(s => s.Id == request.ShopId.Value);
                if (!shopExists)
                    return BadRequest(new { message = "Указанный магазин не существует" });
            }

            // Обновляем данные пользователя
            user.Role = request.Role;
            user.ShopId = request.ShopId;

            await _context.SaveChangesAsync();

            return Ok(new { message = $"Пользователю {user.Email} успешно установлена роль {request.Role}" });
        }

        // 3. Создание нового магазина директором (С учетом расширенной экономики недвижимости)
        [HttpPost("shops")]
        public async Task<IActionResult> CreateShop([FromBody] CreateShopRequest request)
        {
            if (request == null)
                return BadRequest(new { message = "Данные магазина пусты" });

            try
            {
                var newShop = new Shop
                {
                    Name = request.Name,
                    Address = request.Address,
                    CreatedAt = DateTime.UtcNow,
                    LicenseKey = request.LicenseKey,
                    IsOwned = request.IsOwned,
                    RentPrice = request.IsOwned ? 0 : request.RentPrice,
                    RentPaymentDate = request.IsOwned ? null : request.RentPaymentDate,
                    UtilityBills = request.UtilityBills
                };

                _context.Shops.Add(newShop);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Магазин успешно создан", shopId = newShop.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ошибка при сохранении магазина в БД", error = ex.Message });
            }
        }

        // 4. Получение реальной премиум-аналитики магазина для VIP-тарифа
        [HttpGet("shops/{shopId}/analytics")]
        public async Task<IActionResult> GetShopAnalytics(int shopId)
        {
            var shopExists = await _context.Shops.AnyAsync(s => s.Id == shopId);
            if (!shopExists)
                return NotFound(new { message = "Магазин не найден" });

            // 1. Ищем, кто из сотрудников сейчас привязан к магазину
            var activeEmployee = await _context.Users
                .Where(u => u.ShopId == shopId && (u.Role == "Admin" || u.Role == "Florist"))
                .Select(u => u.Email)
                .FirstOrDefaultAsync() ?? "Смена не открыта";

            // Вычисляем дату начала текущего месяца, чтобы брать выручку только за него
            var startOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            // 2. Считаем реальную сумму продаж (Sales) этого магазина за текущий месяц
            // Примечание: Убедись, что в твоей сущности Sale поле даты называется CreatedAt или SaleDate, 
            // а поле суммы — TotalPrice, Amount или TotalCost. Если названия отличаются, подправь их ниже.
            decimal totalSales = await _context.Sales
                .Where(s => s.ShopId == shopId && s.SaleDate >= startOfMonth)
                .SumAsync(s => s.FinalPrice);

            // 3. Заглушка для списаний (так как отдельной таблицы в DbContext пока нет)
            var writeOffs = new List<object>();
            decimal totalWriteOffs = 0;

            return Ok(new
            {
                ActiveEmployee = activeEmployee,
                TotalSales = totalSales,
                TotalWriteOffs = totalWriteOffs,
                WriteOffsDetails = writeOffs
            });
        }

        // 5. НОВЫЙ МЕТОД: Переезд торговой точки на другой адрес с новыми расходами
        [HttpPut("shops/{id}/relocate")]
        public async Task<IActionResult> RelocateShop(int id, [FromBody] RelocateShopRequest request)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
                return NotFound(new { message = "Магазин не найден" });

            // Применяем новые параметры релокации недвижимости
            shop.Address = request.Address;
            shop.IsOwned = request.IsOwned;
            shop.RentPrice = request.IsOwned ? 0 : request.RentPrice;
            shop.RentPaymentDate = request.IsOwned ? null : request.RentPaymentDate;
            shop.UtilityBills = request.UtilityBills;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Точка успешно релоцирована, весь штат сохранен за филиалом." });
        }

        // 6. НОВЫЙ МЕТОД: Закрытие/Ликвидация филиала (С роспуском персонала в общий резерв)
        [HttpDelete("shops/{id}/close")]
        public async Task<IActionResult> CloseShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
                return NotFound(new { message = "Магазин не найден" });

            // Находим сотрудников, привязанных к этой точке, и переводим их в статус "Без магазина"
            var employees = await _context.Users.Where(u => u.ShopId == id).ToListAsync();
            foreach (var emp in employees)
            {
                emp.ShopId = null;
            }

            // Удаляем торговую точку из сети
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Торговая точка закрыта. Сотрудники переведены в резерв сети." });
        }
    }

    // --- RECORDS (ОПИСАНИЕ МОДЕЛЕЙ ЗАПРОСОВ) ---
    public record AssignRoleRequest(int UserId, string Role, int? ShopId);

    public record CreateShopRequest(
        string Name,
        string Address,
        string LicenseKey,
        bool IsOwned,
        decimal RentPrice,
        int? RentPaymentDate,
        decimal UtilityBills
    );

    public record RelocateShopRequest(
        string Address,
        bool IsOwned,
        decimal RentPrice,
        int? RentPaymentDate,
        decimal UtilityBills
    );
}