using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface IFrutoSecoRepositorio
    {

        void Agregar(FrutoSeco frutoSeco);
        void Borrar(int frutoSecoId);
        void Editar(FrutoSeco frutoSeco);
        bool Existe(FrutoSeco frutoSeco);
        List<FrutoSeco> GetFrutoSeco(string? textoParaFiltrar = null);

        int GetCantidad();
    }
}