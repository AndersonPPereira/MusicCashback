using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Infra.Data.SQLServer.Mapping
{
    public class DiscoMap : IEntityTypeConfiguration<Disco>
    {
        public void Configure(EntityTypeBuilder<Disco> builder)
        {
            builder.HasKey(d => d.DiscoId);
            builder.Property(d => d.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(d => d.Preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(d => d.Artista).WithMany(d => d.Disco);
            builder.HasMany(d => d.ItemVenda).WithOne(d => d.Disco);
            builder.HasOne(d => d.Genero).WithMany(d => d.Disco);
            builder.Property(d => d.Data).IsRequired().HasColumnType("Datetime").HasDefaultValueSql("GetDate()");
        }
    }
}
