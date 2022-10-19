using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_images_ImageId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ImageId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_images_ProductId",
                table: "images",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_images_products_ProductId",
                table: "images",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_products_ProductId",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_ProductId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ImageId",
                table: "products",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_images_ImageId",
                table: "products",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
