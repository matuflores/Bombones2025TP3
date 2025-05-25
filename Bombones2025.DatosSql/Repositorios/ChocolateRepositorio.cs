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
    public class ChocolateRepositorio
    {
        private List<Chocolate> chocolates = new();
        private readonly string? connectionString;
        public ChocolateRepositorio()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            LeerDatos();
        }

        private void LeerDatos()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "SELECT ChocolateId, Descripcion FROM Chocolates";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Chocolate chocolate = ConstruirChocolate(reader);
                            chocolates.Add(chocolate);
                        }
                    }
                }
            }
        }

        public List<Chocolate> GetChocolate()
        {
            return chocolates.OrderBy(p => p.Descripcion).ToList();
        }
        private Chocolate ConstruirChocolate(SqlDataReader reader)
        {
            return new Chocolate
            {
                ChocolateId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
    }
}
