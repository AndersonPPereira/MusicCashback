using System.ComponentModel;

namespace MusicCashback.Domain.Enum
{
    public enum GeneroEnum
    {
        [Description("POP")]
        POP = 1,
        [Description("MPB")]
        MPB = 2,
        [Description("CLASSIC")]
        CLASSIC = 3,
        [Description("ROCK")]
        ROCK = 4
    }
}
