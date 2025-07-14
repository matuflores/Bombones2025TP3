using Bombones2025.Entidades;
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
    public partial class FrmFrutosSecos : Form
    {
        private readonly IFrutoSecoServicio _frutoSecoServicio = null!;

        private List<FrutoSeco> _frutosSecos = new();
        private bool filtrarOn = false;

        public FrmFrutosSecos(IFrutoSecoServicio frutoSecoServicio)
        {
            InitializeComponent();
            _frutoSecoServicio = frutoSecoServicio;
        }

        private void FrmFrutosSecos_Load(object sender, EventArgs e)
        {
            try
            {
                _frutosSecos = _frutoSecoServicio.GetFrutoSeco();
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
            GridHelper.LimpiarGrilla(dgvFrutosSecos);
            foreach (FrutoSeco frutoSeco in _frutosSecos)
            {
                var r = GridHelper.ConstruirFila(dgvFrutosSecos);
                GridHelper.SetearFila(r, frutoSeco);
                GridHelper.AgregarFila(r, dgvFrutosSecos);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmFrutosSecosAE frm = new FrmFrutosSecosAE() { Text = "Nuevo Fruto Seco" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            FrutoSeco? frutoSeco = frm.GetFrutoSeco();
            if (frutoSeco == null) return;
            if (!_frutoSecoServicio.Existe(frutoSeco))
            {
                _frutoSecoServicio.Guardar(frutoSeco);
                DataGridViewRow r = GridHelper.ConstruirFila(dgvFrutosSecos);
                GridHelper.SetearFila(r, frutoSeco);
                GridHelper.AgregarFila(r, dgvFrutosSecos);
                MessageBox.Show("Fruto Seco Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fruto Seco Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvFrutosSecos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvFrutosSecos.SelectedRows[0];
            FrutoSeco frutoSecoBorrar = (FrutoSeco)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea Borrar el Fruto Seco {frutoSecoBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _frutoSecoServicio.Borrar(frutoSecoBorrar.FrutoSecoId);
                GridHelper.QuitarFila(r, dgvFrutosSecos);
                MessageBox.Show("Fruto Seco Eliminado");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFrutosSecos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvFrutosSecos.SelectedRows[0];
            FrutoSeco? frutoSeco = (FrutoSeco)r.Tag!;
            if (frutoSeco == null) return;
            FrutoSeco? frutoSecoEditar = frutoSeco.Clonar();
            FrmFrutosSecosAE frm = new FrmFrutosSecosAE() { Text = "Editar Fruto Seco" };
            frm.SetFrutoSeco(frutoSecoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            frutoSecoEditar = frm.GetFrutoSeco();
            if (frutoSecoEditar == null) return;

            try
            {
                if (!_frutoSecoServicio.Existe(frutoSecoEditar))
                {
                    _frutoSecoServicio.Guardar(frutoSecoEditar);
                    GridHelper.SetearFila(r, frutoSecoEditar);

                    MessageBox.Show("Fruto seco modificado", "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fruto seco existente", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!filtrarOn)
            {
                FrmFiltrar frm = new FrmFiltrar() { Text = "Filtrar Fruto Seco" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _frutosSecos = _frutoSecoServicio.GetFrutoSeco(textoParaFiltrar);
                    MostrarDatosEnGrilla();
                    btnFiltrar.Image = Resources.FILTRO40;
                    filtrarOn = true;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
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
                _frutosSecos = _frutoSecoServicio.GetFrutoSeco();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
