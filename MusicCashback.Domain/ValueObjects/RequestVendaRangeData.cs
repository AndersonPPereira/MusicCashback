using MusicCashback.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCashback.Domain.ValueObjects
{
    public class RequestVendaRangeData
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public Paginacao Paginacao { get; set; }

        public RequestVendaRangeData WithPagination(int quantidadeTotal)
        {
            this.Paginacao = Paginacao.New(quantidadeTotal, this.QuantidadePorPagina, this.PaginaAtual);
            return this;
        }

        public bool IsNotValid()
        {
            return
                this.DateStartNotValid() ||
                this.DateEndNotValid();
        }

        private bool DateStartNotValid()
        {
            return this.DataInicial == DateTime.MinValue || this.DataInicial > this.DataFinal;
        }

        private bool DateEndNotValid()
        {
            return this.DataFinal == DateTime.MinValue || this.DataFinal > DateTime.Now;
        }

        public List<string> GetValueInvalidDateString()
        {
            var list = new List<string>();

            if (!this.IsNotValid())
                return list;

            if (this.DateStartNotValid())
                list.Add("Data inicial inválida");

            if (this.DateEndNotValid())
                list.Add("Data final inválida");

            return list;
        }
    }
}
