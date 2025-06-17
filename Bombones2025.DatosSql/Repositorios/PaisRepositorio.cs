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
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly bool _usarCache;
        private List<Pais> paisesCache = new();
        private readonly string? connectionString;
        //creo la lista y la conexion
        public PaisRepositorio(int umbralCache = 30, bool? usarCache = null)
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            if (usarCache.HasValue && usarCache.Value == true)
            {
                _usarCache = true;
            }
            else
            {
                int cantidadRegistros =GetCantidad();
                _usarCache = cantidadRegistros <= umbralCache;
            }
            if (_usarCache)
            {
                LeerDatos();
            }
        }


        private void LeerDatos()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "SELECT PaisId, NombrePais FROM Paises";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pais pais = ConstruirPais(reader);
                            paisesCache.Add(pais);
                        }
                    }
                }
            }
        }

        //luego de leer y construir el Pais, lo Traigo con getPais
        public List<Pais> GetPais()
        {
            if (_usarCache)
            {
                return paisesCache;
            }
            List<Pais> lista = new List<Pais>();
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = @"SELECT PaisId, NombrePais
                                FROM Paises ORDER BY NombrePais";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pais pais = ConstruirPais(reader);
                            lista.Add(pais);
                        }
                    }
                }
            }
            return lista;
        }
        private Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1)
            };
        }
        //-------------------------------------------------------------------------
        public void Agregar(Pais pais)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO Paises (NombrePais) VALUES (@NombrePais);
                                SELECT SCOPE_IDENTITY()";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
                        int paisId = (int)(decimal)cmd.ExecuteScalar();
                        pais.PaisId = paisId;
                    }
                }
                if (_usarCache)
                {
                    paisesCache.Add(pais);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar el registro", ex);
            }
        }

        public bool Existe(Pais pais)
        {
            if (_usarCache)
            {
                return pais.PaisId == 0 ? paisesCache
                    .Any(p => p.NombrePais.ToLower() == pais.NombrePais.ToLower())
                    : paisesCache.Any(p => p.NombrePais.ToLower() == pais.NombrePais.ToLower()
                    && p.PaisId != pais.PaisId);
            }
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query;
                    if (pais.PaisId == 0)
                    {
                        query = @"SELECT COUNT(*) FROM Paises 
                                WHERE LOWER(NombrePais)=LOWER(@NombrePais)";
                    }
                    else
                    {
                        query = @"SELECT COUNT(*) FROM Paises 
                                WHERE LOWER(NombrePais)=LOWER(@NombrePais) AND
                                PaisId<>@PaisId";
                    }

                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        if (pais.PaisId != 0)
                        {
                            cmd.Parameters.AddWithValue("@PaisId", pais.PaisId);
                        }
                        cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
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

        public void Borrar(int paisId)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Paises WHERE PaisId=@PaisId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@PaisId", paisId);
                        cmd.ExecuteNonQuery();//se ejecuta en comandos que no devuelven datos 
                    }
                }
                if (_usarCache)
                {
                    Pais? paisBorrar = paisesCache.FirstOrDefault(p => p.PaisId == paisId);
                    if (paisBorrar == null) return;
                    paisesCache.Remove(paisBorrar);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(Pais pais)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE Paises SET NombrePais=@NombrePais
                                    WHERE PaisId=@PaisId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
                        cmd.Parameters.AddWithValue("@PaisId", pais.PaisId);
                        cmd.ExecuteNonQuery();
                    }
                    if (_usarCache)
                    {
                        Pais? paisEditar = paisesCache.FirstOrDefault(p => p.PaisId == pais.PaisId);
                        if (paisEditar == null) return;
                        paisEditar.NombrePais = pais.NombrePais;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro", ex);
            }
        }

        public List<Pais> Filtrar(string textoParaFiltrar)
        {
            var listaFiltrada = new List<Pais>();
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"SELECT * FROM Paises
                                    WHERE NombrePais LIKE @texto";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        textoParaFiltrar += "%";
                        cmd.Parameters.AddWithValue("@texto", textoParaFiltrar);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pais = ConstruirPais(reader);
                                listaFiltrada.Add(pais);
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

        public int GetCantidad()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = @"SELECT COUNT (*) FROM Paises";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
