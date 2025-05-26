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
    public partial class FrmChocolatesAE : Form
    {
        private Chocolate? chocolate;
        public FrmChocolatesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (chocolate is not null)
            {
                textBoxChocolate.Text = chocolate.Descripcion;
            }
        }

        public Chocolate? GetChocolate()
        {
            return chocolate;
        }

        public void SetChocolate(Chocolate chocolate)
        {
            this.chocolate = chocolate;
        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderChocolate.Clear();
            if (string.IsNullOrEmpty(textBoxChocolate.Text))
            {
                valido = false;
                errorProviderChocolate.SetError(textBoxChocolate, "Nombre de Chocolate requerido");
            }
            return valido;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (chocolate == null)
                {
                    chocolate = new Chocolate();
                }
                chocolate.Descripcion = textBoxChocolate.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
