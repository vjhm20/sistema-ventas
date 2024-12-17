using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using System.IO;

namespace CapaPresentacion.Procesos
{
    public partial class frmAnularComprobante : Form
    {
        LComprobante oComprobante = new LComprobante();
        public frmAnularComprobante()
        {
            InitializeComponent();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            string tipoComprobante = cbTipo.SelectedItem.ToString();
            string nroComprobante = txtNroComprobante.Text;

            if (string.IsNullOrEmpty(tipoComprobante) || string.IsNullOrEmpty(nroComprobante))
            {
                MessageBox.Show("Por favor, completa ambos campos antes de anular el comprobante.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (oComprobante.AnularComprobante(nroComprobante) == true)
            {
                if (oComprobante.ActualizarStock(tipoComprobante,nroComprobante) == true)
                {
                    string mensaje = oComprobante.Mensaje;
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error");
                    return;
                }
            }
            else
            {
                string mensaje = oComprobante.Mensaje;
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            cbTipo.SelectedItem = null;
            cbTipoComprobante.SelectedItem = null;
            txtNroComprobante.Clear();
        }
    }
}
