using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Interfaces.PorcentagemCashback;
using MusicCashback.Domain.ValueObjects.PorcentagemCashback;
using System;

namespace MusicCashback.Domain.ValueObjects.Factory
{
    public class PorcentagemCachbackFactory
    {
        public static IPorcetagemCashback CriaInstanciaPorcentagemCashback(GeneroEnum genero)
        {
            switch (genero)
            {
                case GeneroEnum.CLASSIC:
                    return new PorcentagemCashbackClassic();

                case GeneroEnum.MPB:
                    return new PorcentagemCashbackMpb();

                case GeneroEnum.POP:
                    return new PorcentagemCashbackPop();

                case GeneroEnum.ROCK:
                    return new PorcentagemCashbackRock();

                default:
                    throw new ArgumentException();
            }
        }
    }
}