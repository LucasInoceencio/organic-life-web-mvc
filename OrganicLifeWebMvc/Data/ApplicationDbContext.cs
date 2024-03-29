﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OrganicLifeWebMvc.Models;

namespace OrganicLifeWebMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProduto> VendaProduto {get; set;}
    }
}
