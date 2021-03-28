using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganicLifeWebMvc.Migrations
{
    public partial class UptadeUserPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PessoaId",
                table: "AspNetUsers",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pessoa_PessoaId",
                table: "AspNetUsers",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pessoa_PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "AspNetUsers");
        }
    }
}
