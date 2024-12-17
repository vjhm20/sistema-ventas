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

namespace CapaPresentacion.Mantenimiento
{
    public partial class FrmProducto : Form
    {
        // -- Atributos
        LProducto oProducto = new LProducto();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 50;
        public FrmProducto()
        {
            InitializeComponent();
            dgvProductos.DataSource = oProducto.Listar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtIdProducto.Text = oProducto.GenerarCodigo();
        }

        private void InsertarProducto()
        {
            // Verificar si algún campo obligatorio está vacío
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text) ||
                string.IsNullOrWhiteSpace(txtDenominacion.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor, complete todos los campos obligatorios.";
                tiempo = 50;
                return; // Sale del método sin continuar con el proceso de guardar
            }

            oProducto.IdProducto = txtIdProducto.Text;
            oProducto.Denominacion = txtDenominacion.Text;
            oProducto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            oProducto.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            oProducto.StockInicial = Convert.ToInt32(txtStockInicial.Text);
            oProducto.StockActual = Convert.ToInt32(txtStockActual.Text);
            oProducto.Insertar();
            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oProducto.Mensaje;
            tiempo = 50;
            dgvProductos.DataSource = oProducto.Listar();
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Recuperar el idProducto
            string idProducto = txtIdProducto.Text;
            oProducto.IdProducto = idProducto; // Para ubicar el id producto dentro de la tabla producto
                                               // Verificar si el producto ya existe en la base de datos
            bool productoExistente = oProducto.ExisteProducto();

            if (productoExistente)
            {
                // Si el producto ya existe, llamar al método para actualizarlo
                ActualizarProducto();
            }
            else
            {
                // Si el producto no existe, llamar al método para insertarlo
                InsertarProducto();
            }
        }

        private void ActualizarProducto()
        {
            oProducto.IdProducto = txtIdProducto.Text;
            oProducto.Denominacion = txtDenominacion.Text;
            oProducto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            oProducto.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            oProducto.StockInicial = Convert.ToInt32(txtStockInicial.Text);
            oProducto.StockActual = Convert.ToInt32(txtStockActual.Text);
            oProducto.Modificar();
            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oProducto.Mensaje;
            tiempo = 50;
            dgvProductos.DataSource = oProducto.Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // -- limpiar atributos
            txtIdProducto.Clear();
            txtDenominacion.Clear();
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
            txtStockInicial.Clear();
            txtStockActual.Clear();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tiempo--;
            if (tiempo == 0)
                lblMensaje.Visible = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvProductos.SelectedRows.Count > 0)
            {
                // Obtener el IdProducto de la fila seleccionada
                string idProductoEliminar = dgvProductos.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                oProducto.IdProducto = idProductoEliminar;

                // Eliminar el registro correspondiente de la tabla TProducto usando la clase LProducto
                oProducto.Eliminar();
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = oProducto.Mensaje;
                tiempo = 50;
                dgvProductos.DataSource = oProducto.Listar();
                LimpiarCampos();
            }
            else
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Seleccione una fila para eliminar.";
                tiempo = 50;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dgvProductos.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvProductos.SelectedRows[0].Index;

                // Obtener los valores de las celdas de la fila seleccionada
                string idProducto = dgvProductos.Rows[indiceFilaSeleccionada].Cells["IdProducto"].Value.ToString();
                string denominacion = dgvProductos.Rows[indiceFilaSeleccionada].Cells["Denominacion"].Value.ToString();
                string cantidad = dgvProductos.Rows[indiceFilaSeleccionada].Cells["Cantidad"].Value.ToString();
                string precioUnitario = dgvProductos.Rows[indiceFilaSeleccionada].Cells["PrecioUnitario"].Value.ToString();
                string stockInicial = dgvProductos.Rows[indiceFilaSeleccionada].Cells["StockInicial"].Value.ToString();
                string stockActual = dgvProductos.Rows[indiceFilaSeleccionada].Cells["StockActual"].Value.ToString();

                // Rellena los controles del formulario con los valores obtenidos
                txtIdProducto.Text = idProducto;
                oProducto.IdProducto = idProducto; // Para ubicar el id producto dentro de la tabla producto
                txtDenominacion.Text = denominacion;
                txtCantidad.Text = cantidad;
                txtPrecioUnitario.Text = precioUnitario;
                txtStockInicial.Text = stockInicial;
                txtStockActual.Text = stockActual;
            }
            else
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Seleccione una fila para editar.";
                tiempo = 50;
            }
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
            // Listar productos con determinadas opciones
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
    }
}
