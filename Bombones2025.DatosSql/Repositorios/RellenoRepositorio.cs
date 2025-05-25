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
    public class RellenoRepositorio
    {
        private List<Relleno> rellenos = new();
        private readonly string? connectionString;
        //creo la lista y la conexion
        public RellenoRepositorio()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            LeerDatos();
        }

        private void LeerDatos()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "SELECT RellenoId, Descripcion FROM Rellenos";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Relleno relleno = ConstruirRelleno(reader);
                            rellenos.Add(relleno);
                        }
                    }
                }
            }
        }

        //luego de leer y construir el Pais, lo Traigo con getPais
        public List<Relleno> GetRelleno()
        {
            return rellenos.OrderBy(p => p.Descripcion).ToList();
        }
        private Relleno ConstruirRelleno(SqlDataReader reader)
        {
            return new Relleno
            {
                RellenoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
    }
}
