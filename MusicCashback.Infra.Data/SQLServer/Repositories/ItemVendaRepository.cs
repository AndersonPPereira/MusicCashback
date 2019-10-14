using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class ItemVendaRepository : Repository<ItemVenda>, IItemVendaRepository
    {
        public ItemVendaRepository(ContextEf context) : base(context)
        {

        }
    }
}
