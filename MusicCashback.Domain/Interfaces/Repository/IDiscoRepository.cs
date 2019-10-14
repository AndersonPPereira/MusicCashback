using MusicCashback.Domain.Entities;
using MusicCashback.Domain.ValueObjects;
using System.Collections.Generic;

namespace MusicCashback.Domain.Interfaces.Repository
{
    public interface IDiscoRepository : IRepository<Disco>
    {
        Disco ObterRelacionamentoPorId(int discoId);
        List<Disco> ObterListaPorId(List<int> ids);
        List<Disco> ObterComPaginacao(RequestCatalogoGenero requestCatalagoGenero);
        void AddList(List<Disco> list);
        bool Any();
    }
}
