using MusicCashback.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicCashback.Domain.Entities
{
    public class Venda
    {
        public int VendaId { get; set; }
        public decimal Cashback { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<ItemVenda> ItemVenda { get; set; }
        public DateTime Data { get; set; }

        public static List<Venda> ListEmpty() => new List<Venda>();

        public static Venda Build(Cliente cliente, List<ItemVenda> itemVenda)
        {
            return new Venda()
            {
                Cashback = CalcularCashback(itemVenda),
                Valor = CalcularValorTotal(itemVenda),
                Cliente = cliente,
                ItemVenda = itemVenda
            };
        }

        private static decimal CalcularCashback(List<ItemVenda> itemVenda)
        {
            return itemVenda.Sum(i => i.Cashback).ToDecimal();
        }

        private static decimal CalcularValorTotal(List<ItemVenda> itemVenda)
        {
            return itemVenda.Sum(i => i.ValorTotal).ToDecimal();
        }

    }
}
