using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.DbContexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Actividad> actividades { get; set; }
        public DbSet<Aerolinea> aerolineas { get;set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<Hotel> hoteles { get; set; }
        public DbSet<TipoDocumento> tiposDocumentos { get; set; }
        public DbSet<Trabajador> trabajadores { get; set; }
        public DbSet<Vuelo> vuelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.ToTable("Actividad");

                entity.Property(e => e.idAct).HasColumnName("idAct");

                entity.Property(e => e.nameAct)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameAct");

                entity.Property(e => e.duracionAct)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("duracionAct");

                entity.Property(e => e.precioAct)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("precioAct");
            });

            modelBuilder.Entity<Aerolinea>(entity =>
            {
                entity.ToTable("Aerolinea");

                entity.Property(e => e.idAero).HasColumnName("idAero");

                entity.Property(e => e.nameAero)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameAero");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.idCl).HasColumnName("idCl");

                entity.Property(e => e.nameCl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameCl");

                entity.Property(e => e.lnameCl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lnameCl");

                entity.Property(e => e.nroDocCl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nroDocCl");

                entity.Property(e => e.birthdateCl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("birthdateCl");

                entity.Property(e => e.idTd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("idTd");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
