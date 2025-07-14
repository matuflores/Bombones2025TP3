using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }

        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Chocolate chocolate:
                    r.Cells[0].Value = chocolate.ChocolateId;
                    r.Cells[1].Value = chocolate.Descripcion;
                    break;

                case Pais pais:
                    r.Cells[0].Value = pais.PaisId;
                    r.Cells[1].Value = pais.NombrePais;
                    break;

                case Relleno relleno:
                    r.Cells[0].Value = relleno.RellenoId;
                    r.Cells[1].Value = relleno.Descripcion;
                    break;

                case FrutoSeco frutoSeco:
                    r.Cells[0].Value = frutoSeco.FrutoSecoId;
                    r.Cells[1].Value = frutoSeco.Descripcion;
                    break;

                case FormaDePago tipoDePago:
                    r.Cells[0].Value=tipoDePago.FormaDePagoId;
                    r.Cells[1].Value = tipoDePago.Descripcion;
                    break;

                case ProvinciaEstado provinciaEstado:
                    r.Cells[0].Value = provinciaEstado.ProvinciaEstadoId;
                    r.Cells[1].Value = provinciaEstado.NombreProvinciaEstado;
                    r.Cells[2].Value = provinciaEstado.PaisId;
                    break;
            }
            r.Tag = obj;

        }

        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }

        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }
    }
}
