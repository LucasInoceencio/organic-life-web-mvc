using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganicLifeWebMvc.Migrations
{
    public partial class VendaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Venda_VendaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_VendaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Produto");

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Venda",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pessoa",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "VendaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    ResponsavelCadastro = table.Column<string>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    ResponsavelAlteracao = table.Column<string>(nullable: true),
                    VendaId = table.Column<int>(nullable: true),
                    ProdutoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendaProduto_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_ProdutoId",
                table: "VendaProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_VendaId",
                table: "VendaProduto",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaProduto");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Venda");

            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "Produto",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Produto_VendaId",
                table: "Produto",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Venda_VendaId",
                table: "Produto",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
