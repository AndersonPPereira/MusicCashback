using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Infra.Data.SQLServer.Mapping
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.VendaId);
            builder.Property(v => v.Cashback).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(v => v.Valor).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(v => v.Cliente).WithMany(v => v.Venda);
            builder.HasMany(c => c.ItemVenda).WithOne(c => c.Venda);
            builder.Property(v => v.Data).IsRequired().HasColumnType("Datetime").HasDefaultValueSql("GetDate()");
        }
    }
}
