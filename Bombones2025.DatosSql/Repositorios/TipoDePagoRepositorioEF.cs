using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class TipoDePagoRepositorioEF : ITipoDePagoRepositorio
    {
        private readonly BombonesDbContext? _dbContext;//repo trabaja con este contexto de datos

        public TipoDePagoRepositorioEF(BombonesDbContext? dbContext)
        {
            _dbContext = dbContext;
        }


        public int GetCantidad()
        {
            return _dbContext.TipoDePagos.Count();
        }
        public void Agregar(TipoDePago tipoDePago)
        {
            _dbContext.TipoDePagos.Add(tipoDePago);
            _dbContext.SaveChanges();
        }

        public void Borrar(int tipoPagoId)
        {
            var tipoPagoInDb = _dbContext.TipoDePagos.Find(tipoPagoId);
            if (tipoPagoInDb == null) return;
            _dbContext.TipoDePagos.Remove(tipoPagoInDb);
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public void Editar(TipoDePago tipoDePago)
        {
            var tipoPagoInDb = _dbContext.TipoDePagos.Find(tipoDePago.FormaDePagoId);
            if (tipoPagoInDb == null) return;
            tipoPagoInDb.Descripcion = tipoDePago.Descripcion;
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public bool Existe(TipoDePago tipoDePago)
        {
            return tipoDePago.FormaDePagoId == 0 ?
                _dbContext.TipoDePagos.Any(tp => tp.Descripcion == tipoDePago.Descripcion)
                : _dbContext.TipoDePagos.Any(tp => tp.Descripcion == tipoDePago.Descripcion
                && tp.FormaDePagoId == tipoDePago.FormaDePagoId);
        }


        public List<TipoDePago> GetTipoDePago(string? textoParaFiltrar = null)
        {
            return textoParaFiltrar is null ?
                _dbContext.TipoDePagos.AsNoTracking().ToList()
                : _dbContext.TipoDePagos.Where(tp => tp.Descripcion
                .StartsWith(textoParaFiltrar)).AsNoTracking().ToList();
        }
    }
}
