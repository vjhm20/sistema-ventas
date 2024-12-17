using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using System.IO;

namespace CapaPresentacion.Mantenimiento
{
    public partial class FrmEmpleado : Form
    {
        // -- Atributos
        LEmpleado oEmpleado = new LEmpleado();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 50;
        Image imagenMonigote = Properties.Resources.monigote;

        // -- Inicio de formulario
        public FrmEmpleado()
        {
            InitializeComponent();
            dgvEmpleados.DataSource = oEmpleado.Listar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtIdEmpleado.Text = oEmpleado.GenerarCodigo();
        }

        private void InsertarEmpleado()
        {
            // Verificar si algún campo obligatorio está vacío
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(cbCargo.Text))
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor, complete todos los campos.";
                tiempo = 50;
                return; // Sale del método sin continuar con el proceso de guardar
            }

            oEmpleado.IdEmpleado = txtIdEmpleado.Text;
            oEmpleado.Nombre = txtNombre.Text;
            oEmpleado.Dni = txtDNI.Text;
            oEmpleado.FechaNacimiento = dtpFecha.Value.ToString("yyyy-MM-dd");
            oEmpleado.Email = txtEmail.Text;
            oEmpleado.Direccion = txtDireccion.Text;
            oEmpleado.Telefono = txtTelefono.Text;
            oEmpleado.Cargo = cbCargo.Text;
            oEmpleado.Foto = oUtilitarios.Image2Bytes(pbFoto.Image);
            oEmpleado.Insertar();
            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oEmpleado.Mensaje;
            tiempo = 50;
            dgvEmpleados.DataSource = oEmpleado.Listar();
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Recuperar el idEmpleado
            string idEmpleado = txtIdEmpleado.Text;
            oEmpleado.IdEmpleado = idEmpleado; // Para ubicar el id empleado dentro de la tabla empleado
            // Verificar si el empleado ya existe en la base de datos
            bool empleadoExistente = oEmpleado.ExisteEmpleado();

            if (empleadoExistente)
            {
                // Si el empleado ya existe, llamar al método para actualizarlo
                ActualizarEmpleado();
            }
            else
            {
                // Si el empleado no existe, llamar al método para insertarlo
                InsertarEmpleado();
            }
        }

        private void ActualizarEmpleado()
        {
            oEmpleado.IdEmpleado = txtIdEmpleado.Text;
            oEmpleado.Nombre = txtNombre.Text;
            oEmpleado.Dni = txtDNI.Text;
            oEmpleado.FechaNacimiento = dtpFecha.Value.ToString("yyyy-MM-dd");
            oEmpleado.Email = txtEmail.Text;
            oEmpleado.Direccion = txtDireccion.Text;
            oEmpleado.Telefono = txtTelefono.Text;
            oEmpleado.Cargo = cbCargo.Text;
            oEmpleado.Foto = oUtilitarios.Image2Bytes(pbFoto.Image);
            oEmpleado.Modificar();
            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oEmpleado.Mensaje;
            tiempo = 50;
            dgvEmpleados.DataSource = oEmpleado.Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // -- limpiar atributos
            txtIdEmpleado.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            dtpFecha.Value = DateTime.Today;
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            cbCargo.SelectedItem = null;
            pbFoto.Image = imagenMonigote;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tiempo--;
            if (tiempo == 0)
                lblMensaje.Visible = false;
        }

        private void BtnSubirImagen_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo para seleccionar una imagen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mostrar la imagen seleccionada en el PictureBox
                pbFoto.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el IdEmpleado de la fila seleccionada
                string idEmpleadoEliminar = dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value.ToString();
                oEmpleado.IdEmpleado = idEmpleadoEliminar;

                // Eliminar el registro correspondiente de la tabla TEmpleado usando la clase CEmpleado
                oEmpleado.Eliminar();
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = oEmpleado.Mensaje;
                tiempo = 50;
                dgvEmpleados.DataSource = oEmpleado.Listar();
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
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvEmpleados.SelectedRows[0].Index;

                // Obtener los valores de las celdas de la fila seleccionada
                string idEmpleado = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["IdEmpleado"].Value.ToString();
                string nombre = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["Nombre"].Value.ToString();
                string dni = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["DNI"].Value.ToString();
                string fechaNacimiento = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["FechaNacimiento"].Value.ToString();
                string email = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["Email"].Value.ToString();
                string direccion = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["Direccion"].Value.ToString();
                string telefono = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["Telefono"].Value.ToString();
                string cargo = dgvEmpleados.Rows[indiceFilaSeleccionada].Cells["Cargo"].Value.ToString();

                // Rellena los controles del formulario con los valores obtenidos
                txtIdEmpleado.Text = idEmpleado;
                oEmpleado.IdEmpleado = idEmpleado; // Para ubicar el id empleado dentro de la tabla empleado
                txtNombre.Text = nombre;
                txtDNI.Text = dni;
                dtpFecha.Value = DateTime.Parse(fechaNacimiento);
                txtEmail.Text = email;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono;
                cbCargo.Text = cargo;

                // Obtener la foto del empleado desde la base de datos
                byte[] fotoBytes = oEmpleado.ObtenerFoto();

                // Convertir el arreglo de bytes en una imagen
                if (fotoBytes != null && fotoBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(fotoBytes))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Si no hay foto guardada, puedes mostrar una imagen por defecto o dejar el PictureBox vacío.
                    pbFoto.Image = imagenMonigote;
                }

                // Habilita la edición de los campos que se pueden modificar
                txtNombre.Enabled = true;
                txtDNI.Enabled = true;
                dtpFecha.Enabled = true;
                txtEmail.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
                pbFoto.Enabled = true;
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
            dgvEmpleados.DataSource = oEmpleado.Buscar(campoSeleccionado, valorBuscado);            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = oEmpleado.Listar();
            // Limpiar el campo de texto
            txtTexto.Text = "";
            // Deseleccionar el ítem en el cbCampo
            cbCampo.SelectedItem = null;
        }
    }
}
