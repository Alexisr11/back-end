using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using LibrosApi.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriasController : ControllerBase
    {
        public readonly ILogger<CategoriasController> logger;
        private readonly IMapper mapper;

        public AplicationDbContext Context { get; }

        public CategoriasController(ILogger<CategoriasController> logger,
            AplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            Context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasDTO>>> Get([FromQuery] PaginacionDTO paginacionDto)
        {
            var queryable = Context.Categorias.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var categorias = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDto).ToListAsync();
            return mapper.Map<List<CategoriasDTO>>(categorias);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriasDTO>> Get(int id)
        {
            var categoria = await Context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return mapper.Map<CategoriasDTO>(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreacionCategoriasDTO creacionCategoriaDto)
        {
            var categoria = mapper.Map<Categorias>(creacionCategoriaDto);
            Context.Add(categoria);
            await Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreacionCategoriasDTO creacionCategoriasDto)
        {
            var categoria = await Context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound();

            categoria = mapper.Map(creacionCategoriasDto, categoria);
            await Context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await Context.Categorias.AnyAsync(x => x.Id == id);

            if (existe == null)
            {
                return NotFound();
            }

            Context.Remove(new Categorias() { Id = id});
            await Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
