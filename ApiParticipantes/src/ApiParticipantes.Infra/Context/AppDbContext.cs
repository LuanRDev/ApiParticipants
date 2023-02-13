using ApiParticipantes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiParticipantes.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Participante> Participantes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participante>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("participantes_pkey");

                entity.ToTable("participantes");

                entity.Property(e => e.Id).HasColumnName("codigo_participante");
                entity.Property(e => e.CodigoEvento).HasColumnName("codigo_evento");
                entity.Property(e => e.Cpf).HasColumnName("cpf");
                entity.Property(e => e.DataParticipacao).HasColumnName("data_participacao");
                entity.Property(e => e.Nome).HasColumnName("nome");
            });
        }
    }
}
