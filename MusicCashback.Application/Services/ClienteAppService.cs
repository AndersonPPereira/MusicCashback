using AutoMapper;
using MusicCashback.Application.Dto.Cliente;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Exceptions.Common;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Domain.Validation;
using System;

namespace MusicCashback.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteAppService(IClienteRepository clienteRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Response Add(ClienteDto clienteDto)
        {
            #region Validation
            if (clienteDto.IsNotValid())
                return Response.BuildBadRequest(ExceptionMessages.ObjetoInvalido);

            if(!clienteDto.CpfValid())
                return Response.BuildBadRequest(ExceptionMessages.CpfInvalido);

            if (_clienteRepository.Any(CpfValidation.Limpa(clienteDto.Cpf)))
                return Response.BuildBadRequest(ExceptionMessages.CpfJaCadastrado); 
            #endregion

            var cliente = _clienteRepository
                .Add(_mapper.Map<Cliente>(clienteDto));

            if (!_unitOfWork.Commit())
                throw new ExceptionHttp(ExceptionMessages.ErroAoSalvarDados);

            return Response.BuildSuccess(_mapper.Map<ClienteDto>(cliente));
        }

        public Response ObterPorId(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);

            if(cliente == null)
                return Response.BuildBadRequest(ExceptionMessages.ClienteNaoEncontrado);

            return Response.BuildSuccess(_mapper.Map<ClienteDto>(cliente));
        }

        public Response Atualizar(int id, ClienteDto clienteDto)
        {

            if(clienteDto.IsNotValid())
                return Response.BuildBadRequest(ExceptionMessages.ClienteDadosInvalidos);

            var cliente = _mapper.Map<Cliente>(clienteDto);
            cliente.ClienteId = id;

            var clienteNew = _clienteRepository.Atualiza(cliente);

            if (!_unitOfWork.Commit())
                throw new ExceptionHttp(ExceptionMessages.ErroAoSalvarDados);

            return Response.BuildSuccess(_mapper.Map<ClienteDto>(clienteNew));

        }

        public Response Remove(int id)
        {
            if (_clienteRepository.ObterPorId(id) == null)
                return Response.BuildBadRequest(ExceptionMessages.ClienteNaoEncontrado);

            _clienteRepository.Remove(id);

            return Response.BuildSuccess(ExceptionMessages.ClienteExcluido);
        }

        public Cliente ObterPorCpfESenha(string cpf, string senha)
        {
            return _clienteRepository.ObterPorCpfESenha(cpf, senha);
        }

        public void Dispose() => GC.SuppressFinalize(this);

    }
}
