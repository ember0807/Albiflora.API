namespace Albiflora.API.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int InventoryItemId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; } // Оставляем decimal
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; } = "Sale";

        // ShopId , чтобы потом легко считать выручку магазина
        public int ShopId { get; set; }
    }
}
