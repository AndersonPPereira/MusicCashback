using System.Collections.Generic;
using System.Linq;

namespace MusicCashback.Application.Dto.Pedido
{
    public class PedidoDto
    {
        public List<ItemPedidoDto> ItemPedidoDto { get; set; }

        public bool IsNotValid()
        {
            return
                this.ItemPedidoDto == null ||
                this.ItemPedidoDto != null && !this.ItemPedidoDto.Any();
        }

        public List<int> GetListId()
        {
            return this.ItemPedidoDto.GroupBy(p => p.DiscoId).Select(p => p.Key).ToList();
        }


        public string GetValueInvalidId()
        {
            var valuesInvalid = string.Join(", ", this.ItemPedidoDto.Where(x => x.DiscoId <= 0).Select(x => x.DiscoId).ToList());
            return "DiscoId: {" + valuesInvalid + "}";
        }

        public string GetValueInvalidQuantidade()
        {
            var valuesInvalid = string.Join(", ", this.ItemPedidoDto.Where(x => x.Quantidade <= 0).Select(x => x.Quantidade).ToList());
            return "Quantidade: {" + valuesInvalid + "}";
        }
    }
}
