using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project.Shared.Models;
namespace Project.Server.Models
{
    public partial class TrackContext : DbContext
    {
        public TrackContext()
        {
        }

        public TrackContext(DbContextOptions<TrackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Entrega> Entregas { get; set; } = null!;
        public virtual DbSet<Imagene> Imagenes { get; set; } = null!;
        public virtual DbSet<Localizacione> Localizaciones { get; set; } = null!;
        public virtual DbSet<TrackMobileLocation> TrackMobileLocations { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=TrackConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("EMPRESAS");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cuit)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.FlActivo).HasColumnName("Fl_Activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.ToTable("ENTREGAS");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionEntrega)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EntregaDocumentos)
                    .IsUnicode(false)
                    .HasColumnName("Entrega_Documentos");

                entity.Property(e => e.EntregaFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("Entrega_FechaHora");

                entity.Property(e => e.EntregaFlEntregado).HasColumnName("Entrega_Fl_Entregado");

                entity.Property(e => e.EntregaFlNoEntregado).HasColumnName("Entrega_Fl_NoEntregado");

                entity.Property(e => e.EntregaFlProblemas).HasColumnName("Entrega_Fl_Problemas");

                entity.Property(e => e.EntregaFlTarde).HasColumnName("Entrega_Fl_Tarde");

                entity.Property(e => e.EntregaObservaciones)
                    .IsUnicode(false)
                    .HasColumnName("Entrega_Observaciones");

                entity.Property(e => e.FechaHoraEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdSisCliente).HasColumnName("IdSis_Cliente");

                entity.Property(e => e.IdSisInstitucion).HasColumnName("IdSis_Institucion");

                entity.Property(e => e.IdSisMedico).HasColumnName("IdSis_Medico");

                entity.Property(e => e.IdSisResponsableIngreso).HasColumnName("IdSis_ResponsableIngreso");

                entity.Property(e => e.IdSisTramite).HasColumnName("IdSis_Tramite");

                entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.LocalidadEntrega)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.LugarEntrega)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Material).IsUnicode(false);

                entity.Property(e => e.Medico)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.Property(e => e.Origen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinciaEntrega)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SectorEntrega)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SisTramite).HasColumnName("Sis_Tramite");

                entity.Property(e => e.TelefonoEntrega)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTREGAS_EMPRESAS");

                entity.HasOne(d => d.IdUsuarioAsignadoNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdUsuarioAsignado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTREGAS_USUARIOS");
            });

            modelBuilder.Entity<Imagene>(entity =>
            {
                entity.ToTable("IMAGENES");

                entity.Property(e => e.TipoMime).HasMaxLength(100);
            });

            modelBuilder.Entity<Localizacione>(entity =>
            {
                entity.ToTable("LOCALIZACIONES");

                entity.Property(e => e.FechaHoraGps)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");

                entity.HasOne(d => d.IdEntregaNavigation)
                    .WithMany(p => p.Localizaciones)
                    .HasForeignKey(d => d.IdEntrega)
                    .HasConstraintName("FK_LOCALIZACIONES_ENTREGAS");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Localizaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_LOCALIZACIONES_USUARIOS");
            });

            modelBuilder.Entity<TrackMobileLocation>(entity =>
            {
                entity.ToTable("TRACK_MOBILE_LOCATION");

                entity.Property(e => e.DeviceId).HasMaxLength(50);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Longitude)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Timestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AndroidId)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHoraGps).HasColumnType("datetime");

                entity.Property(e => e.FlActivo).HasColumnName("Fl_Activo");

                entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_EMPRESAS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
