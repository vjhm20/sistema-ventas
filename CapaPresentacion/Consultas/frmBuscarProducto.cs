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

namespace CapaPresentacion.Consultas
{
    public partial class frmBuscarProducto : Form
    {
        
        // Atributos
        int tiempo = 50;
        public int IDComprobante { get; set; }
        public string IdProductoSeleccionado { get; set; }
        public string DenominacionSeleccionada { get; set; }
        public decimal PrecioUnitarioSeleccionado { get; set; }
        public int CantidadSeleccionada { get; set; }

        LProducto oProducto = new LProducto();
        public frmBuscarProducto()
        {
            InitializeComponent();
            dgvProductos.DataSource = oProducto.Listar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cbCampo.SelectedItem == null)
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Seleccione un campo para buscar.";
                tiempo = 50;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ingrese un valor para buscar.";
                tiempo = 50;
                return;
            }

            string campoSeleccionado = cbCampo.SelectedItem.ToString();
            string valorBuscado = txtTexto.Text;
            // Listar empleados con determinadas opciones
            dgvProductos.DataSource = oProducto.Buscar(campoSeleccionado, valorBuscado);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = oProducto.Listar();
            // Limpiar el campo de texto
            txtTexto.Text = "";
            // Deseleccionar el ítem en el cbCampo
            cbCampo.SelectedItem = null;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener el valor de la celda "IdProducto" de la fila seleccionada
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProductos.SelectedRows[0];
                string idProducto = selectedRow.Cells["IdProducto"].Value.ToString();
                string denominacion = selectedRow.Cells["Denominacion"].Value.ToString();
                decimal precioUnitario = Convert.ToDecimal(selectedRow.Cells["PrecioUnitario"].Value);
                decimal cantidadDecimal = nudCantidad.Value;
                int cantidad = (int)cantidadDecimal;
                if (cantidad <=0)
                {
                    MessageBox.Show("Compre minimo un producto");
                    return;
                }
                // Recuperamos para el otro formulario
                IdProductoSeleccionado = idProducto;
                DenominacionSeleccionada = denominacion;
                PrecioUnitarioSeleccionado = precioUnitario;
                CantidadSeleccionada = cantidad;
                // Creamos TdetalleComprobante
                LDetalleComprobante oDetalleComprobante = new LDetalleComprobante();
                oDetalleComprobante.Cantidad = cantidad;
                oDetalleComprobante.PrecioUnitario = precioUnitario;
                oDetalleComprobante.IdComprobante = IDComprobante;
                oDetalleComprobante.IdProducto = idProducto;
                // Insertamos
                bool resultado = oDetalleComprobante.Insertar();
                if (resultado == true)
                {
                    MessageBox.Show("Se agrego exitosamente un producto");
                }
                Close();
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
