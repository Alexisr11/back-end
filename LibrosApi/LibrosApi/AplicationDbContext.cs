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

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
