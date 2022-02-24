using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.DTO_s
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        public string Foto { get; set; }
    }
}
