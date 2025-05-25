using Bombones2025.Entidades;
using Bombones2025.Servicios.Servicios;
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
    public partial class FrmPaises : Form
    {
        //llamo a servicios
        private readonly PaisServicio _paisServicio = null!;
        //instancio la lista
        private List<Pais> _paises = new();
        public FrmPaises(PaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            _paises = _paisServicio.GetPais();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvPaises.Rows.Clear();
            foreach (Pais pais in _paises)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvPaises);
                SetearFila(r, pais);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvPaises.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[0].Value = pais.PaisId;
            r.Cells[1].Value = pais.NombrePais;

            r.Tag = pais;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        //clase 003 min 1:09:01 
    }
}
