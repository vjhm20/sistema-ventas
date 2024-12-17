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
    public partial class FrmProveedor : Form
    {
        // Atributos
        LProveedor oProveedor = new LProveedor();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 50;

        public FrmProveedor()
        {
            InitializeComponent();
            dgvProveedores.DataSource = oProveedor.Listar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtIdProveedor.Text = oProveedor.GenerarCodigo();
        }

        private void InsertarProveedor()
        {
            string idProveedor = txtIdProveedor.Text;
            string razonSocial = txtRazonSocial.Text;
            string ruc = txtRUC.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string fechaInscripcion = dtpFecha.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(razonSocial) ||
                string.IsNullOrWhiteSpace(ruc) ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(correo))
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor, complete todos los campos obligatorios.";
                tiempo = 50;
                return;
            }

            oProveedor.IdProveedor = idProveedor;
            oProveedor.RazonSocial = razonSocial;
            oProveedor.RUC = ruc;
            oProveedor.Direccion = direccion;
            oProveedor.Telefono = telefono;
            oProveedor.Correo = correo;
            oProveedor.FechaInscripcion = fechaInscripcion;
            if (chkEstado.Checked == true)
            {
                oProveedor.Estado = 1;
            }
            else if (chkEstado.Checked == false)
            {
                oProveedor.Estado = 0;
            }
            //oProveedor.Estado = 1;
            oProveedor.Insertar();

            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oProveedor.Mensaje;
            tiempo = 50;

            dgvProveedores.DataSource = oProveedor.Listar();
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string idProveedor = txtIdProveedor.Text;
            oProveedor.IdProveedor = idProveedor; // Para ubicar el id empleado dentro de la tabla empleado
            // Verificar si el empleado ya existe en la base de datos
            bool proveedorExistente = oProveedor.ExisteProveedor();

            if (proveedorExistente)
            {
                // Si el empleado ya existe, llamar al método para actualizarlo
                ActualizarProveedor();
            }
            else
            {
                // Si el empleado no existe, llamar al método para insertarlo
                InsertarProveedor();
            }

        }

        private void ActualizarProveedor()
        {
            string idProveedor = txtIdProveedor.Text;
            string razonSocial = txtRazonSocial.Text;
            string ruc = txtRUC.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string fechaInscripcion = dtpFecha.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(razonSocial) ||
                string.IsNullOrWhiteSpace(ruc) ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(correo))
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor, complete todos los campos obligatorios.";
                tiempo = 50;
                return;
            }

            oProveedor.IdProveedor = idProveedor;
            oProveedor.RazonSocial = razonSocial;
            oProveedor.RUC = ruc;
            oProveedor.Direccion = direccion;
            oProveedor.Telefono = telefono;
            oProveedor.Correo = correo;
            oProveedor.FechaInscripcion = fechaInscripcion;
            if (chkEstado.Checked == true)
            {
                oProveedor.Estado = 1;
            }
            else if (chkEstado.Checked == false)
            {
                oProveedor.Estado = 0;
            }
            //oProveedor.Estado = 1;
            oProveedor.Modificar();

            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oProveedor.Mensaje;
            tiempo = 50;

            dgvProveedores.DataSource = oProveedor.Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // -- limpiar atributos
            txtIdProveedor.Clear();
            txtRazonSocial.Clear();            
            dtpFecha.Value = DateTime.Today;
            txtRUC.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            chkEstado.Checked = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                string idProveedor = dgvProveedores.SelectedRows[0].Cells["IdProveedor"].Value.ToString();
                oProveedor.IdProveedor = idProveedor;
                oProveedor.Eliminar();

                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = oProveedor.Mensaje;
                tiempo = 50;

                dgvProveedores.DataSource = oProveedor.Listar();
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
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvProveedores.SelectedRows[0].Index;

                // Obtener los valores de las celdas de la fila seleccionada
                string idproveedor = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["IdProveedor"].Value.ToString();
                string razonsocial = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["RazonSocial"].Value.ToString();
                string ruc = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["RUC"].Value.ToString();                
                string direccion = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["Direccion"].Value.ToString();
                string telefono = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["Telefono"].Value.ToString();
                string correo = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["Correo"].Value.ToString();
                string fechainscripcion = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["FechaInscripcion"].Value.ToString();
                //int estado = dgvProveedores.Rows[indiceFilaSeleccionada].Cells["Estado"].Value.ToString();

                // Rellena los controles del formulario con los valores obtenidos
                txtIdProveedor.Text = idproveedor;
                oProveedor.IdProveedor = idproveedor; // Para ubicar el id empleado dentro de la tabla empleado
                txtRazonSocial.Text = razonsocial;
                txtRUC.Text = ruc;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono;
                txtCorreo.Text = correo;
                dtpFecha.Value = DateTime.Parse(fechainscripcion);

                // Habilita la edición de los campos que se pueden modificar
                txtRazonSocial.Enabled = true;
                txtRUC.Enabled = true;
                dtpFecha.Enabled = true;
                txtCorreo.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
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
            // Listar empleados con determinadas opciones
            dgvProveedores.DataSource = oProveedor.Buscar(campoSeleccionado, valorBuscado);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgvProveedores.DataSource = oProveedor.Listar();
            // Limpiar el campo de texto
            txtTexto.Text = "";
            // Deseleccionar el ítem en el cbCampo
            cbCampo.SelectedItem = null;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tiempo--;
            if (tiempo == 0)
                lblMensaje.Visible = false;
        }
    }
}
