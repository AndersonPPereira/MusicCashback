using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Data.SQLServer.Context;
using MusicCashback.Infra.Spotify.Interface;
using System;

namespace MusicCashback.Infra.Spotify
{
    public class SpotifyMain : ISpotifyMain
    {
        private readonly IGeneroRepository _generoRepository;

        public SpotifyMain(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public void Execute(IServiceScope scope)
        {
            #region Migrations

            try
            {
                var list = Genero.ListEmpty();
                var context = scope.ServiceProvider.GetService<ContextEf>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a migração dos dados iniciais. Erro:" + ex);
            }

            #endregion

            #region Spotify

            try
            {
                var spotifyService = scope.ServiceProvider.GetService<ISpotifyService>();
                spotifyService.InsertDiscs().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consumir a API do Spotify para inserir os discos por cada gênero. Erro:" + ex);
            }

            #endregion
        }
    }
}
