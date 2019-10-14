using AutoMapper;
using MusicCashback.Application.Dto.Cliente;
using MusicCashback.Application.Dto.Disco;
using MusicCashback.Application.Dto.Pedido;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            CreateMap<VendaDto, Venda>();
            CreateMap<Venda, VendaDto>();

            CreateMap<ItemVendaDto, ItemVenda>();
            CreateMap<ItemVenda, ItemVendaDto>();

            CreateMap<DiscoDto, Disco>();
            CreateMap<Disco, DiscoDto>();

            CreateMap<ArtistaDto, Artista>();
            CreateMap<Artista, ArtistaDto>();

            CreateMap<GeneroDto, Genero>();
            CreateMap<Genero, GeneroDto>();
        }
    }
}
