namespace Albiflora.API.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // --- Блок монетизации ---

        // Дата окончания доступа
        public DateTime SubscriptionEndDate { get; set; }

        // Уникальный лицензионный ключ (псевдо-ключ)
        public string LicenseKey { get; set; } = Guid.NewGuid().ToString();

        // Уровень тарифа (0 - Free, 1 - Pro, 2 - Business)
        public int TariffPlan { get; set; }

        // Свойство-помощник: активно ли приложение сейчас
        public bool IsSubscriptionActive { get; set; } = true;

        public bool IsOwned { get; set; } = false;
        public decimal RentPrice { get; set; } = 0;
        public int? RentPaymentDate { get; set; }
        public decimal UtilityBills { get; set; } = 0;
    }
}

