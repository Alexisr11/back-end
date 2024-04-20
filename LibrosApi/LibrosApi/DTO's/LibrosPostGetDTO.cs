using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.DTO_s
{
    public class LibrosPostGetDTO
    {
        public List<CategoriasDTO> Categorias { get; set; }
        public List<LibreriasDTO> Librerias { get; set; }
    }
}
