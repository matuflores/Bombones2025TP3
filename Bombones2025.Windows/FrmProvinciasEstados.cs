using Bombones2025.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;
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
    public partial class FrmProvinciasEstados : Form
    {
        private readonly IProvinciaEstadoServicio _provinciaEstadoServicio;
        private readonly IPaisServicio _paisServicio;
        private List<ProvinciaEstado>? _provinciaEstados;
        public FrmProvinciasEstados(IProvinciaEstadoServicio provinciaEstadoServicio, IPaisServicio paisServicio)
        {
            InitializeComponent();
            _provinciaEstadoServicio = provinciaEstadoServicio;
            _paisServicio = paisServicio;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProvinciasEstados_Load(object sender, EventArgs e)
        {
            try
            {
                _provinciaEstados = _provinciaEstadoServicio.GetProvinciaEstado();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvProvEst);
            foreach (ProvinciaEstado provinciaEstado in _provinciaEstados!)
            {
                var r = GridHelper.ConstruirFila(dgvProvEst);

                GridHelper.SetearFila(r, provinciaEstado);
                GridHelper.AgregarFila(r, dgvProvEst);
            }
        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFiltroPorPais frm = new FrmFiltroPorPais(_paisServicio);
            DialogResult dr= frm.ShowDialog(this);
        }
    }
}
