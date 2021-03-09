using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    public class Fornecedor : EntidadeBase
    {
        public PessoaJuridica PessoaJuridica { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Fornecedor()
        {
        }

        public Fornecedor(PessoaJuridica pessoaJuridica)
        {
            PessoaJuridica = pessoaJuridica;
        }

        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendas.Where(wh => wh.DataHoraCadastro >= dataInicial && wh.DataHoraCadastro <= dataFinal)
                .Sum(sm => sm.ValorTotal());
        }
    }
}
