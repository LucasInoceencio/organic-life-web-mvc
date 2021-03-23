﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganicLifeWebMvc.Data;

namespace OrganicLifeWebMvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<int?>("PessoaId");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Numero");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<int?>("PessoaJuridicaId");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.HasKey("Id");

                    b.HasIndex("PessoaJuridicaId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Cpf");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.Property<string>("Rg");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Cnpj");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<string>("Email");

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.Property<int?>("ResponsavelId");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Categoria");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<DateTime?>("DataHoraExclusao");

                    b.Property<bool>("Deletado");

                    b.Property<string>("Descricao");

                    b.Property<int?>("FornecedorId");

                    b.Property<string>("Nome");

                    b.Property<bool>("Organico");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.Property<string>("ResponsavelExclusao");

                    b.Property<string>("Sigla");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<DateTime?>("DataHoraExclusao");

                    b.Property<DateTime>("DataHoraPrevisaoEntrega");

                    b.Property<bool>("Deletado");

                    b.Property<int?>("FornecedorId");

                    b.Property<int>("MeioPagamento");

                    b.Property<bool>("Pago");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.Property<string>("ResponsavelExclusao");

                    b.Property<double>("TaxaEntrega");

                    b.Property<double>("ValorDesconto");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.VendaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCadastro");

                    b.Property<int?>("ProdutoId");

                    b.Property<string>("ResponsavelAlteracao");

                    b.Property<string>("ResponsavelCadastro");

                    b.Property<int?>("VendaId");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaProduto");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Cliente", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Fornecedor", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.PessoaJuridica", "PessoaJuridica")
                        .WithMany()
                        .HasForeignKey("PessoaJuridicaId");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Pessoa", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.PessoaJuridica", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("OrganicLifeWebMvc.Models.Pessoa", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Produto", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.Venda", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.Cliente", "Cliente")
                        .WithMany("Compras")
                        .HasForeignKey("ClienteId");

                    b.HasOne("OrganicLifeWebMvc.Models.Fornecedor", "Fornecedor")
                        .WithMany("Vendas")
                        .HasForeignKey("FornecedorId");
                });

            modelBuilder.Entity("OrganicLifeWebMvc.Models.VendaProduto", b =>
                {
                    b.HasOne("OrganicLifeWebMvc.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("OrganicLifeWebMvc.Models.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId");
                });
#pragma warning restore 612, 618
        }
    }
}
