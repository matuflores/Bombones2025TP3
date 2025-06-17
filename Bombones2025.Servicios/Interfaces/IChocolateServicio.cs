using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IChocolateServicio
    {
        void Borrar(int chocolateId);
        bool Existe(Chocolate chocolate);
        List<Chocolate> Filtrar(string textoParaFiltrar);
        List<Chocolate> GetChocolate();
        void Guardar(Chocolate chocolate);
    }
}