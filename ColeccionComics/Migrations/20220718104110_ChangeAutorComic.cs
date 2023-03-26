using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColeccionComics.Migrations
{
    public partial class ChangeAutorComic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Roles_RolId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_RolId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Autores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_RolId",
                table: "Autores",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Roles_RolId",
                table: "Autores",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
