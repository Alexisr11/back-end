using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.DTO_s
{
    public class CreacionAutorDTO
    {
        [Required]
        [StringLength(maximumLength: 200)]
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        public IFormFile Foto { get; set; }
    }
}
