using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IPaisServicio
    {
        bool Borrar(int paisId, out List<string> errores);
        bool Existe(Pais pais);
        //List<Pais> Filtrar(string textoParaFiltrar);
        List<Pais> GetPais(string? textoParaFiltrar=null);
        bool Agregar(Pais pais, out List<string> errores);
        bool Editar(Pais pais, out List<string> errores);
    }
}