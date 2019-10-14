using Microsoft.AspNetCore.Mvc;
using MusicCashback.Application.Dto.Login;
using MusicCashback.Application.Interfaces;

namespace MusicCashback.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ApiController
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginDto loginDto)
        {
            return Ok(_loginAppService.Login(loginDto));
        }
    }
}