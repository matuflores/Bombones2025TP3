using Bombones2025.Entidades;
using Bombones2025.Servicios.Interfaces;
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

namespace Bombones2025.Windows.AE
{
    public partial class FrmProvinciasEstadosAE : Form
    {
        private ProvinciaEstado? _provinciaEstado;
        private readonly IPaisServicio _paisServicio;
        public FrmProvinciasEstadosAE(IPaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cbPaisProvEst, _paisServicio);
        }
        public ProvinciaEstado? GetProvinciaEstado()
        {
            return _provinciaEstado;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_provinciaEstado is null)
                {
                    _provinciaEstado = new ProvinciaEstado();
                }
                _provinciaEstado.NombreProvinciaEstado = textBoxProvEst.Text;
                _provinciaEstado.PaisId = (int)cbPaisProvEst.SelectedValue!;
                //aca le paso el PAIS id, pero tengo que mostrar el nombre en la grilla
                
                
                //_provinciaEstado.Pais=(Pais)cbPaisProvEst.SelectedItem!;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBoxProvEst.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxProvEst, "El nombre es requerido");
            }
            if (cbPaisProvEst.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cbPaisProvEst, "Debe seleccionar un pais");
            }
            
            return valido;
        }
    }
}
