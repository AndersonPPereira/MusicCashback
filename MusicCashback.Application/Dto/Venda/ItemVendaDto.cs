namespace MusicCashback.Application.Dto.Pedido
{
    public class ItemVendaDto
    {
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Cashback { get; set; }
    }
}
