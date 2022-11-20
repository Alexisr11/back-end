using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LibrosApi.Utilidades
{
    public interface IAlmacenarArchivos
    {
        Task borrarArchivo(string ruta, string contenedor);
        Task<string> editarArchivo(string contenedor, IFormFile archivo, string ruta);
        Task<string> guardarArchivo(string contenedor, IFormFile archivo);
    }
}