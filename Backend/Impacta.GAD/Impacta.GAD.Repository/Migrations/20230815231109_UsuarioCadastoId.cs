using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impacta.GAD.Repository.Migrations
{
    public partial class UsuarioCadastoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UsuarioCadastoId",
                table: "DNS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioCadastoId",
                table: "Cliente",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioCadastoId",
                table: "Chamado",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioCadastoId",
                table: "BancoDados",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioCadastoId",
                table: "DNS");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastoId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastoId",
                table: "BancoDados");
        }
    }
}
