using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;
using System.Linq;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ContextEf _contextEf;

        public ClienteRepository(ContextEf context) : base(context)
        {
            _contextEf = context;
        }

        public bool Any(string cpf)
        {
            return _contextEf.Cliente.Any(c => c.Cpf.Equals(cpf));
        }

        public Cliente ObterPorCpfESenha(string cpf, string senha)
        {
            return _contextEf.Cliente.Where(c => c.Cpf.Equals(cpf) && c.Senha.Equals(senha)).FirstOrDefault();
        }
    }
}
