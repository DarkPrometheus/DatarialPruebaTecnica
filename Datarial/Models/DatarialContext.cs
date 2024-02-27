using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datarial.Models
{
    public partial class DatarialContext : DbContext
    {
        public DatarialContext()
        {
        }

        public DatarialContext(DbContextOptions<DatarialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FacturaId).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.ToTable("FacturaDetalle");

                entity.Property(e => e.FacturaDetalleId).ValueGeneratedNever();

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK__FacturaDe__Factu__3B75D760");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__FacturaDe__Produ__3C69FB99");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
