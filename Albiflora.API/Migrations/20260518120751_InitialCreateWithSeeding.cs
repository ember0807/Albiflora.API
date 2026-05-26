using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Albiflora.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) 
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LicenseKey = table.Column<string>(type: "text", nullable: false),
                    TariffPlan = table.Column<int>(type: "integer", nullable: false),
                    IsSubscriptionActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsOwned = table.Column<bool>(type: "boolean", nullable: false),
                    RentPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    RentPaymentDate = table.Column<int>(type: "integer", nullable: true),
                    UtilityBills = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Variety = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    ShelfLifeDays = table.Column<int>(type: "integer", nullable: false),
                    OptimalTemperature = table.Column<double>(type: "double precision", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    ShopId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flowers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: true),
                    TariffPlan = table.Column<int>(type: "integer", nullable: false),
                    IsSubscriptionActive = table.Column<bool>(type: "boolean", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShopId = table.Column<int>(type: "integer", nullable: false),
                    FlowerId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    WholesalePrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WasteProbability = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    RecommendedDiscount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryItemId = table.Column<int>(type: "integer", nullable: true),
                    ShopId = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    SaleDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Inventory_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CreatedAt", "IsOwned", "IsSubscriptionActive", "LicenseKey", "Name", "RentPaymentDate", "RentPrice", "SubscriptionEndDate", "TariffPlan", "UtilityBills" },
                values: new object[,]
                {
                    { 1, "г. Ростов-на-Дону, ул. Большая Садовая, д. 45", new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2352), true, true, "MAIN-ROSTOV-2026", "Albiflora Главный Филиал", null, 0m, new DateTime(2027, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2353), 2, 15000m },
                    { 2, "г. Ростов-на-Дону, пр. Стачки, д. 102", new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2392), false, true, "WEST-ROSTOV-2026", "Albiflora Западный", 5, 45000m, new DateTime(2026, 6, 1, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2393), 1, 8000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsSubscriptionActive", "PasswordHash", "Role", "ShopId", "SubscriptionEndDate", "TariffPlan" },
                values: new object[] { 1, "director@albiflora.ru", true, "AQAAAAEAACcQAAAAEFA1...", "admin", null, new DateTime(2027, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2443), 1 });

            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "Id", "Color", "Name", "OptimalTemperature", "PhotoUrl", "ShelfLifeDays", "ShopId", "Variety" },
                values: new object[,]
                {
                    { 1, "Красный", "Роза Эквадор", 4.0, "flower_1.jpg", 7, 2, "Эквадор" },
                    { 2, "Нежно-розовый", "Роза Пионовидная", 4.0, "flower_2.jpg", 6, 1, "Пионовидная" },
                    { 3, "Розовый", "Пион Сара Бернар", 3.5, "flower_3.jpg", 5, 2, "Сара Бернар" },
                    { 4, "Белый", "Хризантема Антонов", 5.0, "flower_4.jpg", 14, 1, "Антонов" },
                    { 5, "Желтый", "Тюльпан Стронг Голд", 2.0, "flower_5.jpg", 6, 2, "Стронг Голд" },
                    { 6, "Голубой", "Гортензия Магическая", 6.0, "flower_6.jpg", 4, 1, "Магическая" },
                    { 7, "Фиолетовый", "Эустома Алиса", 4.5, "flower_7.jpg", 10, 2, "Алиса" },
                    { 8, "Белый", "Альстромерия Вирджиния", 5.0, "flower_8.jpg", 12, 1, "Вирджиния" },
                    { 9, "Персиковый", "Гвоздика Сортовая", 4.0, "flower_9.jpg", 15, 2, "Сортовая" },
                    { 10, "Радужный", "Гипсофила Мираж", 7.0, "flower_10.jpg", 20, 1, "Мираж" },
                    { 11, "Красный", "Роза Эквадор", 4.0, "flower_11.jpg", 7, 2, "Эквадор" },
                    { 12, "Нежно-розовый", "Роза Пионовидная", 4.0, "flower_12.jpg", 6, 1, "Пионовидная" },
                    { 13, "Розовый", "Пион Сара Бернар", 3.5, "flower_13.jpg", 5, 2, "Сара Бернар" },
                    { 14, "Белый", "Хризантема Антонов", 5.0, "flower_14.jpg", 14, 1, "Антонов" },
                    { 15, "Желтый", "Тюльпан Стронг Голд", 2.0, "flower_15.jpg", 6, 2, "Стронг Голд" },
                    { 16, "Голубой", "Гортензия Магическая", 6.0, "flower_16.jpg", 4, 1, "Магическая" },
                    { 17, "Фиолетовый", "Эустома Алиса", 4.5, "flower_17.jpg", 10, 2, "Алиса" },
                    { 18, "Белый", "Альстромерия Вирджиния", 5.0, "flower_18.jpg", 12, 1, "Вирджиния" },
                    { 19, "Персиковый", "Гвоздика Сортовая", 4.0, "flower_19.jpg", 15, 2, "Сортовая" },
                    { 20, "Радужный", "Гипсофила Мираж", 7.0, "flower_20.jpg", 20, 1, "Мираж" },
                    { 21, "Красный", "Роза Эквадор", 4.0, "flower_21.jpg", 7, 2, "Эквадор" },
                    { 22, "Нежно-розовый", "Роза Пионовидная", 4.0, "flower_22.jpg", 6, 1, "Пионовидная" },
                    { 23, "Розовый", "Пион Сара Бернар", 3.5, "flower_23.jpg", 5, 2, "Сара Бернар" },
                    { 24, "Белый", "Хризантема Антонов", 5.0, "flower_24.jpg", 14, 1, "Антонов" },
                    { 25, "Желтый", "Тюльпан Стронг Голд", 2.0, "flower_25.jpg", 6, 2, "Стронг Голд" },
                    { 26, "Голубой", "Гортензия Магическая", 6.0, "flower_26.jpg", 4, 1, "Магическая" },
                    { 27, "Фиолетовый", "Эустома Алиса", 4.5, "flower_27.jpg", 10, 2, "Алиса" },
                    { 28, "Белый", "Альстромерия Вирджиния", 5.0, "flower_28.jpg", 12, 1, "Вирджиния" },
                    { 29, "Персиковый", "Гвоздика Сортовая", 4.0, "flower_29.jpg", 15, 2, "Сортовая" },
                    { 30, "Радужный", "Гипсофила Мираж", 7.0, "flower_30.jpg", 20, 1, "Мираж" },
                    { 31, "Красный", "Роза Эквадор", 4.0, "flower_31.jpg", 7, 2, "Эквадор" },
                    { 32, "Нежно-розовый", "Роза Пионовидная", 4.0, "flower_32.jpg", 6, 1, "Пионовидная" },
                    { 33, "Розовый", "Пион Сара Бернар", 3.5, "flower_33.jpg", 5, 2, "Сара Бернар" },
                    { 34, "Белый", "Хризантема Антонов", 5.0, "flower_34.jpg", 14, 1, "Антонов" },
                    { 35, "Желтый", "Тюльпан Стронг Голд", 2.0, "flower_35.jpg", 6, 2, "Стронг Голд" },
                    { 36, "Голубой", "Гортензия Магическая", 6.0, "flower_36.jpg", 4, 1, "Магическая" },
                    { 37, "Фиолетовый", "Эустома Алиса", 4.5, "flower_37.jpg", 10, 2, "Алиса" },
                    { 38, "Белый", "Альстромерия Вирджиния", 5.0, "flower_38.jpg", 12, 1, "Вирджиния" },
                    { 39, "Персиковый", "Гвоздика Сортовая", 4.0, "flower_39.jpg", 15, 2, "Сортовая" },
                    { 40, "Радужный", "Гипсофила Мираж", 7.0, "flower_40.jpg", 20, 1, "Мираж" },
                    { 41, "Прозрачный", "Матовая пленка", 18.0, "decor_41.jpg", 365, 2, "Упаковка и Декор" },
                    { 42, "Натуральный", "Крафт бумага", 18.0, "decor_42.jpg", 365, 1, "Упаковка и Декор" },
                    { 43, "Красный", "Атласная лента", 18.0, "decor_43.jpg", 365, 2, "Упаковка и Декор" },
                    { 44, "Пудровый", "Корейская сетка", 18.0, "decor_44.jpg", 365, 1, "Упаковка и Декор" },
                    { 45, "Золотой", "Шелковая бумага", 18.0, "decor_45.jpg", 365, 2, "Упаковка и Декор" },
                    { 46, "Белый", "Свадебный каркас", 18.0, "decor_46.jpg", 365, 1, "Упаковка и Декор" },
                    { 47, "Черный", "Коробка шляпная", 18.0, "decor_47.jpg", 365, 2, "Упаковка и Декор" },
                    { 48, "Тиффани", "Корзина плетеная", 18.0, "decor_48.jpg", 365, 1, "Упаковка и Декор" },
                    { 49, "Бордовый", "Деревянный топпер", 18.0, "decor_49.jpg", 365, 2, "Упаковка и Декор" },
                    { 50, "Акварельный", "Открытка мини", 18.0, "decor_50.jpg", 365, 1, "Упаковка и Декор" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsSubscriptionActive", "PasswordHash", "Role", "ShopId", "SubscriptionEndDate", "TariffPlan" },
                values: new object[,]
                {
                    { 2, "anna2@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 3, "maria3@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 4, "elena4@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 5, "olga5@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 6, "daria6@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 7, "irina7@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 8, "kate8@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 9, "natalia9@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 10, "julia10@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 11, "sveta11@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 12, "anna12@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 13, "maria13@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 14, "elena14@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 15, "olga15@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 16, "daria16@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 17, "irina17@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 18, "kate18@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 19, "natalia19@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 20, "julia20@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 21, "sveta21@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 22, "anna22@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 23, "maria23@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 24, "elena24@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 25, "olga25@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 26, "daria26@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 27, "irina27@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 28, "kate28@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 29, "natalia29@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 30, "julia30@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 31, "sveta31@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 32, "anna32@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 33, "maria33@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 34, "elena34@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 35, "olga35@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 36, "daria36@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 37, "irina37@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 38, "kate38@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 39, "natalia39@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 40, "julia40@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 41, "sveta41@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 42, "anna42@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 43, "maria43@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 44, "elena44@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 45, "olga45@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 46, "daria46@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 47, "irina47@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 48, "kate48@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 49, "natalia49@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 },
                    { 50, "julia50@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "Florist", 1, null, 0 },
                    { 51, "sveta51@albiflora.ru", false, "AQAAAAEAACcQAAAAEFA1...", "user", 2, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "ArrivalDate", "DiscountPercent", "ExpiryDate", "FlowerId", "PurchasePrice", "Quantity", "RecommendedDiscount", "SalePrice", "ShopId", "WasteProbability", "WholesalePrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2778), 5m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2779), 1, 217m, 28, 0m, 434m, 2, 0.18m, 369m },
                    { 2, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2787), 0m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2787), 2, 178m, 94, 0m, 356m, 1, 0.08m, 303m },
                    { 3, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2790), 0m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2790), 3, 145m, 69, 0m, 290m, 2, 0.10m, 246m },
                    { 4, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2793), 10m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2793), 4, 88m, 89, 0m, 176m, 1, 0.18m, 150m },
                    { 5, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2795), 5m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2796), 5, 86m, 87, 0m, 258m, 2, 0.08m, 219m },
                    { 6, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2825), 5m, new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2826), 6, 195m, 15, 0m, 585m, 1, 0.10m, 497m },
                    { 7, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2828), 10m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2828), 7, 87m, 20, 0m, 174m, 2, 0.06m, 148m },
                    { 8, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2830), 0m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2830), 8, 243m, 83, 0m, 486m, 1, 0.13m, 413m },
                    { 9, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2833), 5m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2833), 9, 62m, 89, 0m, 124m, 2, 0.09m, 105m },
                    { 10, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2836), 0m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2836), 10, 116m, 90, 0m, 232m, 1, 0.20m, 197m },
                    { 11, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2838), 0m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2839), 11, 159m, 67, 0m, 477m, 2, 0.00m, 405m },
                    { 12, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2840), 10m, new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2841), 12, 65m, 18, 0m, 195m, 1, 0.09m, 166m },
                    { 13, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2843), 0m, new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2843), 13, 204m, 54, 0m, 408m, 2, 0.13m, 347m },
                    { 14, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2845), 5m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2845), 14, 150m, 110, 0m, 300m, 1, 0.22m, 255m },
                    { 15, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2847), 0m, new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2848), 15, 289m, 89, 0m, 578m, 2, 0.08m, 491m },
                    { 16, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2849), 0m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2850), 16, 244m, 29, 0m, 488m, 1, 0.25m, 415m },
                    { 17, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2851), 0m, new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2852), 17, 241m, 90, 0m, 723m, 2, 0.16m, 615m },
                    { 18, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2854), 0m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2854), 18, 56m, 112, 0m, 112m, 1, 0.01m, 95m },
                    { 19, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2856), 0m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2857), 19, 104m, 59, 0m, 312m, 2, 0.03m, 265m },
                    { 20, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2859), 10m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2859), 20, 130m, 93, 0m, 260m, 1, 0.21m, 221m },
                    { 21, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2861), 10m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2861), 21, 273m, 112, 0m, 546m, 2, 0.16m, 464m },
                    { 22, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2863), 0m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2863), 22, 206m, 46, 0m, 412m, 1, 0.23m, 350m },
                    { 23, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2865), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2865), 23, 296m, 29, 0m, 888m, 2, 0.14m, 755m },
                    { 24, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2867), 5m, new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2868), 24, 189m, 27, 0m, 567m, 1, 0.11m, 482m },
                    { 25, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2869), 5m, new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2870), 25, 137m, 63, 0m, 411m, 2, 0.03m, 349m },
                    { 26, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2871), 10m, new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2872), 26, 76m, 34, 0m, 152m, 1, 0.15m, 129m },
                    { 27, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2873), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2874), 27, 150m, 110, 0m, 300m, 2, 0.08m, 255m },
                    { 28, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2875), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2876), 28, 185m, 113, 0m, 555m, 1, 0.08m, 472m },
                    { 29, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2878), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2878), 29, 181m, 40, 0m, 543m, 2, 0.07m, 462m },
                    { 30, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2880), 0m, new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2880), 30, 107m, 82, 0m, 321m, 1, 0.22m, 273m },
                    { 31, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2882), 5m, new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2882), 31, 244m, 114, 0m, 732m, 2, 0.04m, 622m },
                    { 32, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2884), 5m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2884), 32, 196m, 81, 0m, 392m, 1, 0.20m, 333m },
                    { 33, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2886), 0m, new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2886), 33, 136m, 90, 0m, 408m, 2, 0.15m, 347m },
                    { 34, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2889), 0m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2889), 34, 99m, 20, 0m, 297m, 1, 0.04m, 252m },
                    { 35, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2891), 5m, new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2891), 35, 122m, 107, 0m, 244m, 2, 0.19m, 207m },
                    { 36, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2893), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2893), 36, 215m, 52, 0m, 645m, 1, 0.23m, 548m },
                    { 37, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2895), 10m, new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2896), 37, 198m, 55, 0m, 594m, 2, 0.22m, 505m },
                    { 38, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2897), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2898), 38, 128m, 107, 0m, 384m, 1, 0.15m, 326m },
                    { 39, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2899), 10m, new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2900), 39, 54m, 58, 0m, 162m, 2, 0.07m, 138m },
                    { 40, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2901), 5m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2902), 40, 285m, 18, 0m, 855m, 1, 0.17m, 727m },
                    { 41, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2903), 0m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2904), 41, 180m, 51, 0m, 360m, 2, 0.15m, 306m },
                    { 42, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2906), 0m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2906), 42, 130m, 25, 0m, 390m, 1, 0.24m, 332m },
                    { 43, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2908), 5m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2908), 43, 137m, 75, 0m, 274m, 2, 0.16m, 233m },
                    { 44, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2910), 5m, new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2910), 44, 77m, 33, 0m, 231m, 1, 0.16m, 196m },
                    { 45, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2912), 5m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2912), 45, 265m, 79, 0m, 530m, 2, 0.20m, 450m },
                    { 46, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2914), 5m, new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2914), 46, 188m, 85, 0m, 564m, 1, 0.17m, 479m },
                    { 47, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2916), 10m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2916), 47, 106m, 71, 0m, 212m, 2, 0.15m, 180m },
                    { 48, new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2918), 5m, new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2918), 48, 237m, 118, 0m, 474m, 1, 0.10m, 403m },
                    { 49, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2920), 5m, new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2921), 49, 155m, 74, 0m, 310m, 2, 0.12m, 264m },
                    { 50, new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2948), 5m, new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2948), 50, 127m, 90, 0m, 254m, 1, 0.20m, 216m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_ShopId",
                table: "Flowers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_FlowerId",
                table: "Inventory",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_InventoryItemId",
                table: "Sales",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ShopId",
                table: "Sales",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_LicenseKey",
                table: "Shops",
                column: "LicenseKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShopId",
                table: "Users",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
