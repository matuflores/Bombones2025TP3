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
    public class PaisRepositorio
    {
        private List<Pais> paises = new();
        private readonly string? connectionString;
        //creo la lista y la conexion
        public PaisRepositorio()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            LeerDatos();
        }

        private void LeerDatos()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "SELECT PaisId, NombrePais FROM Paises";
                using (var cmd = new SqlCommand(query,cnn))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pais pais = ConstruirPais(reader);
                            paises.Add(pais);
                        }
                    }
                }
            }
        }

        //luego de leer y construir el Pais, lo Traigo con getPais
        public List<Pais> GetPais()
        {
            return paises.OrderBy(p => p.NombrePais).ToList();
        } 
        private Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais
            {
                PaisId = reader.GetInt32(0),
                NombrePais=reader.GetString(1)
            };
        }
    }
}
