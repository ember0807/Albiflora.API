using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albiflora.API.Migrations
{
    /// <inheritdoc />
    public partial class ConnectTransactionToShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4876), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4877) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4887), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4887) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4893), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4894) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4896), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 6, 11, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4932), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4935), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4935) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4937), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4942), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4943) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4945), new DateTime(2026, 6, 9, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4947), new DateTime(2026, 6, 11, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 6, 9, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4954), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4956), new DateTime(2026, 6, 12, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4957) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4959), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4962), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4962) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4964), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4966), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4967) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4969), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4973), new DateTime(2026, 6, 12, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4976), new DateTime(2026, 6, 11, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4978), new DateTime(2026, 6, 9, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4982), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4984), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4986), new DateTime(2026, 6, 11, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4989), new DateTime(2026, 6, 12, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4991), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4991) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4993), new DateTime(2026, 6, 11, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 6, 9, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5002), new DateTime(2026, 6, 9, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5004), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5005) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5007), new DateTime(2026, 6, 12, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5009), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5011), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5011) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5013), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5014) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5016), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5016) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5018), new DateTime(2026, 6, 10, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5022), new DateTime(2026, 6, 12, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5024), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5025) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 3, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5027), new DateTime(2026, 6, 7, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5029), new DateTime(2026, 6, 12, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 6, 8, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "SubscriptionEndDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4432), new DateTime(2027, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "SubscriptionEndDate" },
                values: new object[] { new DateTime(2026, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4474), new DateTime(2026, 6, 18, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubscriptionEndDate",
                value: new DateTime(2027, 6, 4, 9, 37, 33, 73, DateTimeKind.Utc).AddTicks(4531));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ShopId",
                table: "Transactions",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Shops_ShopId",
                table: "Transactions",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Shops_ShopId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ShopId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2778), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2779) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2787), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2787) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2793), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2793) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2795), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2796) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2825), new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2826) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2828), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2833), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2836), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2836) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2838), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2839) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2843), new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2843) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2845), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2847), new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2848) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2849), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2851), new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2854), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2854) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2856), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2857) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2859), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2859) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2861), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2861) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2863), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2863) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2865), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2867), new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2868) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2869), new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2871), new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2873), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 5, 25, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2889), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2891), new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2891) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2893), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2895), new DateTime(2026, 5, 23, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2897), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2898) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2899), new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2901), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2903), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2906), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2906) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2908), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2908) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 5, 24, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2912), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2912) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2914), new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2914) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2916), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2918), new DateTime(2026, 5, 21, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 5, 26, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ArrivalDate", "ExpiryDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2948), new DateTime(2026, 5, 22, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2948) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "SubscriptionEndDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2352), new DateTime(2027, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "SubscriptionEndDate" },
                values: new object[] { new DateTime(2026, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2392), new DateTime(2026, 6, 1, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2393) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubscriptionEndDate",
                value: new DateTime(2027, 5, 18, 12, 7, 51, 255, DateTimeKind.Utc).AddTicks(2443));
        }
    }
}
