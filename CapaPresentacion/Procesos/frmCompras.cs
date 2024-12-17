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
    public partial class frmCompras : Form
    {
        // -- Atributos
        LProveedor oProveedor = new LProveedor();
        LEmpleado oEmpleado = new LEmpleado();
        LProducto oProducto = new LProducto();
        LComprobante oComprobante = new LComprobante();
        LUsuario oUsuario = new LUsuario();
        public int idComprobante { get; set; }
        public string usuario { get; set; }
        public bool acceso = false;
        // Creamos TdetalleComprobante
        LDetalleComprobante oDetalleComprobante = new LDetalleComprobante();
        public frmCompras()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Digite el RUC del proveedor");
                return;
            }
            else
            {
                // Recuperamos el ruc
                string ruc = txtRUC.Text;
                //oProveedor.MostrarProveedorPorRUC(ruc);
                oProveedor.RUC = ruc;
                // Verificamos que exista
                if (oProveedor.ExisteProveedorPorRUC(ruc) == true)
                {
                    // Mostrar proveedor
                    oProveedor.MostrarProveedorPorRUC(ruc);
                    txtIdProveedor.Text = oProveedor.IdProveedor;
                    txtRazonSocial.Text = oProveedor.RazonSocial;
                    txtDireccion.Text = oProveedor.Direccion;
                    txtTelefono.Text = oProveedor.Telefono;
                    txtCorreo.Text = oProveedor.Correo;
                    txtFechaInscripcion.Text = oProveedor.FechaInscripcion;
                    oProveedor.Estado = 1;
                }
                else
                {
                    MessageBox.Show("No existe el proveedor");
                    return;
                }
            }
        }
        // Boton Nuevo
        private void BtnGenerarIdComprobante_Click(object sender, EventArgs e)
        {
            if (txtTipoComprobante.Text == "")
            {
                MessageBox.Show("Seleccione tipo de comprobante.");
                return;
            }
            else
            {
                if (txtTipoComprobante.Text == "Boleta")
                {
                    //-- Generar numero de comprobante para factura
                    txtNroComprobante.Text = oComprobante.GenerarNroComprobante(txtTipoComprobante.Text);
                }
                else if (txtTipoComprobante.Text == "Factura")
                {
                    //-- Generar numero de comprobante para factura
                    txtNroComprobante.Text = oComprobante.GenerarNroComprobante(txtTipoComprobante.Text);
                }
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Verificamos que txtIdProveedor no este vacio
            if (string.IsNullOrWhiteSpace(txtIdProveedor.Text))
            {
                MessageBox.Show("Deben estar llenos los campos de Proveedor");
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
            oComprobante.TipoComprobante = txtTipoComprobante.Text;
            oComprobante.NroComprobante = txtNroComprobante.Text;
            oComprobante.FechaEmision = dtpFecha.Value.ToString("yyyy-MM-dd");
            oComprobante.Monto = 0;
            oComprobante.IdEmpleado = txtIdEmpleado.Text;
            // oComprobante.IdCliente = null; // auxiliar
            oComprobante.IdProveedor = txtIdProveedor.Text;
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
            if (txtTipoComprobante.Text == "Factura")
            {
                double igv = 0.18 * double.Parse(txtSubTotal.Text);
                txtIGV.Text = igv.ToString("N2");
                double suma = igv + double.Parse(txtSubTotal.Text);
                txtTotal.Text = suma.ToString("N2");
            }
            else if (txtTipoComprobante.Text == "Boleta")
            {
                double suma = double.Parse(txtSubTotal.Text);
                txtTotal.Text = suma.ToString("N2");
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            bool resultado = oComprobante.InsertarProveedor(); // Se crea mi comprobante
            if (resultado == true)
                acceso = true;
            else
                acceso = false;
            MessageBox.Show("Puede empezar a agregar productos");
        }

        private void LimpiarCampos()
        {
            //--Limpiamos en proveedor
            txtRUC.Clear();
            txtIdProveedor.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtFechaInscripcion.Clear();
            //--Limpiamos en comprobante
            //txtTipoComprobante.Clear();
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
            oComprobante.ActualizarMontoComprobante(idComprobante, Total);
            LimpiarCampos();
            MessageBox.Show("Comprobante generado correctamente");
        }

        private void FrmCompras_Load(object sender, EventArgs e)
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
    }
}
