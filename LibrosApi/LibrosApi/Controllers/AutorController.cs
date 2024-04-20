using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using LibrosApi.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AutorController: ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        private IAlmacenarArchivos almacenarArchivos;
        private readonly string contenedor = "autores";

        public AutorController(AplicationDbContext context, IMapper mapper, 
            IAlmacenarArchivos almacenarArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenarArchivos = almacenarArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Autores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var autores = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreacionAutorDTO creacionAutorDTO)
        {
            var autor = mapper.Map<Autor>(creacionAutorDTO);

            if (creacionAutorDTO.Foto != null)
            {
                autor.Foto = await almacenarArchivos.guardarArchivo(contenedor, creacionAutorDTO.Foto);  
            }
            
            context.Add(autor);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AutorDTO>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return mapper.Map<AutorDTO>(autor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] CreacionAutorDTO creacionAutorDTO)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            autor = mapper.Map(creacionAutorDTO, autor);

            if (creacionAutorDTO.Foto != null)
            {
                autor.Foto = await almacenarArchivos.editarArchivo(contenedor, creacionAutorDTO.Foto, autor.Foto);
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();

            await almacenarArchivos.borrarArchivo(autor.Foto, contenedor);
            return NoContent();
        }

        [HttpPost("buscarPorNombre")]
        public async Task<ActionResult<List<LibroAutorDTO>>> buscarPorNombre( [FromBody] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) { return new List<LibroAutorDTO>(); }

            var autores = await context.Autores
                .Where(x => x.Nombre.Contains(nombre))
                .Select(x => new LibroAutorDTO { Id = x.Id, Nombre = x.Nombre, Foto = x.Foto })
                .Take(5)
                .ToListAsync();

            Console.WriteLine(autores);
            return autores;
        }

    }
}
