using MusicCashback.Domain.Entities;
using MusicCashback.Domain.ValueObjects;

namespace MusicCashback.Application.Interfaces
{
    public interface IJwtService
    {
        JsonWebToken CreateJsonWebToken(Cliente cliente);
    }
}
