using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.AE;
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
    public partial class FrmChocolates : Form
    {
        private readonly ChocolateServicio _chocolateServicio = null!;
        private List<Chocolate> _chocolates = new();
        private bool filtrarOn = false;
        public FrmChocolates(ChocolateServicio chocolateServicio)
        {
            InitializeComponent();
            _chocolateServicio = chocolateServicio;
        }

        private void FrmChocolates_Load(object sender, EventArgs e)
        {
            _chocolates = _chocolateServicio.GetChocolate();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvChocolates.Rows.Clear();
            foreach (Chocolate chocolate in _chocolates)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvChocolates);
                SetearFila(r, chocolate);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvChocolates.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Chocolate chocolate)
        {
            r.Cells[0].Value = chocolate.ChocolateId;
            r.Cells[1].Value = chocolate.Descripcion;
            r.Tag = chocolate;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Nuevo Chocolate" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Chocolate? chocolate = frm.GetChocolate();
            if (chocolate == null) return;
            if (!_chocolateServicio.Existe(chocolate))
            {
                _chocolateServicio.Guardar(chocolate);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvChocolates);
                SetearFila(r, chocolate);
                AgregarFila(r);
                MessageBox.Show("Chocolate Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chocolate Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvChocolates.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvChocolates.SelectedRows[0];
            Chocolate chocolateBorrar = (Chocolate)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea Borrar el chocolate {chocolateBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _chocolateServicio.Borrar(chocolateBorrar.ChocolateId);
                dgvChocolates.Rows.Remove(r);
                MessageBox.Show("Chocolate Eliminado");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvChocolates.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvChocolates.SelectedRows[0];
            Chocolate? chocolate = (Chocolate)r.Tag!;
            if (chocolate == null) return;
            Chocolate? chocolateEditar = chocolate.Clonar();
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Editar Chocolate" };
            frm.SetChocolate(chocolateEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            chocolateEditar = frm.GetChocolate();
            if (chocolateEditar == null) return;

            try
            {
                if (!_chocolateServicio.Existe(chocolateEditar))
                {
                    _chocolateServicio.Guardar(chocolateEditar);
                    SetearFila(r, chocolateEditar);

                    MessageBox.Show("Chocolate Modificado", "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chocolate Existente", "Error",
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
                FrmFiltrar frm = new FrmFiltrar() { Text = "Filtrar Chocolate" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _chocolates = _chocolateServicio.Filtrar(textoParaFiltrar);
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
                _chocolates = _chocolateServicio.GetChocolate();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
