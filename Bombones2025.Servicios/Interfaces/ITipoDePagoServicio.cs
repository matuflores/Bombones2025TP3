using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface ITipoDePagoServicio
    {
        bool Borrar(int tipoPagoId, out List<string> errores);
        bool Existe(FormaDePago tipoDePago);
        //List<TipoDePago> Filtrar(string textoParaFiltrar);
        List<FormaDePago> GetTipoDePago(string? textoParaFiltrar = null);
        bool Agregar(FormaDePago tipoDePago, out List<string> errores);
        bool Editar(FormaDePago tipoDePago, out List<string> errores);
    }
}