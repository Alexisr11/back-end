using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categorias, CategoriasDTO>().ReverseMap();
            CreateMap<CreacionCategoriasDTO, Categorias>();
            CreateMap<Autor, AutorDTO>().ReverseMap();
            CreateMap<CreacionAutorDTO, Autor>()
                .ForMember(x => x.Foto, opciones => opciones.Ignore());
        }
    }
}
