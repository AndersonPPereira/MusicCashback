using Microsoft.EntityFrameworkCore;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ContextEf Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ContextEf context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            return DbSet.Add(obj).Entity;
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Atualiza(TEntity obj)
        {
            return DbSet.Update(obj).Entity;
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
