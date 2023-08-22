using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impacta.GAD.Repository.Migrations
{
    public partial class perfilUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pefil",
                table: "AspNetUsers",
                newName: "PerfilUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerfilUsuario",
                table: "AspNetUsers",
                newName: "Pefil");
        }
    }
}
