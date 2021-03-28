using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganicLifeWebMvc.Migrations
{
    public partial class UptadeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFornecedor",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TipoUsuario",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsFornecedor",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }
    }
}
