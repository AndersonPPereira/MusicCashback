using Microsoft.Extensions.Options;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Exceptions.Common;
using MusicCashback.Domain.Interfaces.Http;
using MusicCashback.Domain.Interfaces.Json;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Infra.Spotify.Common;
using MusicCashback.Infra.Spotify.Interface;
using MusicCashback.Infra.Spotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCashback.Infra.Spotify.Service
{
    public class SpotifyService : ISpotifyService
    {
        private readonly IHttpService _httpService;
        private readonly IJsonService _jsonService;
        private readonly SpotifySettings _spotifySettings;
        private readonly IDiscoRepository _discoRepository;

        public SpotifyService(IHttpService httpService,
            IJsonService jsonService,
            IOptions<SpotifySettings> spotifySettings,
            IDiscoRepository discoRepository)
        {
            _httpService = httpService;
            _jsonService = jsonService;
            _spotifySettings = spotifySettings.Value;
            _discoRepository = discoRepository;
        }

        public async Task InsertDiscs()
        {
            if (_discoRepository.Any())
                return;

            var token = await GetToken();
            var listGeneros = typeof(GeneroEnum).GetEnumValuesWithDescription();
            var listDisco = Disco.ListEmpty();

            foreach (var item in listGeneros)
            {
                var list = await GetDiscsByGenre(token, item);
                listDisco.AddRange(list);
            }

            try
            {
                _discoRepository.AddList(listDisco);
            }
            catch (Exception ex)
            {
                ExceptionData.GetInfoDataException("Disco", ex);
            }
        }

        #region Auxiliary methods
        private async Task<string> GetToken()
        {
            var requestToken = HttpRequestToken.Build(_spotifySettings.TokenUrl, _spotifySettings.ClientId, _spotifySettings.ClientSecret);

            var response = await _httpService.GetTokenBasic(requestToken);

            if (!response.IsSuccess())
                Response.BuildInternalServerError();

            var valueToken = _jsonService.DeserializeObject<SpotifyToken>(response.GetDataString());
            return valueToken.access_token;
        }

        private async Task<List<Disco>> GetDiscsByGenre(string token, EnumKeyValue generoEnum)
        {
            var urlTrack = SpotifyWebBuilder.BuildUrlTrack(_spotifySettings.SearchUrl, generoEnum.Description, _spotifySettings.MaximumLimitByGenre, 1);
            var response = await GetTracks(urlTrack, token);
            var listDisco = Disco.ListEmpty();

            foreach (var item in response?.tracks?.items)
            {
                var artista = Artista.Build(item.artists.FirstOrDefault().name);
                var genero = Genero.Build(generoEnum.Key, generoEnum.Description);

                var disco = Disco.Build(genero.GeneroId, item.name, artista, genero);
                listDisco.Add(disco);
            }

            return listDisco;
        }

        private async Task<ResponseTrack> GetTracks(string url, string token)
        {
            var response = await _httpService.GetAsync(url, token);

            // Melhorar a mensagem de retorno
            if (!response.IsSuccess())
                Response.BuildInternalServerError();

            return _jsonService.DeserializeObject<ResponseTrack>(response.GetDataString());
        }

        #endregion
    }
}
