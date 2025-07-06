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
    public class FrutoSecoServicio : IFrutoSecoServicio
    {
        private readonly IFrutoSecoRepositorio _frutoSecoRepositorio = null!;
        public FrutoSecoServicio(IFrutoSecoRepositorio frutoSecoRepositorio)
        {
            //_frutoSecoRepositorio = new FrutoSecoRepositorio(ConstantesDelSistema.umbralCache);
            _frutoSecoRepositorio=frutoSecoRepositorio;
        }

        public List<FrutoSeco> GetFrutoSecos()
        {
            return _frutoSecoRepositorio.GetFrutoSeco();
        }


        public bool Existe(FrutoSeco frutoSeco)
        {
            return _frutoSecoRepositorio.Existe(frutoSeco);
        }
        public void Guardar(FrutoSeco frutoseco)
        {
            if (frutoseco.FrutoSecoId == 0)
            {
                _frutoSecoRepositorio.Agregar(frutoseco);
            }
            else
            {
                _frutoSecoRepositorio.Editar(frutoseco);
            }
        }
        public void Borrar(int frutoSecoId)
        {
            _frutoSecoRepositorio.Borrar(frutoSecoId);
        }

        //public List<FrutoSeco> Filtrar(string textoParaFiltrar)
        //{
        //    return _frutoSecoRepositorio.Filtrar(textoParaFiltrar);
        //}

        public List<FrutoSeco> GetFrutoSeco(string? textoParaFiltrar = null)
        {
            return _frutoSecoRepositorio.GetFrutoSeco(textoParaFiltrar);
        }
    }
}
