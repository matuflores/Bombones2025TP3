using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarComboPaises(ref ComboBox cbo, IPaisServicio paisServicio)
        {
            var listaPaises = paisServicio.GetPais();
            var defaultPais = new Pais
            {
                PaisId = 0,
                NombrePais = "Selecione Pais"
            };
            cbo.DataSource = listaPaises;
            cbo.DisplayMember = "NombrePais";
            cbo.ValueMember = "PaisId";
            cbo.SelectedIndex = 0;
        }
    }
}
