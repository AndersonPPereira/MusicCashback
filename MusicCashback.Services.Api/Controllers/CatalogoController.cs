using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.ValueObjects;

namespace MusicCashback.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : Controller
    {
        private readonly ICatalogoAppService _catalogoAppService;

        public CatalogoController(ICatalogoAppService catalogoAppService)
        {
            _catalogoAppService = catalogoAppService;
        }

        [HttpGet]
        public IActionResult Get(int discoId)
        {
            return Ok(_catalogoAppService.ObterPorId(discoId));
        }

        [HttpGet]
        [Route("ObterComPaginacao")]
        public IActionResult ObterComPaginacao([FromBody] RequestCatalogoGenero requestCatalagoGenero)
        {
            return Ok(_catalogoAppService.ObterComPaginacao(requestCatalagoGenero));
        }
    }
}