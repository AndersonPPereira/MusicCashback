using MusicCashback.Domain.Common;
using System.Threading.Tasks;

namespace MusicCashback.Domain.Interfaces.Http
{
    public interface IHttpService
    {
        Task<HttpResponse> GetTokenBasic(HttpRequestToken requestToken);
        Task<HttpResponse> PostAsync(string url, object content, string token = null);
        Task<HttpResponse> GetAsync(string url, string token = null);
    }
}
