using Microsoft.EntityFrameworkCore.Migrations;

namespace CashierRegister.Data.Migrations
{
    public partial class CashRegisterCashier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisterCashier_CashRegisters_CashRegisterId",
                table: "CashRegisterCashier");

            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisterCashier_Cashiers_CashierId",
                table: "CashRegisterCashier");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_CashRegisterCashier_CashRegisterCashierCashRegisterId_CashRegisterCashierCashierId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashRegisterCashier",
                table: "CashRegisterCashier");

            migrationBuilder.RenameTable(
                name: "CashRegisterCashier",
                newName: "CashRegisterCashiers");

            migrationBuilder.RenameIndex(
                name: "IX_CashRegisterCashier_CashierId",
                table: "CashRegisterCashiers",
                newName: "IX_CashRegisterCashiers_CashierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashRegisterCashiers",
                table: "CashRegisterCashiers",
                columns: new[] { "CashRegisterId", "CashierId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterCashiers_CashRegisters_CashRegisterId",
                table: "CashRegisterCashiers",
                column: "CashRegisterId",
                principalTable: "CashRegisters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterCashiers_Cashiers_CashierId",
                table: "CashRegisterCashiers",
                column: "CashierId",
                principalTable: "Cashiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_CashRegisterCashiers_CashRegisterCashierCashRegisterId_CashRegisterCashierCashierId",
                table: "Receipts",
                columns: new[] { "CashRegisterCashierCashRegisterId", "CashRegisterCashierCashierId" },
                principalTable: "CashRegisterCashiers",
                principalColumns: new[] { "CashRegisterId", "CashierId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisterCashiers_CashRegisters_CashRegisterId",
                table: "CashRegisterCashiers");

            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisterCashiers_Cashiers_CashierId",
                table: "CashRegisterCashiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_CashRegisterCashiers_CashRegisterCashierCashRegisterId_CashRegisterCashierCashierId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashRegisterCashiers",
                table: "CashRegisterCashiers");

            migrationBuilder.RenameTable(
                name: "CashRegisterCashiers",
                newName: "CashRegisterCashier");

            migrationBuilder.RenameIndex(
                name: "IX_CashRegisterCashiers_CashierId",
                table: "CashRegisterCashier",
                newName: "IX_CashRegisterCashier_CashierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashRegisterCashier",
                table: "CashRegisterCashier",
                columns: new[] { "CashRegisterId", "CashierId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterCashier_CashRegisters_CashRegisterId",
                table: "CashRegisterCashier",
                column: "CashRegisterId",
                principalTable: "CashRegisters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterCashier_Cashiers_CashierId",
                table: "CashRegisterCashier",
                column: "CashierId",
                principalTable: "Cashiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_CashRegisterCashier_CashRegisterCashierCashRegisterId_CashRegisterCashierCashierId",
                table: "Receipts",
                columns: new[] { "CashRegisterCashierCashRegisterId", "CashRegisterCashierCashierId" },
                principalTable: "CashRegisterCashier",
                principalColumns: new[] { "CashRegisterId", "CashierId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
