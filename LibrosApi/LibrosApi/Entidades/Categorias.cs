using LibrosApi.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Entidades
{
    public class Categorias
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es Requerido")]
        [StringLength(maximumLength: 50)]
        [PrimeraLetraEnMayuscula]
        public string Nombre { get; set; }
        public List<LibrosCategorias> LibrosCategorias { get; set; }
    }
}
