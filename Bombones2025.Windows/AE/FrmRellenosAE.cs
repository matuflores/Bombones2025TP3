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

namespace Bombones2025.Windows
{
    public partial class FrmRellenosAE : Form
    {
        private Relleno? relleno;
        public FrmRellenosAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (relleno is not null)
            {
                textBoxRelleno.Text = relleno.Descripcion;
            }
        }
        public Relleno? GetRelleno()
        {
            return relleno;
        }

        public void SetRelleno(Relleno relleno)
        {
            this.relleno = relleno;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (relleno == null)
                {
                    relleno = new Relleno();
                }
                relleno.Descripcion = textBoxRelleno.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderRellenoAE.Clear();
            if (string.IsNullOrEmpty(textBoxRelleno.Text))
            {
                valido = false;
                errorProviderRellenoAE.SetError(textBoxRelleno, "Relleno requerido");
            }
            return valido;
        }
    }
}
