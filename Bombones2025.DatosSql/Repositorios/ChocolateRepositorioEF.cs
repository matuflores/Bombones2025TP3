using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ChocolateRepositorioEF : IChocolateRepositorio
    {
        private readonly BombonesDbContext? _dbContext;

        public ChocolateRepositorioEF(BombonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Agregar(Chocolate chocolate)
        {
            _dbContext.Chocolates.Add(chocolate);
            _dbContext.SaveChanges();
        }

        public void Borrar(int chocolateId)
        {
            var chocolateInDb=_dbContext.Chocolates.Find(chocolateId);
            if (chocolateInDb == null) return;
            _dbContext.Chocolates.Remove(chocolateInDb);
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges() ;
        }

        public void Editar(Chocolate chocolate)
        {
            var chocolateInDb = _dbContext.Chocolates.Find(chocolate.ChocolateId);
            if(chocolateInDb == null) return;
            chocolateInDb.Descripcion=chocolate.Descripcion;
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges() ;
        }

        public bool Existe(Chocolate chocolate)
        {
            return chocolate.ChocolateId == 0 ?
                _dbContext.Chocolates.Any(c => c.Descripcion == chocolate.Descripcion)
                : _dbContext.Chocolates.Any(c => c.Descripcion == chocolate.Descripcion
                && c.ChocolateId == chocolate.ChocolateId);
        }

        public int GetCantidad()
        {
            return _dbContext.Chocolates.Count();

        }

        public List<Chocolate> GetChocolate(string? textoParaFiltrar = null)
        {
            return textoParaFiltrar is null ?//SI TEXTOPARAFILTRAR HACE 
                _dbContext.Chocolates.AsNoTracking().ToList()//<--- HACE ESTA LINEA SI NO (?)
                : _dbContext.Chocolates.Where(c => c.Descripcion//<--- HACE ESTO
                .StartsWith(textoParaFiltrar)).AsNoTracking().ToList();
        }
    }
}
