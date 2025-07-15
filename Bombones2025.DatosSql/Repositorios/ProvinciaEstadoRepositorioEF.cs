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
