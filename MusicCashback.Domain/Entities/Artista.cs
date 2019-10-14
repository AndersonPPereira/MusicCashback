using System;
using System.Collections.Generic;

namespace MusicCashback.Domain.Entities
{
    public class Artista
    {
        public int ArtistaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Disco> Disco { get; set; }
        public DateTime Data { get; set; }

        public static Artista Build(string nome)
        {
            return new Artista()
            {
                Nome = nome,
            };
        }
    }
}
