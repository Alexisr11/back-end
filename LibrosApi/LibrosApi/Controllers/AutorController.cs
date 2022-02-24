using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using Microsoft.AspNetCore.Mvc;
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

        public AutorController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreacionAutorDTO creacionAutorDTO)
        {
            var autor = mapper.Map<Autor>(creacionAutorDTO);
            context.Add(autor);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
