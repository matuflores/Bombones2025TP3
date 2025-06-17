using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface IFrutoSecoRepositorio
    {
        void Agregar(FrutoSeco frutoseco);
        void Borrar(int frutoSecoId);
        void Editar(FrutoSeco frutoseco);
        bool Existe(FrutoSeco frutoSeco);
        List<FrutoSeco> Filtrar(string textoParaFiltrar);
        List<FrutoSeco> GetFrutoSeco();

        int GetCantidad();
    }
}