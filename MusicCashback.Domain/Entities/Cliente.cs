using MusicCashback.Domain.Enum;
using System;
using System.Collections.Generic;

namespace MusicCashback.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Venda> Venda { get; set; }


        public static Cliente Build(string nome, string cpf, string senha)
        {
            return new Cliente()
            {
                Nome = nome,
                Cpf = cpf,
                Senha = senha
            };
        }
    }
}
