using MusicCashback.Domain.Interfaces.PorcentagemCashback;
using System;

namespace MusicCashback.Domain.ValueObjects.PorcentagemCashback
{
    public class PorcentagemCashbackClassic : IPorcetagemCashback
    {
        public decimal CalculaValorCashbackPorGenero(DayOfWeek diaSemana)
        {
            switch (diaSemana)
            {
                case DayOfWeek.Sunday:
                    return 35M;

                case DayOfWeek.Monday:
                    return 3M;

                case DayOfWeek.Tuesday:
                    return 5M;

                case DayOfWeek.Wednesday:
                    return 8M;

                case DayOfWeek.Thursday:
                    return 13M;

                case DayOfWeek.Friday:
                    return 18M;

                case DayOfWeek.Saturday:
                    return 25M;

                default:
                    throw new Exception("Não foi possível selecionar a porcentagem do genero classic.");
            }
        }
    }
}
