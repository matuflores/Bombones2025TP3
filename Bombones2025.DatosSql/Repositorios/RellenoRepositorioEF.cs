using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class RellenoRepositorioEF:IRellenoRepositorio
    {
        private readonly BombonesDbContext? _dbContext;

        public RellenoRepositorioEF(BombonesDbContext? dbContext)
        {
            _dbContext = dbContext;
        }

        public void Agregar(Relleno relleno)
        {
            _dbContext.Rellenos.Add(relleno);
            _dbContext.SaveChanges();
        }

        public void Borrar(int rellenoId)
        {
            var rellenoInDb = _dbContext.Rellenos.Find(rellenoId);
            if (rellenoInDb == null) return;
            _dbContext.Rellenos.Remove(rellenoInDb);
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public void Editar(Relleno relleno)
        {
            //_dbContext.Paises.Update(pais);
            var relleInDb = _dbContext.Rellenos.Find(relleno.RellenoId);
            if (relleInDb == null) return;
            relleInDb.Descripcion = relleno.Descripcion;
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public bool Existe(Relleno relleno)
        {
            return relleno.RellenoId == 0 ?
                _dbContext.Rellenos.Any(r => r.Descripcion == relleno.Descripcion)
                : _dbContext.Rellenos.Any(r => r.Descripcion == relleno.Descripcion
                && r.RellenoId == relleno.RellenoId);
            
        }

        public int GetCantidad()
        {
            return _dbContext.Rellenos.Count();
        }

        public List<Relleno> GetRelleno(string? textoParaFiltrar = null)
        {
            
            return textoParaFiltrar is null ?
                _dbContext.Rellenos.AsNoTracking().ToList()
                : _dbContext.Rellenos.Where(r => r.Descripcion
                .StartsWith(textoParaFiltrar)).AsNoTracking().ToList();
        }
    }
}
