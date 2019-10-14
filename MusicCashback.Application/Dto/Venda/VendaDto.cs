using MusicCashback.Application.Dto.Cliente;
using System.Collections.Generic;

namespace MusicCashback.Application.Dto.Pedido
{
    public class VendaDto
    {
        public int VendaId { get; set; }
        public decimal Cashback { get; set; }
        public decimal Valor { get; set; }
        public ClienteDto Cliente { get; set; }
        public List<ItemVendaDto> ItemVenda { get; set; }

        public static List<VendaDto> ListEmpty() => new List<VendaDto>();
    }
}
