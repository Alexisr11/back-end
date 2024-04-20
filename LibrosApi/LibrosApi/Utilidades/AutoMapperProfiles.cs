using AutoMapper;
using LibrosApi.DTO_s;
using LibrosApi.Entidades;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace LibrosApi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {

        }

        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Categorias, CategoriasDTO>().ReverseMap();
            CreateMap<CreacionCategoriasDTO, Categorias>();
            CreateMap<Autor, AutorDTO>().ReverseMap();
            CreateMap<CreacionAutorDTO, Autor>()
                .ForMember(x => x.Foto, opciones => opciones.Ignore());

            CreateMap<Librerias, LibreriasDTO>()
                .ForMember(x => x.Latitud, dto => dto.MapFrom(campo => campo.Ubicacion.Y))
                .ForMember(x => x.Longitud, dto => dto.MapFrom(campo => campo.Ubicacion.X));

            CreateMap<CreacionLibreriasDTO, Librerias>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(dto =>
                geometryFactory.CreatePoint(new Coordinate(dto.Longitud, dto.Latitud))));

            CreateMap<CreacionLibrosDTO, Libro>()
                .ForMember(x => x.Poster, opciones => opciones.Ignore())
                .ForMember(x => x.LibrosCategorias, opciones => opciones.MapFrom(MapearLibrosCategorias))
                .ForMember(x => x.LibrosLibrerias, opciones => opciones.MapFrom(MapearLibrosLibrerias))
                .ForMember(x => x.LibrosAutores, opciones => opciones.MapFrom(MapearLibrosAutores));
        }

        private List<LibrosAutores> MapearLibrosAutores(CreacionLibrosDTO creacionLibrosDTO,
            Libro libro)
        {
            var resultado = new List<LibrosAutores>();

            if (creacionLibrosDTO.Autores == null) { return resultado; }

            foreach (var actor in creacionLibrosDTO.Autores)
            {
                resultado.Add(new LibrosAutores() { AutorId = actor.Id, Personaje = actor.Personaje });
            }

            return resultado;
        }

        private List<LibrosCategorias> MapearLibrosCategorias(CreacionLibrosDTO creacionLibrosDTO,
            Libro libro)
        {
            var resultado = new List<LibrosCategorias>();

            if (creacionLibrosDTO.CategoriasIds == null) { return resultado; }

            foreach (var id in creacionLibrosDTO.CategoriasIds)
            {
                resultado.Add(new LibrosCategorias() { CategoriaId = id });
            }

            return resultado;
        }

        private List<LibrosLibrerias> MapearLibrosLibrerias(CreacionLibrosDTO creacionLibrosDTO,
            Libro libro)
        {
            var resultado = new List<LibrosLibrerias>();

            if (creacionLibrosDTO.LibreriasIds == null) { return resultado; }

            foreach (var id in creacionLibrosDTO.LibreriasIds)
            {
                resultado.Add(new LibrosLibrerias() { LibreriaId = id });
            }

            return resultado;
        }
    }
}
