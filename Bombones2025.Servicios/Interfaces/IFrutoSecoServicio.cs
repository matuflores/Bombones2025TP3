using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IFrutoSecoServicio
    {
        void Borrar(int frutoSecoId);
        bool Existe(FrutoSeco frutoSeco);
        
        List<FrutoSeco> GetFrutoSeco(string? textoParaFiltrar = null);
        void Guardar(FrutoSeco frutoseco);
    }
}