using Albiflora.API.Data;
using Albiflora.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Albiflora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Получить весь склад магазина
        [HttpGet("shop/{shopId}")]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetShopInventory(int shopId)
        {
            return await _context.Inventory
                .Include(i => i.Flower)
                .Where(i => i.ShopId == shopId)
                .ToListAsync();
        }

        // 2. ИИ-АНАЛИТИКА С ПРОВЕРКОЙ ПОДПИСКИ
        [HttpGet("analytics/{shopId}")]
        public async Task<IActionResult> GetAiAnalytics(int shopId)
        {
            var shop = await _context.Shops.FindAsync(shopId);

            if (shop == null) return NotFound("Магазин не найден");

            // Проверка тарифа и активности подписки
            if (!shop.IsSubscriptionActive || shop.TariffPlan < 1)
            {
                return StatusCode(403, new
                {
                    message = "Доступ ограничен. Функция доступна только для тарифа Pro.",
                    plan = shop.TariffPlan,
                    isActive = shop.IsSubscriptionActive
                });
            }

            var inventory = await _context.Inventory
                .Include(i => i.Flower)
                .Where(i => i.ShopId == shopId && i.Quantity > 0)
                .ToListAsync();

            var report = inventory.Select(item => {
                var totalDays = (item.ExpiryDate - item.ArrivalDate).TotalDays;
                var daysLeft = (item.ExpiryDate - DateTime.UtcNow).TotalDays;

                // Расчет риска (от 0 до 1)
                double riskPercent = 1.0 - (daysLeft / (totalDays > 0 ? totalDays : 1));
                riskPercent = Math.Clamp(riskPercent, 0, 1);

                return new
                {
                    Id = item.Id,
                    Item = item.Flower?.Name,
                    Variety = item.Flower?.Variety,
                    RiskLevel = riskPercent,
                    Status = riskPercent > 0.8 ? "Критический риск" : riskPercent > 0.5 ? "Средний риск" : "Свежий товар",
                    SuggestedDiscount = riskPercent > 0.5 ? (riskPercent * 50).ToString("0") + "%" : "0%"
                };
            });

            return Ok(report);
        }

        // 3. Добавление новой позиции на склад
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> AddInventoryItem([FromBody] InventoryItem item)
        {
            if (item == null) return BadRequest("Данные не получены");

            // 1. Пытаемся найти существующий цветок в справочнике
            var existingFlower = await _context.Flowers
                .FirstOrDefaultAsync(f => f.Name == item.Flower.Name && f.Variety == item.Flower.Variety);

            int shelfLife;

            if (existingFlower != null)
            {
                item.FlowerId = existingFlower.Id;
                shelfLife = existingFlower.ShelfLifeDays;
                item.Flower = null; // Обнуляем объект, чтобы EF не пытался создать дубликат в таблице Flowers
            }
            else
            {
                // Если цветок новый, используем его ShelfLifeDays или 7 по умолчанию
                shelfLife = item.Flower?.ShelfLifeDays ?? 7;
            }

            // 2. Установка дат
            if (item.ArrivalDate == default) item.ArrivalDate = DateTime.UtcNow;
            item.ExpiryDate = item.ArrivalDate.AddDays(shelfLife);

            _context.Inventory.Add(item);
            await _context.SaveChangesAsync();

            // Возвращаем объект с загруженными данными о цветке
            var result = await _context.Inventory
                .Include(i => i.Flower)
                .FirstOrDefaultAsync(i => i.Id == item.Id);

            return Ok(result);
        }

        // 4. Продажа товара
        [HttpPost("sale/{id}")]
        public async Task<IActionResult> SellInventoryItem(int id, [FromBody] int quantity)
        {
            if (quantity <= 0) return BadRequest("Количество должно быть больше 0");

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var item = await _context.Inventory.FirstOrDefaultAsync(x => x.Id == id);

                if (item == null) return NotFound("Товар не найден");
                if (item.Quantity < quantity) return BadRequest("Недостаточно товара на складе");

                item.Quantity -= quantity;

                // Создаем запись о транзакции для финансового учета
                var saleRecord = new Transaction
                {
                    InventoryItemId = id,
                    ShopId = item.ShopId, // Важно для аналитики по магазину
                    Quantity = quantity,
                    TotalPrice = item.SalePrice * quantity,
                    Date = DateTime.UtcNow,
                    Type = "Sale"
                };

                _context.Transactions.Add(saleRecord);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(new { newQuantity = item.Quantity, message = "Продажа зафиксирована" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Ошибка при обработке продажи: {ex.Message}");
            }
        }

        
    }
}
