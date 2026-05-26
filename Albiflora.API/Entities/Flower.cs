using System.ComponentModel.DataAnnotations;

namespace Albiflora.API.Entities
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Variety { get; set; } // Сорт
        public string? Color { get; set; }
        public int ShelfLifeDays { get; set; } // Срок годности в днях
        public double OptimalTemperature { get; set; } // Оптимальная температура хранения
        public string? PhotoUrl { get; set; }
        public int ShopId { get; set; } // Внешний ключ
        public Shop? Shop { get; set; } // Навигационное свойство (связь)
    }
}
