using System;
using System.Collections.Generic;

namespace OrganicLifeWebMvc.Models
{
    public enum MeioPagamento
    {
        Dinheiro = 1,
        Pix = 2,
        CartaoCredito = 3,
        CartaoDebito = 4,
        Deposito = 5,
        Transferencia = 6,
        Cheque = 7
    }

    public class Venda : EntidadeSoftDelete
    {
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public double ValorTotal { get; set; }
        public double ValorDesconto { get; set; }
        public double TaxaEntrega { get; set; }
        public double ValorLiquido { get; set; }
        public MeioPagamento MeioPagamento { get; set; }
        public bool Pago { get; set; }
        public DateTime DataHoraPrevisaoEntrega { get; set; }
    }
}
