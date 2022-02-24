using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.DTO_s
{
    public class PaginacionDTO
    {
        public int pagina { get; set; } = 1;
        public int registrosPorPagina = 10;
        public readonly int cantidadMaximaRegistrosPorPagina = 50;

        public int RegistrosPorPagina
        {
            get
            {
                return registrosPorPagina;
            }
            set
            {
                registrosPorPagina = (value > cantidadMaximaRegistrosPorPagina ? cantidadMaximaRegistrosPorPagina : value);
            }
        }
    }
}
