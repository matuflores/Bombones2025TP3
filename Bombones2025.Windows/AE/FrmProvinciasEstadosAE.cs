using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;

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
            if(_provinciaEstado is not null)
            {
                textBoxProvEst.Text = _provinciaEstado.NombreProvinciaEstado;

                //Si no me aparece el pais correspondiente a la prov/est es porque el select
                //no es el que corresponde, antes tenia SELECTEINDEX y no era correcto el pais que
                //me cargaba el cbPaisProvEst
                cbPaisProvEst.SelectedValue = _provinciaEstado.PaisId;
            }
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
            if (cbPaisProvEst.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbPaisProvEst, "Debe seleccionar un pais");
            }

            return valido;
        }

        internal void SetProvinciaEstado(ProvinciaEstado provEstEdit)
        {
            _provinciaEstado = provEstEdit;
        }
    }
}
