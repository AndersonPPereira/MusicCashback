using MusicCashback.Domain.Entities;
using MusicCashback.Domain.ValueObjects;
using System.Collections.Generic;

namespace MusicCashback.Domain.Interfaces.Repository
{
    public interface IVendaRepository : IRepository<Venda>
    {
        List<Venda> ObterListaPorClienteId(int clienteId);
        Venda ObterVendaPorId(int vendaId);
        List<Venda> ObterComPaginacao(RequestVendaRangeData consultaVendaRangeDto);
    }
}
