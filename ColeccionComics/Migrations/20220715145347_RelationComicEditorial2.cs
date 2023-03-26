using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColeccionComics.Migrations
{
    public partial class RelationComicEditorial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorialId",
                table: "Comics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comics_EditorialId",
                table: "Comics",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Editoriales_EditorialId",
                table: "Comics",
                column: "EditorialId",
                principalTable: "Editoriales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Editoriales_EditorialId",
                table: "Comics");

            migrationBuilder.DropIndex(
                name: "IX_Comics_EditorialId",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "EditorialId",
                table: "Comics");
        }
    }
}
