using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using Bombones2025.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio? _paisRepositorio;
        //traido el repo lo llamo en el ctor
        public PaisServicio(IPaisRepositorio paisRepositorio)
        {
            //_paisRepositorio = new PaisRepositorio(ConstantesDelSistema.umbralCache);
            _paisRepositorio=paisRepositorio;
        }

        ////llamo a la lista del repo
        public List<Pais> GetPais(string? textoParaFiltrar=null)
        {
            return _paisRepositorio.GetPais(textoParaFiltrar);
        }//traida lista desarrollo el frmPaises

        public bool Agregar(Pais pais, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.Existe(pais))
            {
                errores.Add("Pais existente!");
                return false;
            }
            _paisRepositorio.Agregar(pais);
            return true;
        }

        public bool Existe(Pais pais)
        {
            return _paisRepositorio.Existe(pais);
        }

        public bool Borrar(int paisId, out List<string> errores)
        {
            errores=new List<string>();
            _paisRepositorio.Borrar(paisId);
            return true;
        }

        public bool Editar(Pais pais, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.Existe(pais))
            {
                errores.Add("Pais Existente!!" + Environment.NewLine + "Edicion denegada");
                return false ;
            }
            _paisRepositorio.Editar(pais);
            return true;
        }

        //public bool Existe(Pais pais)
        //{
        //    return _paisRepositorio.Existe(pais);
        //}
        //public void Guardar(Pais pais)
        //{
        //    if (pais.PaisId == 0)
        //    {
        //        _paisRepositorio.Agregar(pais);
        //    }
        //    else
        //    {
        //        _paisRepositorio.Editar(pais);
        //    }
        //}
        //public void Borrar(int paisId)
        //{
        //    _paisRepositorio.Borrar(paisId);
        //}

        //public List<Pais> Filtrar(string textoParaFiltrar)
        //{
        //    return _paisRepositorio.Filtrar(textoParaFiltrar);
        //}






    }
}
