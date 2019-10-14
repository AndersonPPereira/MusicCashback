using MusicCashback.Domain.Common;
using MusicCashback.Domain.ValueObjects;

namespace MusicCashback.Application.Interfaces
{
    public interface ICatalogoAppService
    {
        Response ObterPorId(int discoId);
        Response ObterComPaginacao(RequestCatalogoGenero requestCatalagoGenero);
    }
}
