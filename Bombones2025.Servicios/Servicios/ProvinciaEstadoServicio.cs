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
        public List<ProvinciaEstado> GetProvinciaEstado()
        {
            return _provinciaEstadoRepositorio.GetProvinciaEstados();
        }
    }
}
