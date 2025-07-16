using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ProvinciaEstadoRepositorioEF:IProvinciaEstadoRepositorio
    {
        private readonly BombonesDbContext _dbContext;

        public ProvinciaEstadoRepositorioEF(BombonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Agregar(ProvinciaEstado provinciaEstado)
        {
            _dbContext.ProvinciasEstados.Add(provinciaEstado);
            _dbContext.SaveChanges();
        }

        public void Borrar(int provinciaEstadoId)
        {
            //PRIMER FORMA DE HACERLO
            //--aca en el get le digo que no este trakeado, trae el obj y si no esta siendo 
            //--trakeado yo le digo remove y como no lo esta siguiendo no sabe que lo tiene que cambiar
            var provEstEnDb = GetById(provinciaEstadoId);
            if (provEstEnDb is not null)
            {
                _dbContext.Entry(provEstEnDb).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }

            //SEGUNDA FORMA DE HACERLO
            //--en el remove tiene que estar siendo trakeado
            //var provEstEnDb = _dbContext.ProvinciasEstados.Find(provinciaEstadoId);
            //if (provEstEnDb is not null)
            //{
            //    _dbContext.ProvinciasEstados.Remove(provEstEnDb);
            //    _dbContext.SaveChanges();
            //}
        }

        public void Editar(ProvinciaEstado provinciaEstado)
        {
            var provEstEnDb=GetById(provinciaEstado.ProvinciaEstadoId);
            if(provEstEnDb is not null)
            {
                //CUANDO QUERIA GUARDAR LA EDICION SALIO UN ERROR QUE SE ME MODIFICABA PERO NO ME 
                //VOLVIA A MOSTRAR LA LISTA! es porque me esta guardando tambien el PAIS!
                provEstEnDb.NombreProvinciaEstado = provinciaEstado.NombreProvinciaEstado;
                provEstEnDb.PaisId=provinciaEstado.PaisId;
                provEstEnDb.Pais = null;//con esto lo anulo y no se guarda!
                _dbContext.Entry(provEstEnDb).State=EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        public bool EstaRelacionado(int provinciaEstadoId)
        {
            //implemento cuando la entidad este relacionado
            return false;
        }

        public bool Existe(ProvinciaEstado provinciaEstado)
        {
            return provinciaEstado.ProvinciaEstadoId == 0
                ? _dbContext.ProvinciasEstados.Any(pe => pe.NombreProvinciaEstado == provinciaEstado.NombreProvinciaEstado)
                : _dbContext.ProvinciasEstados.Any(pe => pe.NombreProvinciaEstado == provinciaEstado.NombreProvinciaEstado
                && pe.ProvinciaEstadoId != provinciaEstado.ProvinciaEstadoId);
        }

        public ProvinciaEstado? GetById(int provinciaEstadoId)
        {
            return _dbContext.ProvinciasEstados
                .Include(pe=>pe.Pais)
                .AsNoTracking()
                .FirstOrDefault(pe => pe.ProvinciaEstadoId == provinciaEstadoId);
        }

        public List<ProvinciaEstado> GetProvinciaEstados(int? paisId = null, string? textoFiltro=null )
        {
            //si viene un paisId tengo que filtrar, IQueryable es una interfaz que me permite ir armando el query por partes
            
            IQueryable<ProvinciaEstado> query = _dbContext.ProvinciasEstados
                .Include(p => p.Pais).AsNoTracking();

            if (paisId.HasValue)
            {
                query = query.Where(p => p.PaisId == paisId.Value);
            }
            if (!string.IsNullOrEmpty(textoFiltro))//si aca no niego "!" al cargar la grilla no me trae ninguna Prov/Est
            {
                query = query.Where(p => p.Pais!.NombrePais.Contains(textoFiltro)||
                p.NombreProvinciaEstado.Contains(textoFiltro));
            }
            return query.ToList();//recien aca ejecuta la consulta

            //return _dbContext.ProvinciasEstados
            //    .Include(p=>p.Pais)//esto hace que pueda acceder al Pais, de aca modifico en el GridHelper
            //    .AsNoTracking()
            //    .ToList();

            //return paisId.HasValue ? query.Where(p => p.PaisId == paisId.Value).ToList():query.ToList();
            //TIENE VALOR EL ID ENTONCES AGARRO ESE VALOR FILTRO Y ARMO LA LISTA, SI NO AGARRO EL QUERY Y EJECUTO LA LISTA

        }
    }
}
