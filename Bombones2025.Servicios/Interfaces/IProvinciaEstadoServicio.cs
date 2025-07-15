using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IProvinciaEstadoServicio
    {
        ProvinciaEstado? GetById(int provinciaEstadoId);
        List<ProvinciaEstado> GetProvinciaEstado(int? paisId=null,string? textoFiltro=null);
        bool Guardar(ProvinciaEstado provinciaEstado, out List<string>errores);
    }
}
