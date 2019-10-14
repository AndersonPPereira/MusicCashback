using Microsoft.IdentityModel.Tokens;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MusicCashback.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public JsonWebToken CreateJsonWebToken(Cliente cliente)
        {
            // 0 - Criando as Claims(atributos).
            var identity = GetClaimsIdentity(cliente);

            // 1 - Criando o Token de acordo com as configurações em JwtSettings.
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                IssuedAt = _jwtSettings.IssuedAt,
                NotBefore = _jwtSettings.NotBefore,
                Expires = _jwtSettings.AccessTokenExpiration,
                SigningCredentials = _jwtSettings.SigningCredentials
            });

            // 2 - Escrevendo o Token(Gerando uma string criptografada).
            var accessToken = handler.WriteToken(securityToken);

            // 3 - Retorna o objeto com informação do token.
            return new JsonWebToken
            {
                Authenticated = true,
                Created = _jwtSettings.IssuedAt.ToString("MM/dd/yyyy HH:mm"),
                ExpiresIn = _jwtSettings.AccessTokenExpiration.ToString("MM/dd/yyyy HH:mm"),
                AccessToken = accessToken,
                Message = "Ok"
            };
        }

        private static ClaimsIdentity GetClaimsIdentity(Cliente cliente)
        {
            var identity = new ClaimsIdentity("Bearer");
            identity.AddClaim(new Claim(ClaimTypes.Name, cliente.Nome));
            identity.AddClaim(new Claim(ClaimTypes.Sid, cliente.ClienteId.ToString()));

            return identity;
        }
    }
}
