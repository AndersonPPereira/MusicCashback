using MusicCashback.Domain.Entities;
using System.Collections.Generic;

namespace MusicCashback.Domain.Interfaces.Repository
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        void AddList(List<Genero> list);
        bool Any();
    }
}
