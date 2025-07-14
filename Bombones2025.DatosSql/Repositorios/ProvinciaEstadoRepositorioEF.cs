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

        public List<ProvinciaEstado> GetProvinciaEstados()
        {
            return _dbContext.ProvinciasEstados
                .Include(p=>p.Pais)//esto hace que pueda acceder al Pais, de aca modifico en el GridHelper
                .AsNoTracking()
                .ToList();

        }
    }
}
