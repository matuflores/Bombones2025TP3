using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public interface IUsuarioServicio
    {
        Usuario? Login(string username);
    }
}