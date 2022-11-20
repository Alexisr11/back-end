using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Entidades
{
    public class LibrosLibrerias
    {
        public int LibroId { get; set; }
        public int LibreriaId { get; set; }
        public Libro Libro { get; set; }
        public Librerias Librerias { get; set; }
    }
}
