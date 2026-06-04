using Microsoft.AspNetCore.Mvc;

namespace Albiflora.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BouquetsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        // Статический список для хранения букетов в памяти сервера (пока не подключена БД)
        private static readonly List<object> CustomBouquets = new List<object>();

        public BouquetsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // 1. GET: api/Bouquets — Отдает встроенные и добавленные букеты
        [HttpGet]
        public IActionResult GetBouquets()
        {
            
            var defaultBouquets = new List<object>
            {
                new { id = 101, name = "Весенний нектар", category = "Нежные", price = 2500, composition = "Розовая кустовая роза, белые тюльпаны, эвкалипт", isAvailable = true, url = "https://images.unsplash.com/photo-1520763185298-1b434c919102?q=80&w=500" },
                new { id = 102, name = "Ростовская роза", category = "Классика", price = 3800, composition = "15 премиальных роз Эквадор, фирменная крафт-упаковка", isAvailable = true, url = "https://images.unsplash.com/photo-1518709268805-4e9042af9f23?q=80&w=500" },
                new { id = 103, name = "Пионовое облако", category = "Премиум", price = 5200, composition = "7 неоновых пионов, белая гортензия, ленты", isAvailable = true, url = "https://images.unsplash.com/photo-1561181286-d3fee7d55364?q=80&w=500" },
                new { id = 104, name = "Лавандовый рассвет", category = "Авторские", price = 2900, composition = "Маттиола лавандовая, кустовая гвоздика, оксипеталум", isAvailable = true, url = "https://images.unsplash.com/photo-1567427017947-545c5f8d16ad?q=80&w=500" }
            };

            var allBouquets = new List<object>();
            allBouquets.AddRange(CustomBouquets);
            allBouquets.AddRange(defaultBouquets);

            return Ok(allBouquets);
        }

        // 2. POST: api/Bouquets/upload — Принимает новый букет, сохраняет фото и добавляет в список
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateBouquet(
            [FromForm] string name,
            [FromForm] decimal price,
            IFormFile photo)
        {
            if (photo == null || photo.Length == 0) return BadRequest("Фото обязательно");

            string uploadsFolder = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);


            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            // Формируем полный URL до картинки
            string fileUrl = $"https://localhost:7199/uploads/{uniqueFileName}";

            // Добавляем букет в начало списка, чтобы он был первым на витрине
            CustomBouquets.Insert(0, new 
            {
                id = CustomBouquets.Count + 1,
                name = name,
                category = "Классика",
                price = price,
                composition = "Свежесобранный дизайнерский букет от флориста",
                isAvailable = true,
                url = fileUrl
            });

            return Ok(new { success = true, filePath = fileUrl });
        }
    }
}
