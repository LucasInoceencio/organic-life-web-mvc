using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OrganicLifeWebMvc.Models;

namespace OrganicLifeWebMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cliente> Endereco { get; set; }
        public DbSet<Cliente> Fornecedor { get; set; }
        public DbSet<Cliente> Pessoa { get; set; }
        public DbSet<Cliente> PessoaJuridica { get; set; }
        public DbSet<Cliente> Produto { get; set; }
        public DbSet<Cliente> Venda { get; set; }
    }
}
