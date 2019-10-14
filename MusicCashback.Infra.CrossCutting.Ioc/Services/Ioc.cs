using Microsoft.Extensions.DependencyInjection;
using MusicCashback.Application.Interfaces;
using MusicCashback.Application.Services;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Interfaces.Http;
using MusicCashback.Domain.Interfaces.Json;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Repositories;
using MusicCashback.Infra.Data.SQLServer.UoW;
using MusicCashback.Infra.HTTP.Services;
using MusicCashback.Infra.Json.Services;
using MusicCashback.Infra.Spotify;
using MusicCashback.Infra.Spotify.Interface;
using MusicCashback.Infra.Spotify.Service;

namespace MusicCashback.Infra.CrossCutting.Ioc.Services
{
    public class Ioc
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Injeção de dependência

            // Aplication
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IVendaAppService, VendaAppService>();
            services.AddScoped<ICatalogoAppService, CatalogoAppService>();
            services.AddScoped<IJwtService, JwtService>();

            // Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IDiscoRepository, DiscoRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Spotify
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddScoped<ISpotifyMain, SpotifyMain>();

            // Services
            services.AddScoped<IJsonService, JsonService>();
            services.AddScoped<IHttpService, HttpService>();

            // Commun
            services.AddSingleton<JwtSettings>();

            #endregion
        }
    }
}
