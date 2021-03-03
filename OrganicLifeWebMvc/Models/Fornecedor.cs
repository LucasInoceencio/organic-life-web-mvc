using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    public class Fornecedor : EntidadeBase
    {
        public PessoaJuridica PessoaJuridica { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
