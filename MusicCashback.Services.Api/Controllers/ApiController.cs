using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Exceptions.Common;

namespace MusicCashback.Services.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected int GetClienteId()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value.ToInt();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}