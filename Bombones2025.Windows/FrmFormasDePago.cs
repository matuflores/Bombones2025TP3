using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.AE;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;

namespace Bombones2025.Windows
{
    public partial class FrmFormasDePago : Form
    {

        private readonly ITipoDePagoServicio _tipoDePagoServicio = null!;
        private List<FormaDePago> _tiposDePago = new();
        private bool filtrarOn = false;
        public FrmFormasDePago(ITipoDePagoServicio tipoDePagoServicio)
        {
            InitializeComponent();
            _tipoDePagoServicio = tipoDePagoServicio;
        }

        private void FrmFormasDePago_Load(object sender, EventArgs e)
        {
            try
            {
                _tiposDePago = _tipoDePagoServicio.GetTipoDePago();
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
            GridHelper.LimpiarGrilla(dgvFormasDePago);
            foreach (FormaDePago tipoDePago in _tiposDePago)
            {
                var r = GridHelper.ConstruirFila(dgvFormasDePago);

                GridHelper.SetearFila(r, tipoDePago);
                GridHelper.AgregarFila(r, dgvFormasDePago);
            }
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
            FormaDePago? tipoDePago = frm.GetTipoDePago();
            if (tipoDePago == null) return;
            try
            {
                if (_tipoDePagoServicio.Agregar(tipoDePago, out var errores))
                {

                    DataGridViewRow r = GridHelper.ConstruirFila(dgvFormasDePago);
                    GridHelper.SetearFila(r, tipoDePago);
                    GridHelper.AgregarFila(r, dgvFormasDePago);
                    MessageBox.Show("Forma de pago Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errores.First(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (dgvFormasDePago.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvFormasDePago.SelectedRows[0];
            FormaDePago tipoDePagoBorrar = (FormaDePago)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea Borrar la forma de pago {tipoDePagoBorrar}",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (_tipoDePagoServicio.Borrar(tipoDePagoBorrar.FormaDePagoId, out var errores))
                {
                    GridHelper.QuitarFila(r, dgvFormasDePago);
                    MessageBox.Show("Forma de pago Eliminado");
                }
                else
                {
                    MessageBox.Show(errores.First(), "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
            FormaDePago? tipoDePago = (FormaDePago)r.Tag!;
            if (tipoDePago == null) return;
            FormaDePago? tipoDePagoEdit = tipoDePago.Clonar();
            FrmFormasDePagoAE frm = new FrmFormasDePagoAE() { Text = "Editar Forma de Pago" };
            frm.SetTipoDePago(tipoDePagoEdit);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            tipoDePagoEdit = frm.GetTipoDePago();
            if (tipoDePagoEdit == null) return;

            try
            {
                if (_tipoDePagoServicio.Editar(tipoDePagoEdit, out var errores))
                {
                    GridHelper.SetearFila(r, tipoDePagoEdit);

                    MessageBox.Show("Tipo de pago Modificado", "Mensaje",
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
                    _tiposDePago = _tipoDePagoServicio.GetTipoDePago(textoParaFiltrar);
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
