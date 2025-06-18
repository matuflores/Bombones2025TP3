using Bombones2025.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.DatosSql
{
    public class BombonesDbContext : DbContext
    {
        public BombonesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BombonesDbContext()
        {
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Relleno> Rellenos { get; set; }
    }
}
