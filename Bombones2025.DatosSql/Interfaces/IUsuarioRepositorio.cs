using Bombones2025.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario? Login(string userName);
    }
}