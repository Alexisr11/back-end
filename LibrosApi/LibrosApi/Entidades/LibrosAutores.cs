using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Entidades
{
    public class LibrosAutores
    {
        public int LibroId { get; set; }
        public int AutorId { get; set; }
        public Libro Libro { get; set; }
        public Autor Autor { get; set; }
        [StringLength(maximumLength: 100)]
        public string Personaje { get; set; }
        public int Orden { get; set; }
    }
}
