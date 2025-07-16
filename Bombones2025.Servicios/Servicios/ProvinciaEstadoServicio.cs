using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades;
using Bombones2025.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class ProvinciaEstadoServicio : IProvinciaEstadoServicio
    {
        private readonly IProvinciaEstadoRepositorio _provinciaEstadoRepositorio;

        public ProvinciaEstadoServicio(IProvinciaEstadoRepositorio provinciaEstadoRepositorio)
        {
            _provinciaEstadoRepositorio = provinciaEstadoRepositorio;
        }

        public bool Borrar(int provinciaEstadoId, out List<string> errores)
        {
            errores=new List<string>();
            if (_provinciaEstadoRepositorio.EstaRelacionado(provinciaEstadoId))
            {
                errores.Add("Registro relacionado, no es posible borrar");
                return false;
            }
            _provinciaEstadoRepositorio.Borrar(provinciaEstadoId);
            return true;
        }

        public ProvinciaEstado? GetById(int provinciaEstadoId)
        {
            return _provinciaEstadoRepositorio.GetById(provinciaEstadoId);
        }

        public List<ProvinciaEstado> GetProvinciaEstado(int? paisId = null, string? textoFiltro = null)
        {
            return _provinciaEstadoRepositorio.GetProvinciaEstados(paisId,textoFiltro);
        }

        public bool Guardar(ProvinciaEstado provinciaEstado, out List<string> errores)
        {
            errores=new List<string>();
            if (_provinciaEstadoRepositorio.Existe(provinciaEstado))
            {
                errores.Add("Provincia/Estado existente");
                return false;
            }
            if (provinciaEstado.ProvinciaEstadoId==0)
            {
                _provinciaEstadoRepositorio.Agregar(provinciaEstado);
                return true;
            }
            _provinciaEstadoRepositorio.Editar(provinciaEstado);
            return true;
        }
    }
}
