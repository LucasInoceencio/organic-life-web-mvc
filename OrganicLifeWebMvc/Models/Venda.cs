using System;
using System.Collections.Generic;
using System.Linq;

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
        public Fornecedor Fornecedor { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public double ValorDesconto { get; set; }
        public double TaxaEntrega { get; set; }
        public MeioPagamento MeioPagamento { get; set; }
        public bool Pago { get; set; }
        public DateTime DataHoraPrevisaoEntrega { get; set; }

        public Venda()
        {
        }

        public Venda(Cliente cliente, Fornecedor fornecedor, double valorDesconto, double taxaEntrega, MeioPagamento meioPagamento, bool pago, DateTime dataHoraPrevisaoEntrega)
        {
            Cliente = cliente;
            Fornecedor = fornecedor;
            ValorDesconto = valorDesconto;
            TaxaEntrega = taxaEntrega;
            MeioPagamento = meioPagamento;
            Pago = pago;
            DataHoraPrevisaoEntrega = dataHoraPrevisaoEntrega;
        }

        public void AddProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public void RemoveProduto(Produto produto)
        {
            Produtos.Remove(produto);
        }

        public double ValorTotal()
        {
            return Produtos.Sum(sm => sm.Valor);
        }

        public double ValorLiquido()
        {
            return ValorTotal() + TaxaEntrega - ValorDesconto;
        }
    }
}
