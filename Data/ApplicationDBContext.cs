using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets (Tabelas)
        public DbSet<Parque> Parques { get; set; }
        public DbSet<CondicaoClimatica> CondicoesClimaticas { get; set; }
        public DbSet<HistoricoIrrigacao> HistoricoIrrigacoes { get; set; }
        public DbSet<ConfiguracaoIrrigacao> ConfiguracoesIrrigacao { get; set; }
        public DbSet<RegraCondicaoClimatica> RegrasCondicoesClimaticas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parque>()
                .HasMany(p => p.CondicoesClimaticas)
                .WithOne(c => c.Parque)
                .HasForeignKey(c => c.ParqueId);

            modelBuilder.Entity<Parque>()
                .HasMany(p => p.HistoricoIrrigacoes)
                .WithOne(h => h.Parque)
                .HasForeignKey(h => h.ParqueId);

            modelBuilder.Entity<Parque>()
                .HasMany(p => p.ConfiguracoesIrrigacao)
                .WithOne(c => c.Parque)
                .HasForeignKey(c => c.ParqueId);

            modelBuilder.Entity<Parque>()
                .HasMany(p => p.RegrasCondicoesClimaticas)
                .WithOne(r => r.Parque)
                .HasForeignKey(r => r.ParqueId);

            modelBuilder.Entity<HistoricoIrrigacao>()
                .HasOne(h => h.ConfiguracaoIrrigacao)
                .WithMany()
                .HasForeignKey(h => h.ConfiguracaoIrrigacaoId);

            modelBuilder.Entity<CondicaoClimatica>()
                .Property(c => c.Temperatura)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CondicaoClimatica>()
                .Property(c => c.Umidade)
                .HasPrecision(5, 2);

            modelBuilder.Entity<HistoricoIrrigacao>()
                .Property(h => h.VolumeIrrigado)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HistoricoIrrigacao>()
                .HasKey(h => h.Id);  // Garantir que a chave primária esteja configurada corretamente

            modelBuilder.Entity<ConfiguracaoIrrigacao>()
                .Property(c => c.Intervalo)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ConfiguracaoIrrigacao>()
                .Property(c => c.Duracao)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RegraCondicaoClimatica>()
                .Property(r => r.TemperaturaMaxima)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RegraCondicaoClimatica>()
                .Property(r => r.TemperaturaMinima)
                .HasPrecision(5, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
