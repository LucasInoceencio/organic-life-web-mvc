using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganicLifeWebMvc.Models
{
    public class Cliente : EntidadeBase
    {
        public Pessoa Pessoa{ get; set; }
        public ICollection<Venda> Compras { get; set; } = new List<Venda>();
        // Dados de acesso

        public Cliente()
        {
        }

        public Cliente(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public double TotalCompras(DateTime dataInicial, DateTime dataFinal)
        {
            return Compras.Where(wh => wh.DataHoraCadastro >= dataInicial && wh.DataHoraCadastro <= dataFinal)
                .Sum(sm => sm.ValorTotal());
        }
    }
}
