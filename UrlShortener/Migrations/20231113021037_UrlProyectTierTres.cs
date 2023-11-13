using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Migrations
{
    public partial class UrlProyectTierTres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Url",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "juaneselmejor", "juan" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 2, "joaeselmejor", "joaquin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 3, "laueselmejor", "lautaro" });

            migrationBuilder.CreateIndex(
                name: "IX_Url_UserId",
                table: "Url",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_User_UserId",
                table: "Url",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_User_UserId",
                table: "Url");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Url_UserId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Url");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Url",
                newName: "ID");
        }
    }
}
