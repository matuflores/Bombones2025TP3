using Bombones2025.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;
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
        private bool filtrarOn = false;
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
            if (!filtrarOn)
            {
                FrmFiltroPorPais frm = new FrmFiltroPorPais(_paisServicio);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) return;
                Pais? paisFiltro = frm.GetPais();
                if (paisFiltro is null) return;
                try
                {
                    _provinciaEstados = _provinciaEstadoServicio.GetProvinciaEstado(paisFiltro.PaisId);
                    MostrarDatosEnGrilla();
                    btnFiltrar.Image = Resources.FILTRO40;
                    filtrarOn = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Quitar Filtro", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                filtrarOn = false;
                btnFiltrar.Image = Resources.FILTRO40;
                _provinciaEstados = _provinciaEstadoServicio.GetProvinciaEstado();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!filtrarOn)
            {
                FrmFiltrar frm = new FrmFiltrar() { Text = "Texto para filtrar Provincia/Estado" };
                DialogResult dr=frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) return;
                string? textoFiltro = frm.GetTexto();
                if (textoFiltro is null) return;
                try
                {
                    _provinciaEstados = _provinciaEstadoServicio.GetProvinciaEstado(null, textoFiltro);
                    MostrarDatosEnGrilla();
                    filtrarOn = false;
                    btnFiltrar.Image = Resources.FILTRO40;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Quitar Filtro", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}
