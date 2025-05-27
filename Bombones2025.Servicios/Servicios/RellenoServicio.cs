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
            _rellenoRepositorio = new RellenoRepositorio(true);
        }

        public void Borrar(int rellenoId)
        {
            _rellenoRepositorio.Borrar(rellenoId);
        }

        public bool Existe(Relleno relleno)
        {
            return _rellenoRepositorio.Existe(relleno);
        }

        public List<Relleno> Filtrar(string textoParaFiltrar)
        {
            return _rellenoRepositorio.Filtrar(textoParaFiltrar);
        }

        public List<Relleno> GetRelleno()
        {
            return _rellenoRepositorio.GetRelleno();
        }

        public void Guardar(Relleno relleno)
        {
            if (relleno.RellenoId == 0)
            {
                _rellenoRepositorio.Agregar(relleno);
            }
            else
            {
                _rellenoRepositorio.Editar(relleno);
            }
        }
    }
}
