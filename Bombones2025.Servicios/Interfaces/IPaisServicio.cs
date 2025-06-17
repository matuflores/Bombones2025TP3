using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IPaisServicio
    {
        void Borrar(int paisId);
        bool Existe(Pais pais);
        List<Pais> Filtrar(string textoParaFiltrar);
        List<Pais> GetPais();
        void Guardar(Pais pais);
    }
}