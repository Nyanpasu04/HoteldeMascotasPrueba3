using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoteldeMascotas.Data.Migrations
{
    public partial class mascotas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dueños");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    MascotasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMascota = table.Column<string>(nullable: true),
                    Raza = table.Column<string>(nullable: true),
                    Años = table.Column<int>(nullable: false),
                    Vacunas = table.Column<bool>(nullable: false),
                    DueñosID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.MascotasId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.CreateTable(
                name: "Dueños",
                columns: table => new
                {
                    DueñosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreDueño = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservaID = table.Column<int>(type: "int", nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueños", x => x.DueñosID);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Costo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false),
                    TipoReserva = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });
        }
    }
}
