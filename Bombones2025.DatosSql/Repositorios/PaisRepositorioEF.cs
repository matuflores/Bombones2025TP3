using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class PaisRepositorioEF:IPaisRepositorio
    {
        private readonly BombonesDbContext? _dbContext;//repo trabaja con este contexto de datos

        public PaisRepositorioEF(BombonesDbContext? dbContext)
        {
            _dbContext = dbContext;//todo lo inyecta APPSERVICE
        }

        public void Agregar(Pais pais)
        {
            _dbContext.Paises.Add(pais);
            _dbContext.SaveChanges();//hasta que no pongo esto el db solo guarda en la memoria y no impacta en la BD
        }

        public void Borrar(int paisId)
        {
            var paisInDb = _dbContext.Paises.Find(paisId);
            if (paisInDb == null) return;
            _dbContext.Paises.Remove(paisInDb);
            _dbContext.ChangeTracker.Entries().ToList();
            //_dbContext.Paises.AsNoTracking().ToList();
            _dbContext.SaveChanges();
        }

        public void Editar(Pais pais)
        {
            //_dbContext.Paises.Update(pais);
            var paisInDb = _dbContext.Paises.Find(pais.PaisId);
            if (paisInDb == null) return;
            paisInDb.NombrePais=pais.NombrePais;
            _dbContext.ChangeTracker.Entries().ToList();
            _dbContext.SaveChanges();
        }

        public bool EstaRelacionado(int paisId)
        {//me fijo si hay alguna provincia que tenga el paisId que le paso
            //si esto da verdadero ANY devuelve un bool
            return _dbContext.ProvinciasEstados.Any(pe=>pe.PaisId==paisId);
        }

        public bool Existe(Pais pais)
        {
            return pais.PaisId==0?
                _dbContext.Paises.Any(p=>p.NombrePais==pais.NombrePais)
                :_dbContext.Paises.Any(p=>p.NombrePais==pais.NombrePais
                && p.PaisId==pais.PaisId);
            //if (pais.PaisId==0)
            //{
            //    return _dbContext.Paises.Any(p => p.NombrePais == pais.NombrePais);
            //}
            //return _dbContext.Paises.Any(p => p.NombrePais == pais.NombrePais && p.PaisId==pais.PaisId);
        }

        public int GetCantidad()
        {
            return _dbContext.Paises.Count();
        }

        public List<Pais> GetPais(string? textoParaFiltrar = null)
        {
            //var lista= _dbContext.Paises.ToList();
            //_dbContext.ChangeTracker.Entries();
            //return lista;
            return textoParaFiltrar is null ? 
                _dbContext.Paises.AsNoTracking().ToList()
                : _dbContext.Paises.Where(p => p.NombrePais
                .StartsWith(textoParaFiltrar)).AsNoTracking().ToList();
        }
    }
}
