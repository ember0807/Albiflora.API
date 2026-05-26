namespace Albiflora.API.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        // Связь со складом делаем nullable (?), чтобы удаление товара не стирало продажи
        public int? InventoryItemId { get; set; }
        public InventoryItem? InventoryItem { get; set; }

        // Жесткая прямая связь с магазином
        public int ShopId { get; set; }
        public Shop? Shop { get; set; }

        // Полезно для истории: сохраняем название товара на момент продажи, 
        // чтобы даже если товар удалят, директор видел, что именно было продано
        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; } // Цена за единицу товара с учетом скидок
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    }
}
