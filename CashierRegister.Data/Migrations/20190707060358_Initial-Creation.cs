using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashierRegister.Data.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CountInStorage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Percentage = table.Column<int>(nullable: false),
                    TaxType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisterCashiers",
                columns: table => new
                {
                    CashierId = table.Column<int>(nullable: false),
                    CashRegisterId = table.Column<int>(nullable: false),
                    StartOfShift = table.Column<DateTime>(nullable: false),
                    EndOfShift = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisterCashiers", x => new { x.CashRegisterId, x.CashierId });
                    table.ForeignKey(
                        name: "FK_CashRegisterCashiers_CashRegisters_CashRegisterId",
                        column: x => x.CashRegisterId,
                        principalTable: "CashRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashRegisterCashiers_Cashiers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTaxes",
                columns: table => new
                {
                    ProductTaxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaxId = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTaxes", x => x.ProductTaxId);
                    table.ForeignKey(
                        name: "FK_ProductTaxes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTaxes_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    CashRegisterCashierId = table.Column<int>(nullable: false),
                    CashRegisterCashierCashRegisterId = table.Column<int>(nullable: true),
                    CashRegisterCashierCashierId = table.Column<int>(nullable: true),
                    ExciseTaxAtCreation = table.Column<int>(nullable: false),
                    DirectTaxAtCreation = table.Column<int>(nullable: false),
                    PreTaxPriceAtCreation = table.Column<int>(nullable: false),
                    PostTaxPriceAtCreation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_CashRegisterCashiers_CashRegisterCashierCashRegisterId_CashRegisterCashierCashierId",
                        columns: x => new { x.CashRegisterCashierCashRegisterId, x.CashRegisterCashierCashierId },
                        principalTable: "CashRegisterCashiers",
                        principalColumns: new[] { "CashRegisterId", "CashierId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptProducts",
                columns: table => new
                {
                    ReceiptId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductExcisePercentageAtCreation = table.Column<int>(nullable: false),
                    ProductDirectPercentageAtCreation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptProducts", x => new { x.ProductId, x.ReceiptId });
                    table.ForeignKey(
                        name: "FK_ReceiptProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptProducts_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisterCashiers_CashierId",
                table: "CashRegisterCashiers",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTaxes_ProductId",
                table: "ProductTaxes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTaxes_TaxId",
                table: "ProductTaxes",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptProducts_ReceiptId",
                table: "ReceiptProducts",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CashRegisterCashierCashRegisterId_CashRegisterCashierCashierId",
                table: "Receipts",
                columns: new[] { "CashRegisterCashierCashRegisterId", "CashRegisterCashierCashierId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTaxes");

            migrationBuilder.DropTable(
                name: "ReceiptProducts");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "CashRegisterCashiers");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "Cashiers");
        }
    }
}
