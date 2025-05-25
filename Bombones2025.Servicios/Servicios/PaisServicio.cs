using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio
    {
        private readonly PaisRepositorio _paisRepositorio = null!;
        //traido el repo lo llamo en el ctor
        public PaisServicio()
        {
            _paisRepositorio=new PaisRepositorio();
        }
        //llamo a la lista del repo
        public List<Pais> GetPais()
        {
            return _paisRepositorio.GetPais();
        }//traida lista desarrollo el frmPaises
    }
}
