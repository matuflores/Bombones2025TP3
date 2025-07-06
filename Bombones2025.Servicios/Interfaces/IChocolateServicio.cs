using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IChocolateServicio
    {
        
        bool Borrar(int chocolateId, out List<string> errores);
        bool Existe(Chocolate chocolate);
        List<Chocolate> GetChocolate(string? textoParaFiltrar = null);
        //void Guardar(Chocolate chocolate);
        bool Agregar(Chocolate chocolate, out List<string> errores);
        bool Editar(Chocolate chocolate, out List<string> errores);
    }
}