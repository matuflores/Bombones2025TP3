using Bombones2025.Entidades;
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
    public partial class FrmFormasDePago : Form
    {

        private readonly TipoDePagoServicio _tipoDePagoServicio = null!;
        private List<TipoDePago> _tiposDePago = new();
        private bool filtrarOn = false;
        public FrmFormasDePago(TipoDePagoServicio tipoDePagoServicio)
        {
            InitializeComponent();
            _tipoDePagoServicio = tipoDePagoServicio;
        }
        
        private void FrmFormasDePago_Load(object sender, EventArgs e)
        {
            _tiposDePago = _tipoDePagoServicio.GetTipoDePago();
            MostrarDatosEnGrilla();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvFormasDePago);
            foreach (TipoDePago tipoDePago in _tiposDePago)
            {
                var r = GridHelper.ConstruirFila(dgvFormasDePago);

                GridHelper.SetearFila(r, tipoDePago);
                GridHelper.AgregarFila(r, dgvFormasDePago);
            }
            //dgvFormasDePago.Rows.Clear();
            //foreach (TipoDePago tipoDePago in _tiposDePago)
            //{

            //    DataGridViewRow r = new DataGridViewRow();
            //    r.CreateCells(dgvFormasDePago);
            //    SetearFila(r, tipoDePago);
            //    AgregarFila(r);
            //}
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvFormasDePago.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDePago tipoDePago)
        {
            r.Cells[0].Value = tipoDePago.FormaDePagoId;
            r.Cells[1].Value = tipoDePago.Descripcion;
            r.Tag = tipoDePago;
        }


        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            FrmFormasDePagoAE frm = new FrmFormasDePagoAE() { Text = "Nueva Forma de Pago" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            TipoDePago? tipoDePago = frm.GetTipoDePago();
            if (tipoDePago == null) return;
            if (!_tipoDePagoServicio.Existe(tipoDePago))
            {
                _tipoDePagoServicio.Guardar(tipoDePago);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvFormasDePago);
                SetearFila(r, tipoDePago);
                AgregarFila(r);

                MessageBox.Show("Tipo de Pago Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tipo de Pago Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (dgvFormasDePago.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvFormasDePago.SelectedRows[0];
            TipoDePago tipoDePagoBorrar = (TipoDePago)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea Borrar el tipo de pago {tipoDePagoBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _tipoDePagoServicio.Borrar(tipoDePagoBorrar.FormaDePagoId);
                dgvFormasDePago.Rows.Remove(r);
                MessageBox.Show("Tipo de Pago Eliminado");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvFormasDePago.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvFormasDePago.SelectedRows[0];
            TipoDePago? tipoDePago = (TipoDePago)r.Tag!;
            if (tipoDePago == null) return;
            TipoDePago? tipoPagoEditar = tipoDePago.Clonar();
            FrmFormasDePagoAE frm = new FrmFormasDePagoAE() { Text = "Editar Tipo de Pago" };
            frm.SetTipoDePago(tipoPagoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            tipoPagoEditar = frm.GetTipoDePago();
            if (tipoPagoEditar == null) return;

            try
            {
                if (!_tipoDePagoServicio.Existe(tipoPagoEditar))
                {
                    _tipoDePagoServicio.Guardar(tipoPagoEditar);
                    SetearFila(r, tipoPagoEditar);

                    MessageBox.Show("Tipo de Pago Modificado", "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tipo de Pago Existente", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            if (!filtrarOn)
            {
                FrmFiltrar frm = new FrmFiltrar() { Text = "Filtrar Tipo de Pago" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _tiposDePago = _tipoDePagoServicio.Filtrar(textoParaFiltrar);
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {
                filtrarOn = false;
                btnFiltrar.Image = Resources.FILTRO40;
                _tiposDePago = _tipoDePagoServicio.GetTipoDePago();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        
    }
}
