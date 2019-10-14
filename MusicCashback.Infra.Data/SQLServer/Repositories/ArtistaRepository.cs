using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(ContextEf context) : base(context)
        {

        }
    }
}
