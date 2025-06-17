using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones2025.Windows.AE
{
    public partial class FrmFormasDePagoAE : Form
    {
        public FrmFormasDePagoAE()
        {
            InitializeComponent();
        }
        private TipoDePago? tipoDePago;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDePago is not null)
            {
                textBoxFormaPago.Text = tipoDePago.Descripcion;
            }
        }

        public TipoDePago? GetTipoDePago()
        {
            return tipoDePago;
        }

        public void SetTipoDePago(TipoDePago tipoPago)
        {
            this.tipoDePago = tipoPago;
        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderFormaDePago.Clear();
            if (string.IsNullOrEmpty(textBoxFormaPago.Text))
            {
                valido = false;
                errorProviderFormaDePago.SetError(textBoxFormaPago, "Tipo de Pago requerido");
            }
            return valido;
        }


        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDePago == null)
                {
                    tipoDePago = new TipoDePago();
                }
                tipoDePago.Descripcion = textBoxFormaPago.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
