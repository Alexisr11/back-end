using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string BookTrailer { get; set; }
        public bool EnLibrerias { get; set; }
        public DateTime FechaDeLanzamiento { get; set; }
        public string Poster { get; set; }
        public List<LibrosAutores> LibrosAutores { get; set; }
        public List<LibrosCategorias> LibrosCategorias { get; set; }
        public List<LibrosLibrerias> LibrosLibrerias { get; set; }

    }
}
