using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Infra.Data.SQLServer.Mapping
{
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.HasKey(i => i.ItemVendaId);
            builder.Property(i => i.ValorUnitario).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(i => i.Quantidade).HasColumnType("int").IsRequired();
            builder.Property(i => i.ValorTotal).HasColumnType("decimal(18, 2)").IsRequired();
            builder.HasOne(i => i.Venda).WithMany(i => i.ItemVenda);
            builder.HasOne(i => i.Disco).WithMany(i => i.ItemVenda);
            builder.Property(v => v.Data).IsRequired().HasColumnType("Datetime").HasDefaultValueSql("GetDate()");
        }
    }
}
