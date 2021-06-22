using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoteldeMascotas.Data.Migrations
{
    public partial class MigracionClases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dueños",
                columns: table => new
                {
                    DueñosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDueño = table.Column<string>(nullable: true),
                    Rut = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    ReservaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueños", x => x.DueñosID);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoReserva = table.Column<string>(nullable: true),
                    Costo = table.Column<string>(nullable: true),
                    Duracion = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dueños");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
