using Bombones2025.DatosSql.Repositorios;
using Bombones2025.DatosSql.RepositoriosSINUSO;
using Bombones2025.Entidades;
using Bombones2025.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class RellenoServicio : IRellenoServicio
    {
        private readonly IRellenoRepositorio? _rellenoRepositorio;

        public RellenoServicio(IRellenoRepositorio rellenoRepositorio)
        {
            _rellenoRepositorio=rellenoRepositorio;
        }

        public bool Agregar(Relleno relleno, out List<string> errores)
        {
            errores = new List<string>();
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("Relleno existente!");
                return false;
            }
            _rellenoRepositorio.Agregar(relleno);
            return true;
        }

        public bool Borrar(int rellenoId, out List<string> errores)
        {
            errores = new List<string>();
            _rellenoRepositorio.Borrar(rellenoId);
            return true;
        }

        public bool Editar(Relleno relleno, out List<string> errores)
        {
            errores = new List<string>();
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("Relleno Existente!!" + Environment.NewLine + "Edicion denegada");
                return false;
            }
            _rellenoRepositorio.Editar(relleno);
            return true;
        }

        public bool Existe(Relleno relleno)
        {
            return _rellenoRepositorio.Existe(relleno);
        }

        public List<Relleno> GetRelleno(string? textoParaFiltrar = null)
        {
            return _rellenoRepositorio.GetRelleno(textoParaFiltrar);
        }

        //public void Borrar(int rellenoId)
        //{
        //    _rellenoRepositorio.Borrar(rellenoId);
        //}

        //public bool Existe(Relleno relleno)
        //{
        //    return _rellenoRepositorio.Existe(relleno);
        //}

        //public List<Relleno> Filtrar(string textoParaFiltrar)
        //{
        //    return _rellenoRepositorio.Filtrar(textoParaFiltrar);
        //}

        //public List<Relleno> GetRelleno()
        //{
        //    return _rellenoRepositorio.GetRelleno();
        //}

        //public void Guardar(Relleno relleno)
        //{
        //    if (relleno.RellenoId == 0)
        //    {
        //        _rellenoRepositorio.Agregar(relleno);
        //    }
        //    else
        //    {
        //        _rellenoRepositorio.Editar(relleno);
        //    }
        //}
    }
}
