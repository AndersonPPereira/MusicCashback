using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCashback.Domain.Entities;

namespace MusicCashback.Infra.Data.SQLServer.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Cpf).HasColumnType("varchar(11)").IsRequired();
            builder.Property(c => c.Senha).HasColumnType("varchar(20)").IsRequired();
            builder.HasMany(c => c.Venda).WithOne(c => c.Cliente);
            builder.Property(c => c.Data).IsRequired().HasColumnType("Datetime").HasDefaultValueSql("GetDate()");
        }
    }
}
