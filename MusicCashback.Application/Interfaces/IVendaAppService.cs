using MusicCashback.Application.Dto.Pedido;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.ValueObjects;
using System;

namespace MusicCashback.Application.Interfaces
{
    public interface IVendaAppService
    {
        Response Comprar(PedidoDto pedidoDto, int clienteId);
        Response ObterPorPeriodo(RequestVendaRangeData consultaVendaRangeDataDto);
        Response ObterPorId(int vendaId);
        Response ObterVendasPorCliente(int clienteId);
    }
}
