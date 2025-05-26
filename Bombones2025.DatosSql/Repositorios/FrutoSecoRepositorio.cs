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

        public bool Existe(FrutoSeco frutoSeco)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query;
                    if (frutoSeco.FrutoSecoId == 0)
                    {
                        query = @"SELECT COUNT(*) FROM FrutosSecos 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion)";
                    }
                    else
                    {
                        query = @"SELECT COUNT(*) FROM FrutosSecos 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion) AND
                                FrutoSecoId<>@FrutoSecoId";
                    }

                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        if (frutoSeco.FrutoSecoId != 0)
                        {
                            cmd.Parameters.AddWithValue("@FrutoSecoId", frutoSeco.FrutoSecoId);
                        }
                        cmd.Parameters.AddWithValue("@Descripcion", frutoSeco.Descripcion);
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

        public void Agregar(FrutoSeco frutoseco)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO FrutosSecos (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY()";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", frutoseco.Descripcion);
                        int frutoSecoId = (int)(decimal)cmd.ExecuteScalar();
                        frutoseco.FrutoSecoId = frutoSecoId;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar el registro", ex);
            }
        }

        public void Borrar(int frutoSecoId)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM FrutosSecos WHERE FrutoSecoId=@FrutoSecoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@FrutoSecoId", frutoSecoId);
                        cmd.ExecuteNonQuery();//se ejecuta en comandos que no devuelven datos 
                    }
                }
                FrutoSeco? frutoSecoBorrar = frutosSecos.FirstOrDefault(fs => fs.FrutoSecoId == frutoSecoId);
                if (frutoSecoBorrar == null) return;
                frutosSecos.Remove(frutoSecoBorrar);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(FrutoSeco frutoseco)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE FrutosSecos SET Descripcion=@Descripcion
                                    WHERE FrutoSecoId=@FrutoSecoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", frutoseco.Descripcion);
                        cmd.Parameters.AddWithValue("@PaisId", frutoseco.FrutoSecoId);
                        cmd.ExecuteNonQuery();
                    }
                    FrutoSeco? frutoSecoEditar = frutosSecos.FirstOrDefault(fs => fs.FrutoSecoId == frutoseco.FrutoSecoId);
                    if (frutoSecoEditar == null) return;
                    frutoSecoEditar.Descripcion = frutoseco.Descripcion;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro", ex);
            }
        }

        public List<FrutoSeco> Filtrar(string textoParaFiltrar)
        {
            var listaFiltrada = new List<FrutoSeco>();
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"SELECT * FROM FrutosSecos
                                    WHERE Descripcion LIKE @texto";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        textoParaFiltrar += "%";
                        cmd.Parameters.AddWithValue("@texto", textoParaFiltrar);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var frutoSeco = ConstruirFrutoSeco(reader);
                                listaFiltrada.Add(frutoSeco);
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
