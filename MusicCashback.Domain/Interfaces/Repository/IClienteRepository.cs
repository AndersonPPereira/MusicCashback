using MusicCashback.Domain.Entities;

namespace MusicCashback.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpfESenha(string cpf, string senha);
        bool Any(string cpf);
    }
}
