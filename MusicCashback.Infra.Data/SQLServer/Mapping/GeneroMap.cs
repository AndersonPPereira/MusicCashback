using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Infra.Data.SQLServer.Mapping
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.Property(g => g.GeneroId).ValueGeneratedNever();
            builder.Property(g => g.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.HasMany(g => g.Disco).WithOne(g => g.Genero);
            builder.Property(g => g.Data).IsRequired().HasColumnType("Datetime").HasDefaultValueSql("GetDate()");
        }
    }
}
