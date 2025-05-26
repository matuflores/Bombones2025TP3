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
    public partial class FrmPaises : Form
    {
        //llamo a servicios
        private readonly PaisServicio _paisServicio = null!;
        //instancio la lista
        private List<Pais> _paises = new();
        private bool filtrarOn = false;
        public FrmPaises(PaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            _paises = _paisServicio.GetPais();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvPaises.Rows.Clear();
            foreach (Pais pais in _paises)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvPaises);
                SetearFila(r, pais);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvPaises.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[0].Value = pais.PaisId;
            r.Cells[1].Value = pais.NombrePais;

            r.Tag = pais;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Nuevo Pais" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Pais? pais = frm.GetPais();
            if (pais == null) return;
            if (!_paisServicio.Existe(pais))
            {
                _paisServicio.Guardar(pais);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvPaises);
                SetearFila(r, pais);
                AgregarFila(r);
                MessageBox.Show("Pais Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Pais Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvPaises.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvPaises.SelectedRows[0];
            Pais paisBorrar = (Pais)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea Borrar el pais {paisBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _paisServicio.Borrar(paisBorrar.PaisId);
                dgvPaises.Rows.Remove(r);
                MessageBox.Show("Pais Eliminado");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPaises.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvPaises.SelectedRows[0];
            Pais? pais = (Pais)r.Tag!;
            if (pais == null) return;
            Pais? paisEditar = pais.Clonar();
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Editar Pais" };
            frm.SetPais(paisEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            paisEditar = frm.GetPais();
            if (paisEditar == null) return;

            try
            {
                if (!_paisServicio.Existe(paisEditar))
                {
                    _paisServicio.Guardar(paisEditar);
                    SetearFila(r, paisEditar);

                    MessageBox.Show("Pais Modificado", "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Pais Existente", "Error",
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
                FrmFiltrar frm = new FrmFiltrar() { Text = "Filtrar Pais" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _paises = _paisServicio.Filtrar(textoParaFiltrar);
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
                _paises = _paisServicio.GetPais();
                MostrarDatosEnGrilla() ;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            }
        }
    }
}
