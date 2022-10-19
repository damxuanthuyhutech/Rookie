using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaTitle",
                table: "categories",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "categories",
                newName: "Active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "categories",
                newName: "MetaTitle");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "categories",
                newName: "Content");
        }
    }
}
