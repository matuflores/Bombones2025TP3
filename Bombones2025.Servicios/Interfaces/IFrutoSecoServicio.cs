using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IFrutoSecoServicio
    {
        void Borrar(int frutoSecoId);
        bool Existe(FrutoSeco frutoSeco);
        List<FrutoSeco> Filtrar(string textoParaFiltrar);
        List<FrutoSeco> GetFrutoSecos();
        void Guardar(FrutoSeco frutoseco);
    }
}