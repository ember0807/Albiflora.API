namespace Albiflora.API.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }

        // Связи
        public int ShopId { get; set; }
        public int FlowerId { get; set; }
        public Flower? Flower { get; set; }

        public int Quantity { get; set; }

        // Цены
        public decimal PurchasePrice { get; set; } // Цена закупки
        public decimal SalePrice { get; set; }     // Цена продажи
        public decimal? WholesalePrice { get; set; } // Оптовая цена (на случай больших заказов)
        public decimal DiscountPercent { get; set; } // Текущая скидка в %

        public DateTime ArrivalDate { get; set; } // Дата прибытия партии
        public DateTime ExpiryDate { get; set; }  // Рассчитывается как ArrivalDate + ShelfLife
        public decimal WasteProbability { get; set; } // Вероятность списания (от 0 до 1)
        public decimal RecommendedDiscount { get; set; } // Рекомендованная скидка от ИИ
    }
}
