using System;
using System.Collections.Generic;
using apinet6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIPRUEBAS.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Marca> marcas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("PK__MARCA__09889210DE0C8C69");

                entity.ToTable("Marcas");

                entity.Property(e => e.descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(m => m.habilitado);
                //entity.HasOne //relaciones
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
