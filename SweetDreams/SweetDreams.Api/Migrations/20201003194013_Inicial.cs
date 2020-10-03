using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetDreams.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroHabitacion = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Caracteriscas = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Accesibilidad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitacion");
        }
    }
}
