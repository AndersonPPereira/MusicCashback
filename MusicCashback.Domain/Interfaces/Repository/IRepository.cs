using System;
using System.Collections.Generic;

namespace MusicCashback.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        List<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        TEntity Atualiza(TEntity obj);
        void Remove(int id);
    }
}
