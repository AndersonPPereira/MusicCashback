using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Interfaces.PorcentagemCashback;
using System;

namespace MusicCashback.Domain.ValueObjects.PorcentagemCashback
{
    public class PorcentagemCashbackRock : IPorcetagemCashback
    {
        public decimal CalculaValorCashbackPorGenero(DayOfWeek diaSemana)
        {
            switch (diaSemana)
            {
                case DayOfWeek.Sunday:
                    return 40M;

                case DayOfWeek.Monday:
                    return 10M;

                case DayOfWeek.Tuesday:
                    return 15M;

                case DayOfWeek.Wednesday:
                    return 15M;

                case DayOfWeek.Thursday:
                    return 15M;

                case DayOfWeek.Friday:
                    return 20M;

                case DayOfWeek.Saturday:
                    return 40M;

                default:
                    throw new Exception("Não foi possível selecionar a porcentagem do genero Rock.");
            }
        }
    }
}
