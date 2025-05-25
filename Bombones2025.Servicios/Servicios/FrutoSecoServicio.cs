using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class FrutoSecoServicio
    {
        private readonly FrutoSecoRepositorio _frutoSecoRepositorio = null!;
        public FrutoSecoServicio()
        {
            _frutoSecoRepositorio = new FrutoSecoRepositorio();
        }
        
        public List<FrutoSeco> GetFrutoSecos()
        {
            return _frutoSecoRepositorio.GetFrutoSeco();
        }
    }
}
