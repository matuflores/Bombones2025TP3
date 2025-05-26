using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Entidades
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; } = null!;

        public override string ToString()
        {
            return $"{NombrePais}";
        }
        //es la copia exacta en un pais Nuevo
        public Pais Clonar()
        {
            return new Pais
            {
                PaisId =PaisId,
                NombrePais = NombrePais
            };
        }
    }
}
