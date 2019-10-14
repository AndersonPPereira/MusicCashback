using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;
using System.Collections.Generic;
using System.Linq;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        private ContextEf _context;
        public GeneroRepository(ContextEf context) : base(context)
        {
            _context = context;
        }

        public void AddList(List<Genero> list)
        {
            _context.Genero.AddRange(list);
            _context.SaveChanges();
        }

        public bool Any()
        {
            return _context.Genero.Any();
        }
    }
}
