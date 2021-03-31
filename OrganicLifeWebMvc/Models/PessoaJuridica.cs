using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    [BindProperties(SupportsGet = true)]
    public class PessoaJuridica : EntidadeBase
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        [BindProperty]
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        [BindProperty]
        public Pessoa Responsavel { get; set; }

        public PessoaJuridica() 
        {
        }

        public PessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj, Endereco endereco, string email, string telefone, string celular, Pessoa responsavel)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            Responsavel = responsavel;
        }
    }
}
