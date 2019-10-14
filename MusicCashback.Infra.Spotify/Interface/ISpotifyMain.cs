using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MusicCashback.Infra.Spotify.Interface
{
    public interface ISpotifyMain
    {
        void Execute(IServiceScope serviceScope);
    }
}
