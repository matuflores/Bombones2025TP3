using Bombones2025.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly string connectionString = null!;

        public UsuarioRepositorio()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public Usuario? Login(string userName)
        {
            Usuario usuario;
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                string query = "SELECT UsuarioId, Nombre, ClaveHash, RolId FROM Usuarios WHERE Nombre=@usuario";
                using (SqlCommand cmd = new(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", userName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        usuario = new Usuario
                        {
                            UsuarioId = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            ClaveHash = reader.GetString(2),
                        };

                    }

                }
            }
            return usuario;
        }
    }
}
