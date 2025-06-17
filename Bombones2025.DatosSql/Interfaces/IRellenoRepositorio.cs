using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface IRellenoRepositorio
    {
        void Agregar(Relleno relleno);
        void Borrar(int rellenoId);
        void Editar(Relleno relleno);
        bool Existe(Relleno relleno);
        List<Relleno> Filtrar(string textoParaFiltrar);
        List<Relleno> GetRelleno();
    }
}