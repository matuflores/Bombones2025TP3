using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
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
        private readonly FrutoSecoServicio _frutoSecoServicio = null!;

        private List<FrutoSeco> _frutosSecos = new();
        private bool filtrarOn = false;

        public FrmFrutosSecos(FrutoSecoServicio frutoSecoServicio)
        {
            InitializeComponent();
            _frutoSecoServicio = frutoSecoServicio;
        }

        private void FrmFrutosSecos_Load(object sender, EventArgs e)
        {
            _frutosSecos = _frutoSecoServicio.GetFrutoSecos();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvFrutosSecos.Rows.Clear();
            foreach (FrutoSeco frutoSeco in _frutosSecos)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvFrutosSecos);
                SetearFila(r, frutoSeco);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvFrutosSecos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, FrutoSeco frutoSeco)
        {
            r.Cells[0].Value = frutoSeco.FrutoSecoId;
            r.Cells[1].Value = frutoSeco.Descripcion;

            r.Tag = frutoSeco;
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
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvFrutosSecos);
                SetearFila(r, frutoSeco);
                AgregarFila(r);
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
                dgvFrutosSecos.Rows.Remove(r);
                MessageBox.Show("Pais Eliminado");
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
                    SetearFila(r, frutoSecoEditar);

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
                    _frutosSecos = _frutoSecoServicio.Filtrar(textoParaFiltrar);
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
                _frutosSecos = _frutoSecoServicio.GetFrutoSecos();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
