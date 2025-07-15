using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;
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
    public partial class FrmFiltroPorPais : Form
    {
        private readonly IPaisServicio _paisServicio;
        private Pais? paisFiltro;
        public FrmFiltroPorPais(IPaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        public Pais? GetPais()
        {
            return paisFiltro;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cbPaises, _paisServicio);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cbPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbPaises, "Debe seleccionar un pais");
                return valido;
            }
            return valido;
        }

        private void cbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            paisFiltro=cbPaises.SelectedIndex>0?(Pais)cbPaises.SelectedItem!
                : null;
            //seleccione un pais le doy el pais seleccionado si no selecciono nada le pongo nulo

        }
    }
}
