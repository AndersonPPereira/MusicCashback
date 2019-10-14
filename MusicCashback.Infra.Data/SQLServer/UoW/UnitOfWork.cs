using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;
using System;

namespace MusicCashback.Infra.Data.SQLServer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextEf _context;

        public UnitOfWork(ContextEf context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
