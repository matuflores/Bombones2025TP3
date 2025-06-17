using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using Bombones2025.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class ChocolateServicio : IChocolateServicio
    {
        private readonly IChocolateRepositorio _chocolateRepositorio = null!;
        public ChocolateServicio(IChocolateRepositorio chocolateRepositorio)
        {
            //_chocolateRepositorio = new ChocolateRepositorio(ConstantesDelSistema.umbralCache);
            _chocolateRepositorio = chocolateRepositorio;
        }

        public List<Chocolate> GetChocolate()
        {
            return _chocolateRepositorio.GetChocolate();
        }


        public bool Existe(Chocolate chocolate)
        {
            return _chocolateRepositorio.Existe(chocolate);
        }
        //public void Guardar(Chocolate chocolate)
        //{
        //    if (chocolate.ChocolateId == 0)
        //    {
        //        _chocolateRepositorio.Agregar(chocolate);
        //    }
        //    else
        //    {
        //        _chocolateRepositorio.Editar(chocolate);
        //    }
        //}
        //public void Borrar(int chocolateId)
        //{
        //    _chocolateRepositorio.Borrar(chocolateId);
        //}

        public List<Chocolate> Filtrar(string textoParaFiltrar)
        {
            return _chocolateRepositorio.Filtrar(textoParaFiltrar);
        }

        public bool Agregar(Chocolate chocolate, out List<string> errores)
        {
            errores = new List<string>();
            if (_chocolateRepositorio.Existe(chocolate))
            {
                errores.Add("Chocolate existente!");
                return false;
            }
            _chocolateRepositorio.Agregar(chocolate);
            return true;
        }

        public bool Editar(Chocolate chocolate, out List<string> errores)
        {
            errores= new List<string>();
            if (_chocolateRepositorio.Existe(chocolate))
            {
                errores.Add("Chocolate existente!"+Environment.NewLine+"Edicion denegada");
                return false;
            }
            _chocolateRepositorio.Editar(chocolate);
            return true;
        }

        public bool Borrar(int chocolateId, out List<string> errores)
        {
            errores = new List<string>();
            _chocolateRepositorio.Borrar(chocolateId);
            return true;
        }
    }
}
