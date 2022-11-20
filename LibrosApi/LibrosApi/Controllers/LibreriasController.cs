using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using LibrosApi.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Controllers
{
    [ApiController]
    [Route("api/librerias")]
    public class LibreriasController: ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public LibreriasController(AplicationDbContext Context, IMapper mapper)
        {
            context = Context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreacionLibreriasDTO creacionLibreriasDTO)
        {
            var libreria = mapper.Map<Librerias>(creacionLibreriasDTO);
            context.Add(libreria);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<LibreriasDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Librerias.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var librerias = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<LibreriasDTO>>(librerias);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibreriasDTO>> Get(int id)
        {
            var libreria = await context.Librerias.FirstOrDefaultAsync(x => x.Id == id);

            if (libreria == null)
            {
                return NotFound();
            }

            return mapper.Map<LibreriasDTO>(libreria);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, [FromBody] CreacionLibreriasDTO creacionLibreriasDTO)
        {
            var libreria = await context.Librerias.FirstOrDefaultAsync(x => x.Id == id);

            if (libreria == null)
            {
                return NoContent();
            }

            libreria = mapper.Map(creacionLibreriasDTO, libreria);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = context.Librerias.AnyAsync(x => x.Id == id);

            if (existe == null)
            {
                return NotFound();
            }

            context.Remove(new Librerias() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
