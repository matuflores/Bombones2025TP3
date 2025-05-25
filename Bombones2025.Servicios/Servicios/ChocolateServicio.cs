using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class ChocolateServicio
    {
        private readonly ChocolateRepositorio _chocolateRepositorio = null!;
        public ChocolateServicio()
        {
            _chocolateRepositorio = new ChocolateRepositorio();
        }

        public List<Chocolate> GetChocolate()
        {
            return _chocolateRepositorio.GetChocolate();
        }
    }
}
