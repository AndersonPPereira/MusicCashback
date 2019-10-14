using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicCashback.Domain.Entities;
using MusicCashback.Domain.Interfaces.Repository;
using MusicCashback.Domain.ValueObjects;
using MusicCashback.Infra.Data.SQLServer.Context;

namespace MusicCashback.Infra.Data.SQLServer.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        private readonly ContextEf _contextEf;
        public VendaRepository(ContextEf context) : base(context)
        {
            _contextEf = context;
        }

        public List<Venda> ObterListaPorClienteId(int clienteId)
        {
            return _contextEf.Venda
                            .Include(v => v.ItemVenda)
                            .Include(v => v.Cliente)
                            .Where(v => v.Cliente.ClienteId == clienteId).ToList();

        }

        public Venda ObterVendaPorId(int vendaId)
        {
            return _contextEf.Venda
                            .Include(v => v.ItemVenda)
                            .Include(v => v.Cliente)
                            .Where(v => v.VendaId == vendaId).FirstOrDefault();
        }

        public List<Venda> ObterComPaginacao(RequestVendaRangeData consultaVendaRangeDto)
        {
            var where = new Func<Venda, bool>(v => v.Data >= consultaVendaRangeDto.DataInicial && v.Data <= consultaVendaRangeDto.DataFinal);

            var total = _contextEf.Venda.Count(where);

            if (total == 0)
                return Venda.ListEmpty();

            consultaVendaRangeDto.WithPagination(total);

            return _contextEf.Venda
                            .Include(v => v.ItemVenda)
                            .Include(v => v.Cliente)
                            .Where(where)
                            .OrderByDescending(d => d.Data)
                            .Skip(consultaVendaRangeDto.Paginacao.Skip)
                            .Take(consultaVendaRangeDto.Paginacao.Take)
                            .ToList();
        }
    }
}
