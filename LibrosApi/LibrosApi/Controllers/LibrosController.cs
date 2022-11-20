using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using LibrosApi.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenarArchivos almacenadorArchivos;
        private readonly string contendor = "Libros";

        public LibrosController(AplicationDbContext context, 
            IMapper mapper,
            IAlmacenarArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreacionLibrosDTO creacionLibrosDTO)
        {
            var libro = mapper.Map<Libro>(creacionLibrosDTO);

            if (creacionLibrosDTO.Poster != null)
            {
                libro.Poster = await almacenadorArchivos.guardarArchivo(contendor, creacionLibrosDTO.Poster);
            }

            EscribirOrdenAutores(libro);

            context.Add(libro);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private void EscribirOrdenAutores(Libro libro)
        {
            if (libro.LibrosAutores != null)
            {
                for (int i = 0; i < libro.LibrosAutores.Count; i++)
                {
                    libro.LibrosAutores[i].Orden = i;
                }
            }
        }
    }
}
