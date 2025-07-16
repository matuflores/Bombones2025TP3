using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Entidades
{
    public class ProvinciaEstado
    {
        public int ProvinciaEstadoId { get; set; }
        public string NombreProvinciaEstado { get; set; } = null!;

        public int PaisId { get; set; }
        //a traves de esta clave principal puedo acceder al Pais:
        public Pais? Pais { get; set; }//navegacion?

        public ProvinciaEstado? Clonar()
        {
            return new ProvinciaEstado
            {
                ProvinciaEstadoId = ProvinciaEstadoId,
                NombreProvinciaEstado = NombreProvinciaEstado,
                PaisId = PaisId
            };
        }


        //recordatorio, esto hace que eje cuando pongo eliminar y me muestre
        //el mensaje si quiero eliminar tal Provincia salga el nombre y no me
        //salga Bombones2025.Entidades.Prov...
        public override string ToString()
        {
            return $"{NombreProvinciaEstado}";
        }

    }
}
