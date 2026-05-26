using Albiflora.API.Data;
using Albiflora.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FlowersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public FlowersController(ApplicationDbContext context) => _context = context;

    // 1. Получить цветы КОНКРЕТНОГО магазина
    // Будет вызываться как: api/Flowers/shop/3
    [HttpGet("shop/{shopId}")]
    public async Task<ActionResult<IEnumerable<Flower>>> GetFlowersByShop(int shopId)
    {
        var flowers = await _context.Flowers
            .Where(f => f.ShopId == shopId)
            .ToListAsync();

        return Ok(flowers);
    }

    // 2. Универсальный метод добавления
    [HttpPost]
    public async Task<ActionResult<Flower>> AddFlower([FromBody] Flower flower)
    {
        if (flower == null) return BadRequest("Данные цветка не заполнены");

        // УБРАЛИ flower.ShopId = 3; 
        // Теперь ShopId берется из того, что прислал фронтенд в JSON

        _context.Flowers.Add(flower);
        await _context.SaveChangesAsync();

        return Ok(flower);
    }

    // Оставляем общий метод, если он нужен для админки всей сети
    [HttpGet]
    public async Task<IActionResult> GetAllFlowers()
    {
        var flowers = await _context.Flowers.ToListAsync();
        return Ok(flowers);
    }
}