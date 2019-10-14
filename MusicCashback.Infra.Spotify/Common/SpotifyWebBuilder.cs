using MusicCashback.Domain.Common;
namespace MusicCashback.Infra.Spotify.Common
{
    public class SpotifyWebBuilder
    {
        public static string BuildUrlTrack(string urlBase, string genero, int max, int offset)
        {
            return $"{urlBase}q=genre%3A{genero.ToLower()}&type=track&limit={max}&offset={offset}";
        }
    }
}
