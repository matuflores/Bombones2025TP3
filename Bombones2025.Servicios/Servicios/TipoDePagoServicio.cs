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
        private readonly ITipoDePagoRepositorio _tipoDePagoRepositorio = null!;

        public TipoDePagoServicio(ITipoDePagoRepositorio tipoDePagoRepositorio)
        {
            //_tipoDePagoRepositorio = new TipoDePagoRepositorio();
            _tipoDePagoRepositorio=tipoDePagoRepositorio;
        }

        public List<TipoDePago> GetTipoDePago()
        {
            return _tipoDePagoRepositorio.GetTipoDePago();
        }


        public bool Existe(TipoDePago tipoDePago)
        {
            return _tipoDePagoRepositorio.Existe(tipoDePago);
        }
        public void Guardar(TipoDePago tipoDePago)
        {
            if (tipoDePago.FormaDePagoId == 0)
            {
                _tipoDePagoRepositorio.Agregar(tipoDePago);
            }
            else
            {
                _tipoDePagoRepositorio.Editar(tipoDePago);
            }
        }
        public void Borrar(int tipoPagoId)
        {
            _tipoDePagoRepositorio.Borrar(tipoPagoId);
        }

        //public List<TipoDePago> Filtrar(string textoParaFiltrar)
        //{
        //    return _tipoDePagoRepositorio.Filtrar(textoParaFiltrar);
        //}
    }
}
