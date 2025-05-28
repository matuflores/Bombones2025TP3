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
        private readonly bool _usarCache;
        private List<Chocolate> chocolatesCache = new();
        private readonly string? connectionString;
        public ChocolateRepositorio(int umbralCache=30,bool? usarCache=null)
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            if (usarCache.HasValue && usarCache.Value == true)
            {
                _usarCache = true;
            }
            else 
            {
                int cantidadRegistros = ObtenerCantidadRegistros();
                _usarCache = cantidadRegistros <= umbralCache;
            }
            if (_usarCache)
            {
                LeerDatos();
            }            
        }

        private int ObtenerCantidadRegistros()
        {
            using (var cnn=new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = @"SELECT COUNT (*) FROM Chocolates";
                using (var cmd=new SqlCommand(query,cnn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
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
                            chocolatesCache.Add(chocolate);
                        }
                    }
                }
            }
        }

        //public void RecargarCache()
        //{
        //    chocolatesCache.Clear();
        //    LeerDatos();
        //}
        public List<Chocolate> GetChocolate()
        {
            if (_usarCache)
            {
                return chocolatesCache;
            }
            List<Chocolate>lista = new List<Chocolate>();
            using (var cnn=new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = @"SELECT ChocolateId, Descripcion
                                FROM Chocolates ORDER BY Descripcion";
                using (var cmd=new SqlCommand(query,cnn))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Chocolate chocolate = ConstruirChocolate(reader);
                            lista.Add(chocolate);
                        }
                    }
                }
            }
            return lista;
        }
        private Chocolate ConstruirChocolate(SqlDataReader reader)
        {
            return new Chocolate
            {
                ChocolateId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public bool Existe(Chocolate chocolate)
        {
            if (_usarCache)//si es verdadero
            {//me fijo si el chocolate es nuevo, me fijo si tengo en el cache uno igaul, de caso contrario. Si hay uno con mismo nombre pero distinto ID
                return chocolate.ChocolateId==0?chocolatesCache
                    .Any(c=>c.Descripcion.ToLower()==chocolate.Descripcion.ToLower())
                    :chocolatesCache.Any(c=>c.Descripcion.ToLower() == chocolate.Descripcion.ToLower()
                    && c.ChocolateId!=chocolate.ChocolateId);
            } 
            try//si no uso cache en memoria lo impacto en la base de datos
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query;
                    if (chocolate.ChocolateId == 0)
                    {
                        query = @"SELECT COUNT(*) FROM Chocolates 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion)";
                    }
                    else
                    {
                        query = @"SELECT COUNT(*) FROM Chocolates 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion) AND
                                ChocolateId<>@ChocolateId";
                    }

                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        if (chocolate.ChocolateId != 0)
                        {
                            cmd.Parameters.AddWithValue("@ChocolateId", chocolate.ChocolateId);
                        }
                        cmd.Parameters.AddWithValue("@Descripcion", chocolate.Descripcion);
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

        public void Agregar(Chocolate chocolate)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO Chocolates (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY()";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", chocolate.Descripcion);
                        int chocolateId = (int)(decimal)cmd.ExecuteScalar();
                        chocolate.ChocolateId = chocolateId;
                    }
                }
                if (_usarCache)
                {
                    chocolatesCache.Add(chocolate);
                    //RecargarCache();
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar el registro", ex);
            }
        }

        public void Borrar(int chocolateId)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Chocolates WHERE ChocolateId=@ChocolateId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@ChocolateId", chocolateId);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (_usarCache)
                {
                    Chocolate? chocolateBorrar = chocolatesCache.FirstOrDefault(c => c.ChocolateId == chocolateId);
                    if (chocolateBorrar == null) return;
                    chocolatesCache.Remove(chocolateBorrar);
                    //RecargarCache();
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(Chocolate chocolate)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE Chocolates SET Descripcion=@Descripcion
                                    WHERE ChocolateId=@ChocolateId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", chocolate.Descripcion);
                        cmd.Parameters.AddWithValue("@ChocolateId", chocolate.ChocolateId);
                        cmd.ExecuteNonQuery();
                    }
                    if (_usarCache)
                    {
                        Chocolate? chocolateEditar = chocolatesCache.FirstOrDefault(c => c.ChocolateId == chocolate.ChocolateId);
                        if (chocolateEditar == null) return;
                        chocolateEditar.Descripcion = chocolate.Descripcion;
                        //RecargarCache();
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro", ex);
            }
        }

        public List<Chocolate> Filtrar(string textoParaFiltrar)
        {
            //if (_usarCache)
            //{
            //    return chocolatesCache.Where(c => c.Descripcion.
            //                            StartsWith(textoParaFiltrar)).ToList();
            //}
            var listaFiltrada = new List<Chocolate>();
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"SELECT * FROM Chocolates
                                    WHERE Descripcion LIKE @texto";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        textoParaFiltrar += "%";
                        cmd.Parameters.AddWithValue("@texto", textoParaFiltrar);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var chocolate = ConstruirChocolate(reader);
                                listaFiltrada.Add(chocolate);
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
