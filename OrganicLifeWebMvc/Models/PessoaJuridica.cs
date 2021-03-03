using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    public class PessoaJuridica : EntidadeBase
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Pessoa Responsavel { get; set; }
    }
}
