using Albiflora.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Albiflora.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Этот конструктор нужен для запуска приложения
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка точности для всех денежных полей (чтобы не было ошибок в Postgres)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

                foreach (var property in properties)
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }

            // Добавляем уникальный индекс для ключа лицензии
            modelBuilder.Entity<Shop>().HasIndex(s => s.LicenseKey).IsUnique();

            // Добавляем стандартный набор цветов
            //modelBuilder.Entity<Flower>().HasData(
            //    new Flower { Id = 1, Name = "Роза", Variety = "Эквадор", Color = "Красный", ShelfLifeDays = 7, OptimalTemperature = 4.0, PhotoUrl = "rose_red.jpg" },
            //    new Flower { Id = 2, Name = "Пион", Variety = "Сара Бернар", Color = "Розовый", ShelfLifeDays = 5, OptimalTemperature = 3.5, PhotoUrl = "peony_pink.jpg" },
            //    new Flower { Id = 3, Name = "Хризантема", Variety = "Антонов", Color = "Белый", ShelfLifeDays = 14, OptimalTemperature = 5.0, PhotoUrl = "chrys_white.jpg" },
            //    new Flower { Id = 4, Name = "Тюльпан", Variety = "Стронг Голд", Color = "Желтый", ShelfLifeDays = 6, OptimalTemperature = 2.0, PhotoUrl = "tulip_yellow.jpg" },
            //    new Flower { Id = 5, Name = "Гортензия", Variety = "Магическая", Color = "Голубой", ShelfLifeDays = 4, OptimalTemperature = 6.0, PhotoUrl = "hydrangea_blue.jpg" }
            //);
            DbSeeder.SeedData(modelBuilder);
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

