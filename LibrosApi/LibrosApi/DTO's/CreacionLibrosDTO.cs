using LibrosApi.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.DTO_s
{
    public class CreacionLibrosDTO
    {
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string BookTrailer { get; set; }
        public bool EnLibrerias { get; set; }
        public DateTime FechaDeLanzamiento { get; set; }
        public IFormFile Poster { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CategoriasIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> LibreriasIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<CreacionAutorLibroDTO>>))]
        public List<CreacionAutorLibroDTO> Autores { get; set; }
    }
}
