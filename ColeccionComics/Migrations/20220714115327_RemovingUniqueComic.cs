using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColeccionComics.Migrations
{
    public partial class RemovingUniqueComic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comics_Titulo",
                table: "Comics");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Comics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Comics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Comics_Titulo",
                table: "Comics",
                column: "Titulo",
                unique: true);
        }
    }
}
