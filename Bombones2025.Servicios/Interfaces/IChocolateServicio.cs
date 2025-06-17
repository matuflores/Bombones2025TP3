using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IChocolateServicio
    {
        //void Borrar(int chocolateId);
        bool Borrar(int chocolateId, out List<string> errores);
        bool Existe(Chocolate chocolate);
        List<Chocolate> Filtrar(string textoParaFiltrar);
        List<Chocolate> GetChocolate();
        //void Guardar(Chocolate chocolate);
        bool Agregar(Chocolate chocolate, out List<string> errores);
        bool Editar(Chocolate chocolate, out List<string> errores);
    }
}