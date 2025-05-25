using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class RellenoServicio
    {
        private readonly RellenoRepositorio _rellenoRepositorio = null!;
        
        public RellenoServicio()
        {
            _rellenoRepositorio = new RellenoRepositorio();
        }
        public List<Relleno> GetRelleno()
        {
            return _rellenoRepositorio.GetRelleno();
        }
    }
}
