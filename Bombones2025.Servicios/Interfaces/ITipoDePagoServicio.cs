using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface ITipoDePagoServicio
    {
        void Borrar(int tipoPagoId);
        bool Existe(TipoDePago tipoDePago);
        List<TipoDePago> Filtrar(string textoParaFiltrar);
        List<TipoDePago> GetTipoDePago();
        void Guardar(TipoDePago tipoDePago);
    }
}