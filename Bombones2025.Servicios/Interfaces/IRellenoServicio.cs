using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IRellenoServicio
    {
        
        bool Existe(Relleno relleno);
        List<Relleno> GetRelleno(string? textoParaFiltrar = null);
        bool Borrar(int rellenoId, out List<string> errores);
        bool Agregar(Relleno relleno, out List<string> errores);
        bool Editar(Relleno relleno, out List<string> errores);
        //--
    }
}