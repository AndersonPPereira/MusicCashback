using System.Collections.Generic;

namespace MusicCashback.Application.Dto.Disco
{
    public class DiscoDto
    {
        public int DiscoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public ArtistaDto Artista { get; set; }
        public GeneroDto Genero { get; set; }

        public static List<DiscoDto> ListEmpty() => new List<DiscoDto>();
    }
}
