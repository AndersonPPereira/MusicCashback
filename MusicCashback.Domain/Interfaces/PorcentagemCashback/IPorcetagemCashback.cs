using MusicCashback.Domain.Enum;
using System;

namespace MusicCashback.Domain.Interfaces.PorcentagemCashback
{
    public interface IPorcetagemCashback
    {
        decimal CalculaValorCashbackPorGenero(DayOfWeek diaSemana);
    }
}
