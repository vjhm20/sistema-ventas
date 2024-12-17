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
    public partial class frmVentas : Form
    {
        // -- Atributos
        LCliente oCliente = new LCliente();
        LEmpleado oEmpleado = new LEmpleado();
        LProducto oProducto = new LProducto();
        LComprobante oComprobante = new LComprobante();
        LUsuario oUsuario = new LUsuario();
        public int idComprobante { get; set; }
        public string usuario { get; set; }
        public bool acceso = false;
                                                                  // Creamos TdetalleComprobante
        LDetalleComprobante oDetalleComprobante = new LDetalleComprobante();
        public frmVentas()
        {
            InitializeComponent();            
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                MessageBox.Show("Digite el IdCliente");
                return;
            }
            else
            {
                // Recuperamos el id
                string idCliente = txtIdCliente.Text;
                oCliente.IdCliente = idCliente;
                // Verificamos que exista
                if (oCliente.ExisteCliente() == true)
                {
                    // Mostrar cliente
                    oCliente.MostrarCliente(idCliente);
                    txtNombreCliente.Text = oCliente.Nombre;
                    txtDNI.Text = oCliente.Dni;
                    txtRUC.Text = oCliente.Ruc;
                    txtDireccion.Text = oCliente.Direccion;
                    txtTipoCliente.Text = oCliente.TipoCliente;
                    txtEmail.Text = oCliente.Email;
                }
                else
                {
                    MessageBox.Show("No existe el cliente");
                    return;
                }
            }
        }
        // Boton Nuevo
        private void BtnGenerarIdComprobante_Click(object sender, EventArgs e)
        {
            if (cbTipoComprobante.SelectedItem == null)
            {
                MessageBox.Show("Seleccione tipo de comprobante.");
                return;
            }
            else
            {
                if (cbTipoComprobante.Text == "Boleta")
                {
                    //-- Generar numero de comprobante para factura
                    txtNroComprobante.Text = oComprobante.GenerarNroComprobante(cbTipoComprobante.Text);
                }
                else if (cbTipoComprobante.Text == "Factura")
                {
                    //-- Generar numero de comprobante para factura
                    txtNroComprobante.Text = oComprobante.GenerarNroComprobante(cbTipoComprobante.Text);
                }
            }
        }

        private void BtnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            oUsuario.MostrarUsuario(usuario);
            txtIdEmpleado.Text = oUsuario.IdEmpleado;
            // Recuperamos el id
            string idEmpleado = txtIdEmpleado.Text;
            oEmpleado.IdEmpleado = idEmpleado;
            // Verificamos que exista
            if (oEmpleado.ExisteEmpleado() == true)
            {
                // Mostrar empleado
                oEmpleado.MostrarEmpleado(idEmpleado);
                txtNombreEmpleado.Text = oEmpleado.Nombre;
            }
            else
            {
                MessageBox.Show("No existe el empleado");
                return;
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Verificamos que txtnombreCliente no este vacio
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Deben estar llenos los campos de Cliente");
                return;
            }
            // Verificamos que txtNroComprobante no este vacio.
            if (string.IsNullOrWhiteSpace(txtNroComprobante.Text))
            {
                MessageBox.Show("Debe generar el numero de Comprobante");
                return;
            }
            // Verificamos que txtnombreEmpleado no este vacio
            if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
            {
                MessageBox.Show("Debe buscar su Id Empleado");
                return;
            }
            // extraer mis datos para Crear mi Comprobante
            oComprobante.TipoComprobante = cbTipoComprobante.Text;
            oComprobante.NroComprobante = txtNroComprobante.Text;
            oComprobante.FechaEmision = dtpFecha.Value.ToString("yyyy-MM-dd");
            oComprobante.Monto = 0;
            oComprobante.IdEmpleado = txtIdEmpleado.Text;
            oComprobante.IdCliente = txtIdCliente.Text;
            // Verificamos que el acceso sea true
            if (acceso == false)
            {
                MessageBox.Show("Debe hacer click en NUEVO para la verificacion de datos");
                return;
            }
            else
            {
                // Dialogo de formulario de bsqueda de productos
                Consultas.frmBuscarProducto formBuscarProductos = new Consultas.frmBuscarProducto();
                int idCompro = oComprobante.ObtenerIdComprobanteCreado(); // IdComprobante
                idComprobante = idCompro;
                formBuscarProductos.IDComprobante = idCompro;
                if (formBuscarProductos.ShowDialog() == DialogResult.OK)
                {
                    // Realizara el proceso de agregacion en TDetalleComprobante
                }
                // Agregar una nueva fila al DataGridView dgvVentas
                dgvVentas.DataSource = oDetalleComprobante.ListarProductos(idCompro);
                CalcularYActualizarTotal();
            }
        }

        // Función para calcular y actualizar el total
        private void CalcularYActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                decimal totalproducto = Convert.ToDecimal(row.Cells["TotalCompra"].Value);
                total += totalproducto;
            }

            txtSubTotal.Text = total.ToString("N2");
            if (cbTipoComprobante.Text == "Factura")
            {
                double igv = 0.18 * double.Parse(txtSubTotal.Text);
                txtIGV.Text = igv.ToString("N2");
                double suma = igv + double.Parse(txtSubTotal.Text);
                txtTotal.Text = suma.ToString("N2");
            }
            else if (cbTipoComprobante.Text == "Boleta")
            {
                double suma = double.Parse(txtSubTotal.Text);
                txtTotal.Text = suma.ToString("N2");
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            bool resultado = oComprobante.InsertarCliente(); // Se crea mi comprobante
            if (resultado == true)
                acceso = true;
            else
                acceso = false;
            MessageBox.Show("Puede empezar a agregar productos");
        }

        private void LimpiarCampos()
        {
            //--Limpiamos en cliente
            txtIdCliente.Clear();
            txtNombreCliente.Clear();
            txtDNI.Clear();
            txtRUC.Clear();
            txtDireccion.Clear();
            txtTipoCliente.Clear();
            txtEmail.Clear();
            //--Limpiamos en comprobante
            cbTipoComprobante.SelectedItem = null;
            txtNroComprobante.Clear();
            //--Limpiamos el DataGridView dgvVentas
            dgvVentas.DataSource = null;
            //--Limpiamos precios
            txtSubTotal.Clear();
            txtIGV.Text = "";
            txtTotal.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Se cambia el acceso
            acceso = false;
            decimal Total = decimal.Parse(txtSubTotal.Text);
            oComprobante.ActualizarMontoComprobante(idComprobante,Total);
            LimpiarCampos();
            MessageBox.Show("Comprobante generado correctamente");
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            oUsuario.MostrarUsuario(usuario);
            txtIdEmpleado.Text = oUsuario.IdEmpleado;
            // Recuperamos el id
            string idEmpleado = txtIdEmpleado.Text;
            oEmpleado.IdEmpleado = idEmpleado;
            // Verificamos que exista
            if (oEmpleado.ExisteEmpleado() == true)
            {
                // Mostrar empleado
                oEmpleado.MostrarEmpleado(idEmpleado);
                txtNombreEmpleado.Text = oEmpleado.Nombre;
            }
            else
            {
                MessageBox.Show("No existe el empleado");
                return;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnQuitarProducto_Click(object sender, EventArgs e)
        {
            int idCompro = oComprobante.ObtenerIdComprobanteCreado(); // IdComprobante
            idComprobante = idCompro;
            // Obtener el valor de la celda "IdProducto" de la fila seleccionada
            if (dgvVentas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvVentas.SelectedRows[0];
                int idDetalle = (int)selectedRow.Cells["IdDetalle"].Value;
                bool resultado = oDetalleComprobante.Eliminar(idDetalle);
                if (resultado == true)
                {
                    dgvVentas.DataSource = oDetalleComprobante.ListarProductos(idCompro);
                    CalcularYActualizarTotal();
                    MessageBox.Show("Se elimino correctamente un producto");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }
    }
}
