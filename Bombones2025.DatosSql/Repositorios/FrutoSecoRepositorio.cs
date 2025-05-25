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
    public class FrutoSecoRepositorio
    {
        private List<FrutoSeco> frutosSecos = new();
        private readonly string? connectionString;
        public FrutoSecoRepositorio()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            LeerDatos();
        }

        private void LeerDatos()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "SELECT FrutoSecoId, Descripcion FROM FrutosSecos";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FrutoSeco frutoSeco = ConstruirFrutoSeco(reader);
                            frutosSecos.Add(frutoSeco);
                        }
                    }
                }
            }
        }

        public List<FrutoSeco> GetFrutoSeco()
        {
            return frutosSecos.OrderBy(p => p.Descripcion).ToList();
        }
        private FrutoSeco ConstruirFrutoSeco(SqlDataReader reader)
        {
            return new FrutoSeco
            {
                FrutoSecoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
    }
}
