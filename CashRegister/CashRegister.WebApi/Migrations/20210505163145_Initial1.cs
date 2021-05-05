using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.WebApi.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLine_Product_ProductID",
                table: "ReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLine_Receipt_ReceiptID",
                table: "ReceiptLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptLine",
                table: "ReceiptLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ReceiptLine",
                newName: "ReceiptLines");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLine_ReceiptID",
                table: "ReceiptLines",
                newName: "IX_ReceiptLines_ReceiptID");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLine_ProductID",
                table: "ReceiptLines",
                newName: "IX_ReceiptLines_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptLines",
                table: "ReceiptLines",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLines_Products_ProductID",
                table: "ReceiptLines",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLines_Receipts_ReceiptID",
                table: "ReceiptLines",
                column: "ReceiptID",
                principalTable: "Receipts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLines_Products_ProductID",
                table: "ReceiptLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLines_Receipts_ReceiptID",
                table: "ReceiptLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptLines",
                table: "ReceiptLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "ReceiptLines",
                newName: "ReceiptLine");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLines_ReceiptID",
                table: "ReceiptLine",
                newName: "IX_ReceiptLine_ReceiptID");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLines_ProductID",
                table: "ReceiptLine",
                newName: "IX_ReceiptLine_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptLine",
                table: "ReceiptLine",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLine_Product_ProductID",
                table: "ReceiptLine",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLine_Receipt_ReceiptID",
                table: "ReceiptLine",
                column: "ReceiptID",
                principalTable: "Receipt",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
