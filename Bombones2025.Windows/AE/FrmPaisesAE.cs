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
    public partial class FrmPaisesAE : Form
    {
        private Pais? pais;

        public FrmPaisesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais is not null)
            {
                textBoxPais.Text = pais.NombrePais;
            }
        }

        public Pais? GetPais()
        {
            return pais;
        }

        public void SetPais(Pais pais)
        {
            this.pais = pais;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                {
                    pais = new Pais();
                }

                pais.NombrePais = textBoxPais.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderPaisAe.Clear();
            if (string.IsNullOrEmpty(textBoxPais.Text))
            {
                valido = false;
                errorProviderPaisAe.SetError(textBoxPais, "Nombre de Pais requerido");
            }
            return valido;
        }
    }
}
