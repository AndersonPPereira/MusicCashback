using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCashback.Application.Dto.Pedido;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.ValueObjects;
using System;

namespace MusicCashback.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendaController : ApiController
    {
        private readonly IVendaAppService _vendaAppService;

        public VendaController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(int vendaId)
        {
            return Ok(_vendaAppService.ObterPorId(vendaId));
        }

        [HttpGet]
        [Route("ObterVendasPorCliente")]
        public IActionResult ObterVendasPorCliente()
        {
            return Ok(_vendaAppService.ObterVendasPorCliente(GetClienteId()));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ObterVendaPorPeriodo")]
        public IActionResult ObterVendaPorPeriodo(RequestVendaRangeData consultaVendaRangeDataDto)
        {
            return Ok(_vendaAppService.ObterPorPeriodo(consultaVendaRangeDataDto));
        }

        [HttpPost]
        public IActionResult Post(PedidoDto pedidoDto)
        {
            return Ok(_vendaAppService.Comprar(pedidoDto, GetClienteId()));
        }
    }
}