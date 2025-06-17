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
    public partial class FrmRellenos : Form
    {
        private readonly IRellenoServicio _rellenoServicio = null!;
        private List<Relleno> _rellenos = new();
        private bool filtrarOn = false;
        public FrmRellenos(IRellenoServicio rellenoServicio)
        {
            InitializeComponent();
            _rellenoServicio = rellenoServicio;
        }

        private void FrmRellenos_Load(object sender, EventArgs e)
        {
            _rellenos = _rellenoServicio.GetRelleno();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvRellenos);
            foreach (Relleno relleno in _rellenos)
            {
                var r = GridHelper.ConstruirFila(dgvRellenos);
                GridHelper.SetearFila(r, relleno);
                GridHelper.AgregarFila(r, dgvRellenos);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRellenosAE frm = new FrmRellenosAE() { Text = "Nuevo Relleno" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Relleno? relleno = frm.GetRelleno();
            if (relleno == null) return;
            if (!_rellenoServicio.Existe(relleno))
            {
                _rellenoServicio.Guardar(relleno);
                DataGridViewRow r = GridHelper.ConstruirFila(dgvRellenos);
                //r.CreateCells(dgvChocolates);
                GridHelper.SetearFila(r, relleno);
                GridHelper.AgregarFila(r, dgvRellenos);

                MessageBox.Show("Relleno Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Relleno Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvRellenos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvRellenos.SelectedRows[0];
            Relleno rellenoBorrar = (Relleno)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea Borrar el relleno {rellenoBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _rellenoServicio.Borrar(rellenoBorrar.RellenoId);
                GridHelper.QuitarFila(r, dgvRellenos);
                MessageBox.Show("Relleno Eliminado");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRellenos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvRellenos.SelectedRows[0];
            Relleno? relleno = (Relleno)r.Tag!;
            if (relleno == null) return;
            Relleno? rellenoEditar = relleno.Clonar();
            FrmRellenosAE frm = new FrmRellenosAE() { Text = "Editar Relleno" };
            frm.SetRelleno(rellenoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            rellenoEditar = frm.GetRelleno();
            if (rellenoEditar == null) return;

            try
            {
                if (!_rellenoServicio.Existe(rellenoEditar))
                {
                    _rellenoServicio.Guardar(rellenoEditar);
                    GridHelper.SetearFila(r, rellenoEditar);

                    MessageBox.Show("Relleno Modificado", "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Relleno Existente", "Error",
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
                FrmFiltrar frm = new FrmFiltrar() { Text = "Filtrar Relleno" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _rellenos = _rellenoServicio.Filtrar(textoParaFiltrar);
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
                _rellenos = _rellenoServicio.GetRelleno();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
