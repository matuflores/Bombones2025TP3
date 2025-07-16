using Bombones2025.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.AE;
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
                DialogResult dr = frm.ShowDialog(this);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciasEstadosAE frm = new FrmProvinciasEstadosAE(_paisServicio) { Text = "Nueva Provincia/Estado" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            ProvinciaEstado? provinciaEstado = frm.GetProvinciaEstado();
            if (provinciaEstado is null) return;

            try
            {
                if (_provinciaEstadoServicio.Guardar(provinciaEstado, out var errores))//(_provinciaEstadoServicio.Existe(provinciaEstado))
                {
                    ProvinciaEstado? peAgregado = _provinciaEstadoServicio.GetById(provinciaEstado.ProvinciaEstadoId);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvProvEst);
                    GridHelper.SetearFila(r, peAgregado!);
                    GridHelper.AgregarFila(r, dgvProvEst);
                    MessageBox.Show("Provincia/Estado Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errores.First(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProvEst.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvProvEst.SelectedRows[0];
            //ProvinciaEstado? provEstBorrar = (ProvinciaEstado)r.Tag!;
            ProvinciaEstado? provEstBorrar = r.Tag as ProvinciaEstado;
            if (provEstBorrar is null) return;

            DialogResult dr = MessageBox.Show($"¿Desea Borrar la Provincia/Estado {provEstBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No) return;
            try
            {
                if (_provinciaEstadoServicio.Borrar(provEstBorrar.ProvinciaEstadoId, out var errores))
                {
                    GridHelper.QuitarFila(r, dgvProvEst);
                    MessageBox.Show("Provincia/Estado Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProvEst.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvProvEst.SelectedRows[0];
            ProvinciaEstado? provinciaEstado = r.Tag as ProvinciaEstado;//(ProvinciaEstado)r.Tag!;
            if (provinciaEstado == null) return;
            ProvinciaEstado? provEstEdit = provinciaEstado.Clonar();
            if (provinciaEstado is null) return;
            FrmProvinciasEstadosAE frm = new FrmProvinciasEstadosAE(_paisServicio) { Text = "Editar Provincia/Estado" };
            frm.SetProvinciaEstado(provEstEdit!);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            provEstEdit = frm.GetProvinciaEstado();
            if (provEstEdit == null) return;

            try
            {
                if (_provinciaEstadoServicio.Guardar(provEstEdit, out var errores))
                {
                    ProvinciaEstado? provEstEditado = _provinciaEstadoServicio.GetById(provEstEdit.ProvinciaEstadoId);
                    GridHelper.SetearFila(r, provEstEditado!);

                    MessageBox.Show("Provincia/Estado Modificado", "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errores.First(), "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
