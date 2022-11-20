using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Entidades
{
    public class LibrosCategorias
    {
        public int LibroId { get; set; }
        public int CategoriaId { get; set; }
        public Libro Libro { get; set; }
        public Categorias Categorias { get; set; }
    }
}
