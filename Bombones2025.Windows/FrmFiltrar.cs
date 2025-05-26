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
    public partial class FrmFiltrar : Form
    {
        private string? textoFiltro;
        public FrmFiltrar()
        {
            InitializeComponent();
        }

        public string? GetTexto()
        {
            return textoFiltro;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                textoFiltro=textBoxFiltrar.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderFiltrar.Clear();
            if (string.IsNullOrEmpty(textBoxFiltrar.Text.Trim()))
            {
                valido= false;
                errorProviderFiltrar.SetError(textBoxFiltrar, "Debe ingresar un texto a filtrar");
            }
            return valido;
        }
    }
}
