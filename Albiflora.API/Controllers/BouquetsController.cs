using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BouquetsController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public BouquetsController(IWebHostEnvironment env)
    {
        _env = env;
    }

    // 1. Добавляем Consumes, чтобы Swagger понял тип запроса
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateBouquet(
        [FromForm] string name,
        [FromForm] decimal price,
        IFormFile photo) // 2. Убираем [FromForm] прямо перед IFormFile
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

        return Ok(new { success = true, filePath = $"/uploads/{uniqueFileName}" });
    }
}
