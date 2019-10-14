using MusicCashback.Domain.Common;

namespace MusicCashback.Domain.ValueObjects
{
    public class RequestCatalogoGenero
    {
        public int GeneroId { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public Paginacao Paginacao { get; set; }

        public RequestCatalogoGenero WithPagination(int quantidadeTotal)
        {
            this.Paginacao = Paginacao.New(quantidadeTotal, this.QuantidadePorPagina, this.PaginaAtual);
            return this;
        }
    }
}
