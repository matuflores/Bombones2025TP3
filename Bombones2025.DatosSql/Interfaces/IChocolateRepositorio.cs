using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface IChocolateRepositorio
    {
        void Agregar(Chocolate chocolate);
        void Borrar(int chocolateId);
        void Editar(Chocolate chocolate);
        bool Existe(Chocolate chocolate);
        List<Chocolate> GetChocolate(string? textoParaFiltrar = null);

        int GetCantidad();
    }
}