using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Migrations
{
    public partial class UrlShortProyectTier2Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Url_CategoriesId",
                table: "Url",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Categories_CategoriesId",
                table: "Url",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_Categories_CategoriesId",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_CategoriesId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Url");
        }
    }
}
