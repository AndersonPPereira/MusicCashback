using MusicCashback.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MusicCashback.Domain.Entities
{
    public class Disco
    {
        public int DiscoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Artista Artista { get; set; }
        public Genero Genero { get; set; }
        public ICollection<ItemVenda> ItemVenda { get; set; }
        public DateTime Data { get; set; }

        public static List<Disco> ListEmpty() => new List<Disco>();

        public static Disco Build(int id, string nome, Artista artista, Genero genero)
        {
            return new Disco()
            {
                Nome = nome,
                Preco = DiscoPreco.GetPrice(),
                Artista = artista,
                Genero = genero
            };
        }
    }
}
