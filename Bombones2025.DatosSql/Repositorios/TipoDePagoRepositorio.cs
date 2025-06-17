using Bombones2025.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bombones2025.DatosSql.Repositorios
{
    public class TipoDePagoRepositorio : ITipoDePagoRepositorio
    {
        private readonly bool _usarCache;
        private List<TipoDePago> tiposDePagosCache = new();
        private readonly string? connectionString;
        public TipoDePagoRepositorio(int umbralCache = 30, bool? usarCache = null)
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            if (usarCache.HasValue && usarCache.Value == true)
            {
                _usarCache = true;
            }
            else
            {
                int cantidadRegistros = GetCantidad();
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
                string query = "SELECT FormaDePagoId, Descripcion FROM FormasDePago";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoDePago tipoDePago = ConstruirFormaDePago(reader);
                            tiposDePagosCache.Add(tipoDePago);
                        }
                    }
                }
            }
        }

        public List<TipoDePago> GetTipoDePago()
        {
            if (_usarCache)
            {
                return tiposDePagosCache;
            }
            List<TipoDePago> lista = new List<TipoDePago>();
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = @"SELECT FormaDePagoId, Descripcion
                                FROM FormasDePago ORDER BY Descripcion";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoDePago tipoDePago = ConstruirFormaDePago(reader);
                            lista.Add(tipoDePago);
                        }
                    }
                }
            }
            return lista;
        }
        private TipoDePago ConstruirFormaDePago(SqlDataReader reader)
        {
            return new TipoDePago
            {
                FormaDePagoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public bool Existe(TipoDePago tipoDePago)
        {
            if (_usarCache)
            {
                return tipoDePago.FormaDePagoId == 0 ? tiposDePagosCache
                    .Any(tp => tp.Descripcion.ToLower() == tipoDePago.Descripcion.ToLower())
                    : tiposDePagosCache.Any(tp => tp.Descripcion.ToLower() == tipoDePago.Descripcion.ToLower()
                    && tp.FormaDePagoId != tipoDePago.FormaDePagoId);
            }
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query;
                    if (tipoDePago.FormaDePagoId == 0)
                    {
                        query = @"SELECT COUNT(*) FROM FormasDePago 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion)";
                    }
                    else
                    {
                        query = @"SELECT COUNT(*) FROM FormasDePago 
                                WHERE LOWER(Descripcion)=LOWER(@Descripcion) AND
                                FormaDePagoId<>@FormaDePagoId";
                    }

                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        if (tipoDePago.FormaDePagoId != 0)
                        {
                            cmd.Parameters.AddWithValue("@FormaDePagoId", tipoDePago.FormaDePagoId);
                        }
                        cmd.Parameters.AddWithValue("@Descripcion", tipoDePago.Descripcion);
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

        public void Agregar(TipoDePago tipoDePago)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO FormasDePago (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY()";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", tipoDePago.Descripcion);
                        int tipoPagoId = (int)(decimal)cmd.ExecuteScalar();
                        tipoDePago.FormaDePagoId = tipoPagoId;
                    }
                }
                if (_usarCache)
                {
                    tiposDePagosCache.Add(tipoDePago);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar el registro", ex);
            }
        }

        public void Borrar(int tipoPagoId)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM FormasDePago WHERE FormaDePagoId=@FormaDePagoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@FormaDePagoId", tipoPagoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (_usarCache)
                {
                    TipoDePago? tipoPagoBorrar = tiposDePagosCache.FirstOrDefault(tp => tp.FormaDePagoId == tipoPagoId);
                    if (tipoPagoBorrar == null) return;
                    tiposDePagosCache.Remove(tipoPagoBorrar);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(TipoDePago tipoDePago)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE FormasDePago SET Descripcion=@Descripcion
                                    WHERE FormaDePagoId=@FormaDePagoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", tipoDePago.Descripcion);
                        cmd.Parameters.AddWithValue("@FormaDePagoId", tipoDePago.FormaDePagoId);
                        cmd.ExecuteNonQuery();
                    }
                    if (_usarCache)
                    {
                        TipoDePago? tipoPagoEditar = tiposDePagosCache.FirstOrDefault(tp => tp.FormaDePagoId == tipoDePago.FormaDePagoId);
                        if (tipoPagoEditar == null) return;
                        tipoPagoEditar.Descripcion = tipoDePago.Descripcion;
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro", ex);
            }
        }

        public List<TipoDePago> Filtrar(string textoParaFiltrar)
        {
            var listaFiltrada = new List<TipoDePago>();
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"SELECT * FROM FormasDePago
                                    WHERE Descripcion LIKE @texto";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        textoParaFiltrar += "%";
                        cmd.Parameters.AddWithValue("@texto", textoParaFiltrar);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tipoDePago = ConstruirFormaDePago(reader);
                                listaFiltrada.Add(tipoDePago);
                            }
                        }
                    }
                }
                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public int GetCantidad()
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = @"SELECT COUNT (*) FROM FormasDePago";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
