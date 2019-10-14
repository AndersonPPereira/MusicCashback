using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Interfaces.PorcentagemCashback;
using System;

namespace MusicCashback.Domain.ValueObjects.PorcentagemCashback
{
    public class PorcentagemCashbackPop : IPorcetagemCashback
    {
        public decimal CalculaValorCashbackPorGenero(DayOfWeek diaSemana)
        {
            switch (diaSemana)
            {
                case DayOfWeek.Sunday:
                    return 25M;

                case DayOfWeek.Monday:
                    return 7M;

                case DayOfWeek.Tuesday:
                    return 6M;

                case DayOfWeek.Wednesday:
                    return 2M;

                case DayOfWeek.Thursday:
                    return 10M;

                case DayOfWeek.Friday:
                    return 15M;

                case DayOfWeek.Saturday:
                    return 20M;

                default:
                    throw new Exception("Não foi possível selecionar a porcentagem do genero Pop.");
            }
        }
    }
}
