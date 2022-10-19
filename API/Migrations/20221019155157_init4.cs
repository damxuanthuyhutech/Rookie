using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_products_MyPropertyId",
                table: "cartItems");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "cartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_MyPropertyId",
                table: "cartItems",
                newName: "IX_cartItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_products_ProductId",
                table: "cartItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_products_ProductId",
                table: "cartItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "cartItems",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_ProductId",
                table: "cartItems",
                newName: "IX_cartItems_MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_products_MyPropertyId",
                table: "cartItems",
                column: "MyPropertyId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
