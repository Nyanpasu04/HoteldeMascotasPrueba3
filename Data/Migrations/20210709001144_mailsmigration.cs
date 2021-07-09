using Microsoft.EntityFrameworkCore.Migrations;

namespace HoteldeMascotas.Data.Migrations
{
    public partial class mailsmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Por = table.Column<string>(nullable: true),
                    Para = table.Column<string>(nullable: true),
                    Asunto = table.Column<string>(nullable: true),
                    Mensaje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mails");
        }
    }
}
