using MusicCashback.Domain.Common;
using System;
using System.Collections.Generic;

namespace MusicCashback.Domain.Entities
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Cashback { get; set; }
        public Disco Disco { get; set; }
        public Venda Venda { get; set; }
        public DateTime Data { get; set; }

        public static List<ItemVenda> ListEmpty() => new List<ItemVenda>();

        public static ItemVenda Build(int quantidade, decimal cashback, Disco disco)
        {
            var total = CalcularValorTotal(quantidade, disco.Preco);

            return new ItemVenda()
            {
                ValorUnitario = disco.Preco,
                Quantidade = quantidade,
                ValorTotal = total,
                Cashback = CalcularCashback(total, cashback),
                Disco = disco
            };
        }

        private static decimal CalcularCashback(decimal total, decimal cashback)
        {
            return ((cashback / 100) * total).ToDecimal();
        }

        private static decimal CalcularValorTotal(int quantidade, decimal preco)
        {
            return (quantidade * preco).ToDecimal();
        }
    }
}
