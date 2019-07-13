using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashierRegister.Data.Migrations
{
    public partial class contextwithseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Location" },
                values: new object[,]
                {
                    { 1, "Split" },
                    { 2, "Zagreb" }
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "tj3ZAukuZcd7AYunJd4BHY3Ve/71Rvork5Yf334cQeWvnbge", "Test" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CountInStorage", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"), 12, "Banana", 3 },
                    { new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"), 12, "Malboro", 6 },
                    { new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"), 12, "Philip Morris", 5 },
                    { new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"), 12, "Lucky Strike", 5 },
                    { new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"), 12, "Burek", 8 },
                    { new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"), 12, "Šunka", 3 },
                    { new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"), 12, "Coca-cola", 6 },
                    { new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"), 12, "Čips", 4 },
                    { new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"), 12, "Lubenica", 2 },
                    { new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"), 12, "Camel", 5 },
                    { new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"), 12, "Kupus", 3 }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "Id", "Name", "Percentage", "TaxType" },
                values: new object[,]
                {
                    { 1, "Direct", 25, 1 },
                    { 2, "Hrana", 0, 0 },
                    { 3, "Duhanski proizvodi", 130, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductTaxes",
                columns: new[] { "ProductTaxId", "ProductId", "TaxId" },
                values: new object[,]
                {
                    { 1, new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"), 1 },
                    { 19, new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"), 3 },
                    { 13, new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"), 3 },
                    { 22, new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"), 2 },
                    { 18, new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"), 2 },
                    { 17, new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"), 2 },
                    { 16, new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"), 2 },
                    { 15, new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"), 2 },
                    { 14, new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"), 2 },
                    { 12, new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"), 2 },
                    { 11, new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"), 1 },
                    { 10, new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"), 1 },
                    { 9, new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"), 1 },
                    { 8, new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"), 1 },
                    { 7, new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"), 1 },
                    { 6, new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"), 1 },
                    { 5, new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"), 1 },
                    { 4, new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"), 1 },
                    { 3, new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"), 1 },
                    { 2, new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"), 1 },
                    { 20, new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"), 3 },
                    { 21, new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cashiers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductTaxes",
                keyColumn: "ProductTaxId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"));

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
