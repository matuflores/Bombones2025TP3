using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface ITipoDePagoRepositorio
    {
        void Agregar(FormaDePago tipoDePago);
        void Borrar(int tipoPagoId);
        void Editar(FormaDePago tipoDePago);
        bool Existe(FormaDePago tipoDePago);
        List<FormaDePago> GetTipoDePago(string? textoParaFiltrar = null);


        int GetCantidad();
    }
}