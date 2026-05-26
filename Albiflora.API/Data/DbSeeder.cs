using System;
using System.Collections.Generic;
using System.Linq;
using Albiflora.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Albiflora.API.Data
{
    public static class DbSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // ==========================================
            // 1. СИДИНГ МАГАЗИНОВ (SHOPS)
            // ==========================================
            var shops = new List<Shop>
            {
                new Shop
                {
                    Id = 1,
                    Name = "Albiflora Главный Филиал",
                    Address = "г. Ростов-на-Дону, ул. Большая Садовая, д. 45",
                    CreatedAt = DateTime.UtcNow,
                    LicenseKey = "MAIN-ROSTOV-2026",
                    TariffPlan = 2, // Business
                    IsSubscriptionActive = true,
                    SubscriptionEndDate = DateTime.UtcNow.AddYears(1),
                    IsOwned = true,
                    RentPrice = 0,
                    UtilityBills = 15000
                },
                new Shop
                {
                    Id = 2,
                    Name = "Albiflora Западный",
                    Address = "г. Ростов-на-Дону, пр. Стачки, д. 102",
                    CreatedAt = DateTime.UtcNow,
                    LicenseKey = "WEST-ROSTOV-2026",
                    TariffPlan = 1, // Pro
                    IsSubscriptionActive = true,
                    SubscriptionEndDate = DateTime.UtcNow.AddDays(14),
                    IsOwned = false,
                    RentPrice = 45000,
                    RentPaymentDate = 5,
                    UtilityBills = 8000
                }
            };
            modelBuilder.Entity<Shop>().HasData(shops);

            // ==========================================
            // 2. СИДИНГ ДИРЕКТОРА (1 DIRECTOR)
            // ==========================================
            var director = new User
            {
                Id = 1,
                Email = "director@albiflora.ru",
                PasswordHash = "AQAAAAEAACcQAAAAEFA1...", // Статичный хеш
                Role = "admin",
                ShopId = null, // Доступ ко всей сети
                TariffPlan = 1, // VIP аналитика
                IsSubscriptionActive = true,
                SubscriptionEndDate = DateTime.UtcNow.AddYears(1)
            };
            modelBuilder.Entity<User>().HasData(director);

            // ==========================================
            // 3. СИДИНГ 50 ПОЛЬЗОВАТЕЛЕЙ (USERS / FLORISTS)
            // ==========================================
            var users = new List<User>();
            string[] names = { "anna", "maria", "elena", "olga", "daria", "irina", "kate", "natalia", "julia", "sveta" };

            for (int i = 2; i <= 51; i++)
            {
                var name = names[(i - 2) % names.Length];
                users.Add(new User
                {
                    Id = i,
                    Email = $"{name}{i}@albiflora.ru",
                    PasswordHash = "AQAAAAEAACcQAAAAEFA1...",
                    Role = i % 2 == 0 ? "Florist" : "user",
                    ShopId = i % 2 == 0 ? 1 : 2, // Равномерно распределяем сотрудников
                    TariffPlan = 0,
                    IsSubscriptionActive = false
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            // ==========================================
            // 4. СИДИНГ 50 ВИДОВ ТОВАРОВ (FLOWERS / PACKAGING)
            // ==========================================
            var flowers = new List<Flower>();
            var flowerTypes = new[]
            {
                new { N = "Роза", V = "Эквадор", C = "Красный", T = 7, Temp = 4.0 },
                new { N = "Роза", V = "Пионовидная", C = "Нежно-розовый", T = 6, Temp = 4.0 },
                new { N = "Пион", V = "Сара Бернар", C = "Розовый", T = 5, Temp = 3.5 },
                new { N = "Хризантема", V = "Антонов", C = "Белый", T = 14, Temp = 5.0 },
                new { N = "Тюльпан", V = "Стронг Голд", C = "Желтый", T = 6, Temp = 2.0 },
                new { N = "Гортензия", V = "Магическая", C = "Голубой", T = 4, Temp = 6.0 },
                new { N = "Эустома", V = "Алиса", C = "Фиолетовый", T = 10, Temp = 4.5 },
                new { N = "Альстромерия", V = "Вирджиния", C = "Белый", T = 12, Temp = 5.0 },
                new { N = "Гвоздика", V = "Сортовая", C = "Персиковый", T = 15, Temp = 4.0 },
                new { N = "Гипсофила", V = "Мираж", C = "Радужный", T = 20, Temp = 7.0 }
            };

            for (int i = 1; i <= 40; i++)
            {
                var template = flowerTypes[(i - 1) % flowerTypes.Length];
                flowers.Add(new Flower
                {
                    Id = i,
                    Name = $"{template.N} {template.V}",
                    Variety = template.V,
                    Color = template.C,
                    ShelfLifeDays = template.T,
                    OptimalTemperature = template.Temp,
                    PhotoUrl = $"flower_{i}.jpg",
                    ShopId = i % 2 == 0 ? 1 : 2
                });
            }

            // Добавляем 10 упаковочных материалов и декора до ровного счета 50
            var decorTypes = new[] { "Матовая пленка", "Крафт бумага", "Атласная лента", "Корейская сетка", "Шелковая бумага", "Свадебный каркас", "Коробка шляпная", "Корзина плетеная", "Деревянный топпер", "Открытка мини" };
            var decorColors = new[] { "Прозрачный", "Натуральный", "Красный", "Пудровый", "Золотой", "Белый", "Черный", "Тиффани", "Бордовый", "Акварельный" };

            for (int i = 41; i <= 50; i++)
            {
                var index = i - 41;
                flowers.Add(new Flower
                {
                    Id = i,
                    Name = decorTypes[index],
                    Variety = "Упаковка и Декор",
                    Color = decorColors[index],
                    ShelfLifeDays = 365,
                    OptimalTemperature = 18.0,
                    PhotoUrl = $"decor_{i}.jpg",
                    ShopId = i % 2 == 0 ? 1 : 2
                });
            }
            modelBuilder.Entity<Flower>().HasData(flowers);

            // ==========================================
            // 5. СИДИНГ СКЛАДА (50 INVENTORY ITEMS)
            // ==========================================
            var inventory = new List<InventoryItem>();
            var rand = new Random(42); // Фиксированный seed для красивой генерации цен

            for (int i = 1; i <= 50; i++)
            {
                decimal purchase = rand.Next(50, 300);
                decimal markup = rand.Next(2, 4);
                decimal salePrice = decimal.Round(purchase * markup, 0);

                inventory.Add(new InventoryItem
                {
                    Id = i,
                    ShopId = i % 2 == 0 ? 1 : 2,
                    FlowerId = i,
                    Quantity = rand.Next(15, 120),
                    PurchasePrice = purchase,
                    SalePrice = salePrice,
                    WholesalePrice = decimal.Round(salePrice * 0.85m, 0),
                    DiscountPercent = rand.Next(0, 3) * 5,
                    ArrivalDate = DateTime.UtcNow.AddDays(-rand.Next(0, 2)),
                    ExpiryDate = DateTime.UtcNow.AddDays(rand.Next(3, 9)),
                    WasteProbability = decimal.Round((decimal)rand.NextDouble() * 0.25m, 2),
                    RecommendedDiscount = 0
                });
            }
            modelBuilder.Entity<InventoryItem>().HasData(inventory);
        }
    }
}
