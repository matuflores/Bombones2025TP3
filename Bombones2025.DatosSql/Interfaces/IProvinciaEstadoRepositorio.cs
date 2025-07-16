using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IProvinciaEstadoRepositorio
    {
        List<ProvinciaEstado> GetProvinciaEstados(int? paisId=null, string? textoFiltro=null);
        void Agregar(ProvinciaEstado provinciaEstado);
        ProvinciaEstado? GetById(int provinciaEstadoId);
        bool Existe(ProvinciaEstado provinciaEstado);
        bool EstaRelacionado(int provinciaEstadoId);
        void Borrar(int provinciaEstadoId);
        void Editar(ProvinciaEstado provinciaEstado);
    }
}
