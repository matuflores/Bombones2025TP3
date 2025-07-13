using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class TipoDePagoServicio : ITipoDePagoServicio
    {
        private readonly ITipoDePagoRepositorio? _tipoDePagoRepositorio=null!;
        public TipoDePagoServicio(ITipoDePagoRepositorio tipoDePagoRepositorio)
        {
            _tipoDePagoRepositorio = tipoDePagoRepositorio;
        }

        

        public bool Agregar(FormaDePago tipoDePago, out List<string> errores)
        {
            errores = new List<string>();
            if (_tipoDePagoRepositorio.Existe(tipoDePago))
            {
                errores.Add("Tipo de pago existente!");
                return false;
            }
            _tipoDePagoRepositorio.Agregar(tipoDePago);
            return true;
        }

        public bool Existe(FormaDePago tipoDePago)
        {
            return _tipoDePagoRepositorio.Existe(tipoDePago);
        }

        public bool Borrar(int formaDePagoId, out List<string> errores)
        {
            errores = new List<string>();
            _tipoDePagoRepositorio.Borrar(formaDePagoId);
            return true;
        }

        public bool Editar(FormaDePago tipoDePago, out List<string> errores)
        {
            errores = new List<string>();
            if (_tipoDePagoRepositorio.Existe(tipoDePago))
            {
                errores.Add("Tipo de pago Existente!!" + Environment.NewLine + "Edicion denegada");
                return false;
            }
            _tipoDePagoRepositorio.Editar(tipoDePago);
            return true;
        }


        public List<FormaDePago> GetTipoDePago(string? textoParaFiltrar = null)
        {
            return _tipoDePagoRepositorio.GetTipoDePago(textoParaFiltrar);
        }
    }
}
