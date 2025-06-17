using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Entidades
{
    public class TipoDePago
    {
        public int FormaDePagoId { get; set; }
        public string Descripcion { get; set; } = null!;

        public override string ToString()
        {
            return $"{Descripcion}";
        }
        public TipoDePago Clonar()
        {
            return new TipoDePago
            {
                FormaDePagoId = FormaDePagoId,
                Descripcion = Descripcion
            };
        }
    }
}
