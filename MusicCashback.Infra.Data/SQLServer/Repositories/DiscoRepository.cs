using Microsoft.EntityFrameworkCore;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Domain.ValueObjects;
using MusicCashback.Infra.Data.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class DiscoRepository : Repository<Disco>, IDiscoRepository
    {
        private readonly ContextEf _contextEf;
        public DiscoRepository(ContextEf context) : base(context)
        {
            _contextEf = context;
        }

        public void AddList(List<Disco> list)
        {
            _contextEf.Disco.AddRange(list);
            _contextEf.SaveChanges();
        }

        public bool Any()
        {
            return _contextEf.Disco.Any();
        }

        public Disco ObterRelacionamentoPorId(int discoId)
        {
            return _contextEf.Disco
                            .Include(d => d.Genero)
                            .Include(d => d.Artista)
                            .Where(d => d.DiscoId == discoId).FirstOrDefault();
        }

        public List<Disco> ObterListaPorId(List<int> ids)
        {
            return _contextEf.Disco
                            .Include(d => d.Genero)
                            .Include(d => d.Artista)
                            .Where(d => ids.Contains(d.DiscoId)).ToList();
        }

        public List<Disco> ObterComPaginacao(RequestCatalogoGenero requestCatalagoGenero)
        {
            var where = requestCatalagoGenero.GeneroId <= 0
                        ? new Func<Disco, bool>(d => d.Genero.GeneroId != 0)
                        : new Func<Disco, bool>(d => d.Genero.GeneroId == requestCatalagoGenero.GeneroId);

            var total = _contextEf.Disco
                                 .Include(d => d.Genero)
                                 .Include(d => d.Artista)
                                 .Count(where);

            if (total == 0)
                return Disco.ListEmpty();

            requestCatalagoGenero.WithPagination(total);

            return _contextEf.Disco
                          .Where(where)
                          .OrderBy(d => d.Nome)
                          .Skip(requestCatalagoGenero.Paginacao.Skip)
                          .Take(requestCatalagoGenero.Paginacao.Take)
                          .ToList();
        }
    }
}
