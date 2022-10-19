using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_products_MyPropertyId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_sizes_SizeId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_users_UserId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "cartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_UserId",
                table: "cartItems",
                newName: "IX_cartItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_SizeId",
                table: "cartItems",
                newName: "IX_cartItems_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_MyPropertyId",
                table: "cartItems",
                newName: "IX_cartItems_MyPropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_products_MyPropertyId",
                table: "cartItems",
                column: "MyPropertyId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_sizes_SizeId",
                table: "cartItems",
                column: "SizeId",
                principalTable: "sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_users_UserId",
                table: "cartItems",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_products_MyPropertyId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_sizes_SizeId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_users_UserId",
                table: "cartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems");

            migrationBuilder.RenameTable(
                name: "cartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_UserId",
                table: "CartItem",
                newName: "IX_CartItem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_SizeId",
                table: "CartItem",
                newName: "IX_CartItem_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_MyPropertyId",
                table: "CartItem",
                newName: "IX_CartItem_MyPropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_products_MyPropertyId",
                table: "CartItem",
                column: "MyPropertyId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_sizes_SizeId",
                table: "CartItem",
                column: "SizeId",
                principalTable: "sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_users_UserId",
                table: "CartItem",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
