using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IRellenoServicio
    {
        void Borrar(int rellenoId);
        bool Existe(Relleno relleno);
        List<Relleno> Filtrar(string textoParaFiltrar);
        List<Relleno> GetRelleno();
        void Guardar(Relleno relleno);
    }
}