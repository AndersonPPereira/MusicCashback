using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCashback.Application.Dto.Cliente;
using MusicCashback.Application.Interfaces;

namespace MusicCashback.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteAppService.ObterPorId(GetClienteId()));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] ClienteDto clienteDto)
        {
            return Ok(_clienteAppService.Add(clienteDto));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClienteDto clienteDto)
        {
            return Ok(_clienteAppService.Atualizar(GetClienteId(), clienteDto));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(_clienteAppService.Remove(GetClienteId()));
        }
    }
}
