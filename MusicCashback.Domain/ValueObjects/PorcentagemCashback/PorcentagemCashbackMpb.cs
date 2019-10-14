using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Interfaces.PorcentagemCashback;
using System;

namespace MusicCashback.Domain.ValueObjects.PorcentagemCashback
{
    public class PorcentagemCashbackMpb : IPorcetagemCashback
    {
        public decimal CalculaValorCashbackPorGenero(DayOfWeek diaSemana)
        {
            switch (diaSemana)
            {
                case DayOfWeek.Sunday:
                    return 30M;

                case DayOfWeek.Monday:
                    return 5M;

                case DayOfWeek.Tuesday:
                    return 10M;

                case DayOfWeek.Wednesday:
                    return 15M;

                case DayOfWeek.Thursday:
                    return 20M;

                case DayOfWeek.Friday:
                    return 25M;

                case DayOfWeek.Saturday:
                    return 30M;

                default:
                    throw new Exception("Não foi possível selecionar a porcentagem do genero Mpb.");
            }
        }
    }
}
