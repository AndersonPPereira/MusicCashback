using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Infra.Data.SQLServer.Mapping
{
    public class ArtistaMap : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.HasKey(a => a.ArtistaId);
            builder.Property(a => a.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.HasMany(a => a.Disco).WithOne(a => a.Artista);
            builder.Property(a => a.Data).IsRequired().HasColumnType("Datetime").HasDefaultValueSql("GetDate()");
        }
    }
}
