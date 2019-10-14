using AutoMapper;
using MusicCashback.Application.Dto.Disco;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Exceptions.Common;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Domain.ValueObjects;
using System;
using System.Linq;

namespace MusicCashback.Application.Services
{
    public class CatalogoAppService : ICatalogoAppService
    {
        private readonly IDiscoRepository _discoRepository;
        private readonly IMapper _mapper;

        public CatalogoAppService(IDiscoRepository discoRepository, IMapper mapper)
        {
            _discoRepository = discoRepository;
            _mapper = mapper;
        }

        public Response ObterPorId(int discoId)
        {
            try
            {
                if (discoId <= 0)
                    return Response.BuildBadRequest(ExceptionMessages.DiscoIdNaoInformado);

                return Response.BuildSuccess(_mapper.Map<DiscoDto>(_discoRepository.ObterRelacionamentoPorId(discoId)));
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError(ex.Message);
            }
        }

        public Response ObterComPaginacao(RequestCatalogoGenero requestCatalagoGenero)
        {
            try
            {
                var listDiscos = DiscoDto.ListEmpty();
                var discos = _discoRepository.ObterComPaginacao(requestCatalagoGenero);

                if(!discos.Any())
                    return Response.BuildBadRequest(ExceptionMessages.DiscoNaoEncontrada);

                foreach (var disco in discos)
                {
                    listDiscos.Add(_mapper.Map<DiscoDto>(disco));
                }

                return Response.BuildSuccess(listDiscos);
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError(ex.Message);
            }
        }
    }
}
