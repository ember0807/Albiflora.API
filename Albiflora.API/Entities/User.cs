namespace Albiflora.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // В идеале храним хеш
        public string Role { get; set; } = "user"; // "admin", "user", "Florist"

        // Привязка к магазину (может быть пустым для обычных клиентов или глобального директора)
        public int? ShopId { get; set; }
        public Shop? Shop { get; set; } // Сделали nullable (добавили ?), чтобы не было ошибок типизации

        // --- ДОБАВИЛИ ПОЛЯ ДЛЯ VIP-ТАРИФА ДИРЕКТОРА ---
       public int TariffPlan { get; set; } = 0; // 0 = Базовый, 1 = VIP аналитика
       public bool IsSubscriptionActive { get; set; } = false; // Статус подписки
        public DateTime? SubscriptionEndDate { get; set; } // Дата окончания действия VIP
    }
}