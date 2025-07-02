using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class FrutoSecoRepositorioEF : IFrutoSecoRepositorio
    {
        private readonly BombonesDbContext? _dbContext;

        public FrutoSecoRepositorioEF(BombonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Agregar(FrutoSeco frutoSeco)
        {
            _dbContext.FrutosSecos.Add(frutoSeco);
            _dbContext.SaveChanges();
        }

        public void Borrar(int frutoSecoId)
        {
            var frutoSecoInDB=_dbContext.FrutosSecos.Find(frutoSecoId);
            if (frutoSecoInDB == null) return;
            _dbContext.FrutosSecos.Remove(frutoSecoInDB);
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public void Editar(FrutoSeco frutoSeco)
        {
            var frutoSecoInDb = _dbContext.FrutosSecos.Find(frutoSeco.FrutoSecoId);
            if (frutoSecoInDb == null) return;
            frutoSecoInDb.Descripcion = frutoSeco.Descripcion;
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public bool Existe(FrutoSeco frutoSeco)
        {
            return frutoSeco.FrutoSecoId == 0 ?
                _dbContext.FrutosSecos.Any(fs => fs.Descripcion == frutoSeco.Descripcion)
                : _dbContext.FrutosSecos.Any(fs => fs.Descripcion == frutoSeco.Descripcion
                && fs.FrutoSecoId == frutoSeco.FrutoSecoId);
        }

        public int GetCantidad()
        {
            return _dbContext.FrutosSecos.Count();
        }

        public List<FrutoSeco> GetFrutoSeco(string? textoParaFiltrar = null)
        {
            return textoParaFiltrar is null ?
                _dbContext.FrutosSecos.AsNoTracking().ToList()
                : _dbContext.FrutosSecos.Where(fs => fs.Descripcion
                .StartsWith(textoParaFiltrar)).AsNoTracking().ToList();
        }
    }
}
