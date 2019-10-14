using MusicCashback.Application.Dto.Cliente;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Entities;
using System;

namespace MusicCashback.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        Response Add(ClienteDto clienteDto);
        Response ObterPorId(int id);
        Cliente ObterPorCpfESenha(string cpf, string senha);
        Response Atualizar(int id, ClienteDto clienteViewModels);
        Response Remove(int id);
    }
}
