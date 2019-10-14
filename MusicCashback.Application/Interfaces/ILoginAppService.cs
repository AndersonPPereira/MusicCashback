using MusicCashback.Application.Dto.Login;
using MusicCashback.Domain.Common;

namespace MusicCashback.Application.Interfaces
{
    public interface ILoginAppService
    {
        Response Login(LoginDto loginDto);
    }
}
