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
    public class ChocolateServicio
    {
        private readonly ChocolateRepositorio _chocolateRepositorio = null!;
        public ChocolateServicio()
        {
            _chocolateRepositorio = new ChocolateRepositorio(ConstantesDelSistema.umbralCache);
        }

        public List<Chocolate> GetChocolate()
        {
            return _chocolateRepositorio.GetChocolate();
        }


        public bool Existe(Chocolate chocolate)
        {
            return _chocolateRepositorio.Existe(chocolate);
        }
        public void Guardar(Chocolate chocolate)
        {
            if (chocolate.ChocolateId == 0)
            {
                _chocolateRepositorio.Agregar(chocolate);
            }
            else
            {
                _chocolateRepositorio.Editar(chocolate);
            }
        }
        public void Borrar(int chocolateId)
        {
            _chocolateRepositorio.Borrar(chocolateId);
        }

        public List<Chocolate> Filtrar(string textoParaFiltrar)
        {
            return _chocolateRepositorio.Filtrar(textoParaFiltrar);
        }
    }
}
