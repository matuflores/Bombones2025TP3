using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones2025.Windows
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            PaisServicio servicio = new PaisServicio();
            FrmPaises frm = new FrmPaises(servicio) { Text = "Listado de Paises" };
            frm.ShowDialog();

        }

        private void btnRellenos_Click(object sender, EventArgs e)
        {
            RellenoServicio servicio = new RellenoServicio();
            FrmRellenos frm = new FrmRellenos(servicio) { Text = "Listado de Rellenos" };
            frm.ShowDialog();
        }
    }
}
