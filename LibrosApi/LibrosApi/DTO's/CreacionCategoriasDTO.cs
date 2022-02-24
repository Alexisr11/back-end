using LibrosApi.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.DTO_s
{
    public class CreacionCategoriasDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(maximumLength: 10)]
        [PrimeraLetraEnMayuscula]
        public string Nombre { get; set; }
    }
}
