using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicCashback.Domain.Entities;
using MusicCashback.Infra.Data.SQLServer.Mapping;

namespace MusicCashback.Infra.Data.SQLServer.Context
{
    public class ContextEf : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Disco> Disco { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }

        public ContextEf(DbContextOptions<ContextEf> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Conventions

            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            #endregion

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ArtistaMap());
            modelBuilder.ApplyConfiguration(new DiscoMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new ItemVendaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
