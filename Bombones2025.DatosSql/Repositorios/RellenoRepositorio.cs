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

        public bool Existe(Relleno relleno)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query;
                    if (relleno.RellenoId == 0)
                    {
                        query = @"SELECT COUNT(*) FROM Rellenos 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion)";
                    }
                    else
                    {
                        query = @"SELECT COUNT(*) FROM Rellenos 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion) AND
                                RellenoId<>@RellenoId";
                    }

                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        if (relleno.RellenoId != 0)
                        {
                            cmd.Parameters.AddWithValue("@RellenoId", relleno.RellenoId);
                        }
                        cmd.Parameters.AddWithValue("@Descripcion", relleno.Descripcion);
                        int cantidad = (int)cmd.ExecuteScalar();
                        return cantidad > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar leer el registro", ex);
            }
        }

        public void Agregar(Relleno relleno)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO Rellenos (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY()";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", relleno.Descripcion);
                        int rellenoId = (int)(decimal)cmd.ExecuteScalar();
                        relleno.RellenoId = rellenoId;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar el registro", ex);
            }
        }

        public void Borrar(int rellenoId)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Rellenos WHERE RellenoId=@RellenoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@RellenoId", rellenoId);
                        cmd.ExecuteNonQuery();//se ejecuta en comandos que no devuelven datos 
                    }
                }
                Relleno? rellenoBorrar = rellenos.FirstOrDefault(re => re.RellenoId == rellenoId);
                if (rellenoBorrar == null) return;
                rellenos.Remove(rellenoBorrar);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(Relleno relleno)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE Rellenos SET Descripcion=@Descripcion
                                    WHERE RellenoId=@RellenoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", relleno.Descripcion);
                        cmd.Parameters.AddWithValue("@RellenoId", relleno.RellenoId);
                        cmd.ExecuteNonQuery();
                    }
                    Relleno? rellenoEditar = rellenos.FirstOrDefault(re => re.RellenoId == relleno.RellenoId);
                    if (rellenoEditar == null) return;
                    rellenoEditar.Descripcion = relleno.Descripcion;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro", ex);
            }
        }

        public List<Relleno> Filtrar(string textoParaFiltrar)
        {
            var listaFiltrada = new List<Relleno>();
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"SELECT * FROM Rellenos
                                    WHERE Descripcion LIKE @texto";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        textoParaFiltrar += "%";
                        cmd.Parameters.AddWithValue("@texto", textoParaFiltrar);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var relleno = ConstruirRelleno(reader);
                                listaFiltrada.Add(relleno);
                            }
                        }
                    }
                }
                return listaFiltrada;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
