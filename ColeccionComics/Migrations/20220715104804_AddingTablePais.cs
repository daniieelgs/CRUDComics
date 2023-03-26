using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColeccionComics.Migrations
{
    public partial class AddingTablePais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Nacionalidades");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Nacionalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nacionalidades_PaisId",
                table: "Nacionalidades",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                table: "Paises",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nacionalidades_Paises_PaisId",
                table: "Nacionalidades",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nacionalidades_Paises_PaisId",
                table: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Nacionalidades_PaisId",
                table: "Nacionalidades");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Nacionalidades");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Nacionalidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
