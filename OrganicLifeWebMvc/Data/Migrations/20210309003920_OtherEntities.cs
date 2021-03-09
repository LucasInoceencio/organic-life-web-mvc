using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganicLifeWebMvc.Data.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    ResponsavelCadastro = table.Column<string>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    ResponsavelAlteracao = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    ResponsavelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Pessoa_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    ResponsavelCadastro = table.Column<string>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    ResponsavelAlteracao = table.Column<string>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    ResponsavelCadastro = table.Column<string>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    ResponsavelAlteracao = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DataHoraExclusao = table.Column<DateTime>(nullable: true),
                    ResponsavelExclusao = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    FornecedorId = table.Column<int>(nullable: true),
                    ValorTotal = table.Column<double>(nullable: false),
                    ValorDesconto = table.Column<double>(nullable: false),
                    TaxaEntrega = table.Column<double>(nullable: false),
                    ValorLiquido = table.Column<double>(nullable: false),
                    MeioPagamento = table.Column<int>(nullable: false),
                    Pago = table.Column<bool>(nullable: false),
                    DataHoraPrevisaoEntrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    ResponsavelCadastro = table.Column<string>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    ResponsavelAlteracao = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DataHoraExclusao = table.Column<DateTime>(nullable: true),
                    ResponsavelExclusao = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Organico = table.Column<bool>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: true),
                    VendaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_PessoaJuridicaId",
                table: "Fornecedor",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_EnderecoId",
                table: "PessoaJuridica",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_ResponsavelId",
                table: "PessoaJuridica",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_VendaId",
                table: "Produto",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_FornecedorId",
                table: "Venda",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
