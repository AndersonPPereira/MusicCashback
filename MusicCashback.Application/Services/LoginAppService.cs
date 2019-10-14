using MusicCashback.Application.Dto.Login;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Exceptions.Common;
using MusicCashback.Domain.Validation;

namespace MusicCashback.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IJwtService _jwtService;

        public LoginAppService(IClienteAppService clienteAppService, IJwtService jwtService)
        {
            _clienteAppService = clienteAppService;
            _jwtService = jwtService;
        }

        public Response Login(LoginDto loginDto)
        {
            if(loginDto.IsNotValid())
                return Response.BuildBadRequest(ExceptionMessages.CpfESenhaEmBranco);

            var cliente = _clienteAppService.ObterPorCpfESenha(CpfValidation.Limpa(loginDto.Cpf), loginDto.Senha);

            if (cliente == null)
                return Response.BuildBadRequest(ExceptionMessages.ClienteNaoEncontrado);

            return Response.BuildSuccess(_jwtService.CreateJsonWebToken(cliente));
        }
    }
}
