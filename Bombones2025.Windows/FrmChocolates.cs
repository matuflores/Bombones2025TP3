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
    public partial class FrmChocolates : Form
    {
        private readonly ChocolateServicio _chocolateServicio = null!;
        private List<Chocolate> _chocolates = new();
        public FrmChocolates(ChocolateServicio chocolateServicio)
        {
            InitializeComponent();
            _chocolateServicio = chocolateServicio;
        }

        private void FrmChocolates_Load(object sender, EventArgs e)
        {
            _chocolates = _chocolateServicio.GetChocolate();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvChocolates.Rows.Clear();
            foreach (Chocolate chocolate in _chocolates)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvChocolates);
                SetearFila(r, chocolate);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvChocolates.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Chocolate chocolate)
        {
            r.Cells[0].Value = chocolate.ChocolateId;
            r.Cells[1].Value = chocolate.Descripcion;
            r.Tag = chocolate;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
