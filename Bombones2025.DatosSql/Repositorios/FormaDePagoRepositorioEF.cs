using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class FormaDePagoRepositorioEF : ITipoDePagoRepositorio
    {
        private readonly BombonesDbContext? _dbContext;

        public FormaDePagoRepositorioEF(BombonesDbContext? dbContext)
        {
            _dbContext = dbContext;
        }


        public int GetCantidad()
        {
            return _dbContext.FormasDePago.Count();
        }
        public void Agregar(FormaDePago formaDePago)
        {
            _dbContext.FormasDePago.Add(formaDePago);
            _dbContext.SaveChanges();
        }

        public void Borrar(int tipoPagoId)
        {
            var tipoPagoInDb = _dbContext.FormasDePago.Find(tipoPagoId);
            if (tipoPagoInDb == null) return;
            _dbContext.FormasDePago.Remove(tipoPagoInDb);
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public void Editar(FormaDePago formaDePago)
        {
            var tipoPagoInDb = _dbContext.FormasDePago.Find(formaDePago.FormaDePagoId);
            if (tipoPagoInDb == null) return;
            tipoPagoInDb.Descripcion = formaDePago.Descripcion;
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public bool Existe(FormaDePago formaDePago)
        {
            return formaDePago.FormaDePagoId == 0 ?
                _dbContext.FormasDePago.Any(tp => tp.Descripcion == formaDePago.Descripcion)
                : _dbContext.FormasDePago.Any(tp => tp.Descripcion == formaDePago.Descripcion
                && tp.FormaDePagoId == formaDePago.FormaDePagoId);
        }


        public List<FormaDePago> GetTipoDePago(string? textoParaFiltrar = null)
        {
            return textoParaFiltrar is null ?
                _dbContext.FormasDePago.AsNoTracking().ToList()
                : _dbContext.FormasDePago.Where(tp => tp.Descripcion
                .StartsWith(textoParaFiltrar)).AsNoTracking().ToList();
        }
    }
}
