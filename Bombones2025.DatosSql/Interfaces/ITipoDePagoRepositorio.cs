using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface ITipoDePagoRepositorio
    {
        void Agregar(TipoDePago tipoDePago);
        void Borrar(int tipoPagoId);
        void Editar(TipoDePago tipoDePago);
        bool Existe(TipoDePago tipoDePago);
        List<TipoDePago> Filtrar(string textoParaFiltrar);
        List<TipoDePago> GetTipoDePago();

        int GetCantidad();
    }
}