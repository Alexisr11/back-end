using LibrosApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibrosAutores>()
                .HasKey(x => new { x.LibroId, x.AutorId });

            modelBuilder.Entity<LibrosCategorias>()
                .HasKey(x => new { x.LibroId, x.CategoriaId });

            modelBuilder.Entity<LibrosLibrerias>()
                .HasKey(x => new { x.LibroId, x.LibreriaId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Librerias> Librerias { get; set; }
        public DbSet<LibrosAutores> LibrosAutores { get; set; }
        public DbSet<LibrosCategorias> LibrosCategorias { get; set; }
        public DbSet<LibrosLibrerias> LibrosLibrerias { get; set; }
    }
}
