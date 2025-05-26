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
    public partial class FrmFrutosSecosAE : Form
    {
        private FrutoSeco? frutoSeco;
        public FrmFrutosSecosAE()
        {
            InitializeComponent();
        }

        public FrutoSeco? GetFrutoSeco()
        {
            return frutoSeco;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (frutoSeco is not null)
            {
                textBoxFrutoSeco.Text = frutoSeco.Descripcion;
            }
        }

        public void SetFrutoSeco(FrutoSeco frutoSeco)
        {
            this.frutoSeco = frutoSeco;
        }
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (frutoSeco == null)
                {
                    frutoSeco = new FrutoSeco();
                }
                frutoSeco.Descripcion = textBoxFrutoSeco.Text;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderFSeco.Clear();
            if (string.IsNullOrEmpty(textBoxFrutoSeco.Text))
            {
                valido = false;
                errorProviderFSeco.SetError(textBoxFrutoSeco, "Nombre de Fruto Seco requerido");
            }
            return valido;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
    }
}
