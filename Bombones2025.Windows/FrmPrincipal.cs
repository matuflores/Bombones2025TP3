using Bombones2025.Entidades;
using Bombones2025.Infraestructura;
using Bombones2025.Servicios.Servicios;
using Microsoft.Extensions.DependencyInjection;
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
        private Usuario usuario = null!;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            //PaisServicio servicio = new PaisServicio();
            IPaisServicio servicio=AppServices.ServiceProvider!
                .GetRequiredService<IPaisServicio>();
            FrmPaises frm = new FrmPaises(servicio) { Text = "Listado de Paises" };
            frm.ShowDialog();

        }

        private void btnRellenos_Click(object sender, EventArgs e)
        {
            IRellenoServicio servicio = AppServices.ServiceProvider!
                .GetRequiredService<IRellenoServicio>();
            FrmRellenos frm = new FrmRellenos(servicio) { Text = "Listado de Rellenos" };
            frm.ShowDialog();
        }

        private void btnFrutosSecos_Click(object sender, EventArgs e)
        {
            IFrutoSecoServicio servicio =AppServices.ServiceProvider!
                .GetRequiredService<IFrutoSecoServicio>();
            FrmFrutosSecos frm = new FrmFrutosSecos(servicio) { Text = "Listado de Frutos Secos" };
            frm.ShowDialog();
        }

        private void btnChocolates_Click(object sender, EventArgs e)
        {
            IChocolateServicio servicio = AppServices.ServiceProvider!
                .GetRequiredService<IChocolateServicio>();
            FrmChocolates frm = new FrmChocolates(servicio) { Text = "Listado de Chocolates" };
            frm.ShowDialog();
        }

        public void SetUsuario(Usuario usuarioLogueado)
        {
            toolStripUserLogin.Text = usuarioLogueado.Nombre;
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFormasDePagos_Click(object sender, EventArgs e)
        {
            ITipoDePagoServicio servicio = AppServices.ServiceProvider!
                .GetRequiredService<ITipoDePagoServicio>();
            FrmFormasDePago frm = new FrmFormasDePago(servicio) { Text = "Listado de Formas de Pago" };
            frm.ShowDialog();
        }
    }
}
