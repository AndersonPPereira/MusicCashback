using System;
using System.Linq;
using AutoMapper;
using MusicCashback.Application.Dto.Pedido;
using MusicCashback.Application.Interfaces;
using MusicCashback.Domain.Common;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Enum;
using MusicCashback.Domain.Exceptions.Common;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Domain.ValueObjects;
using MusicCashback.Domain.ValueObjects.Factory;

namespace MusicCashback.Application.Services
{
    public class VendaAppService : IVendaAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IDiscoRepository _discoRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VendaAppService(IClienteRepository clienteRepository,
           IDiscoRepository discoRepository,
           IGeneroRepository generoRepository,
           IVendaRepository vendaRepository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _discoRepository = discoRepository;
            _generoRepository = generoRepository;
            _vendaRepository = vendaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Response Comprar(PedidoDto pedidoDto, int clienteId)
        {
            try
            {
                var listItemVenda = ItemVenda.ListEmpty();
                var discos = Disco.ListEmpty();

                #region Validation

                if (pedidoDto.IsNotValid())
                    return Response.BuildBadRequest();

                var cliente = _clienteRepository.ObterPorId(clienteId);

                if (cliente == null)
                    return Response.BuildBadRequest(ExceptionMessages.ClienteNaoEncontrado);

                discos = _discoRepository.ObterListaPorId(pedidoDto.GetListId());

                if (!discos.Any())
                    return Response.BuildBadRequest(ExceptionMessages.DiscoNaoEncontrado);

                #endregion

                foreach (var disco in discos)
                {
                    var pedidoItem = pedidoDto.ItemPedidoDto.Where(i => i.DiscoId == disco.DiscoId).FirstOrDefault();

                    var cashback = PorcentagemCachbackFactory.
                        CriaInstanciaPorcentagemCashback((GeneroEnum)_generoRepository.ObterPorId(disco.Genero.GeneroId).GeneroId)
                        .CalculaValorCashbackPorGenero(DateTime.Now.DayOfWeek);

                    listItemVenda.Add(ItemVenda.Build(pedidoItem.Quantidade, cashback, disco));
                }

                var venda = _vendaRepository.Add(Venda.Build(cliente, listItemVenda));

                if (!_unitOfWork.Commit())
                    Response.BuildBadRequest(ExceptionMessages.ErroAoSalvarDados);

                return Response.BuildSuccess(_mapper.Map<VendaDto>(venda));
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError(ex.Message);
            }
        }

        public Response ObterPorId(int vendaId)
        {
            try
            {
                if (vendaId < 1)
                    return Response.BuildBadRequest(ExceptionMessages.VendaIdNaoInformado);

                return Response.BuildSuccess(_mapper.Map<VendaDto>(_vendaRepository.ObterVendaPorId(vendaId)));
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError(ex.Message);
            }
        }

        public Response ObterVendasPorCliente(int clienteId)
        {
            try
            {
                var listVendaDto = VendaDto.ListEmpty();
                var cliente = _clienteRepository.ObterPorId(clienteId);

                if (cliente == null)
                    return Response.BuildBadRequest(ExceptionMessages.ClienteNaoEncontrado);

                var vendas = _vendaRepository.ObterListaPorClienteId(clienteId);

                if (vendas == null)
                    return Response.BuildBadRequest(ExceptionMessages.ClienteSemVendas);

                foreach (var venda in vendas)
                {
                    listVendaDto.Add(_mapper.Map<VendaDto>(venda));
                }

                return Response.BuildSuccess(listVendaDto);
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError(ex.Message);
            }
        }

        public Response ObterPorPeriodo(RequestVendaRangeData consultaVendaRangeData)
        {
            try
            {
                var listVendaDto = VendaDto.ListEmpty();

                if (consultaVendaRangeData.IsNotValid())
                    return Response.BuildBadRequest(ExceptionMessages.VendaRangeDatasInvalido);

                var vendas = _vendaRepository.ObterComPaginacao(consultaVendaRangeData);

                if (!vendas.Any())
                    return Response.BuildBadRequest(ExceptionMessages.VendaNaoEncontrada);

                foreach (var venda in vendas)
                {
                    listVendaDto.Add(_mapper.Map<VendaDto>(venda));
                }

                return Response.BuildSuccess(listVendaDto);

            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError(ex.Message);
            }
        }
    }
}
