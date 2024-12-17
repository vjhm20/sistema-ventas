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
    public partial class FrmCliente : Form
    {
        // -- Atributos
        LCliente oCliente = new LCliente();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 50;
        Image imagenDefault = Properties.Resources.monigote;

        public FrmCliente()
        {
            InitializeComponent();
            dgvClientes.DataSource = oCliente.Listar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = oCliente.GenerarCodigo();
        }

        private void InsertarCliente()
        {
            // Verificar si algún campo obligatorio está vacío
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtTipoCliente.Text))
            {
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor, complete todos los campos obligatorios.";
                tiempo = 50;
                return; // Sale del método sin continuar con el proceso de guardar
            }

            oCliente.IdCliente = txtIdCliente.Text;
            oCliente.Nombre = txtNombre.Text;
            oCliente.Dni = txtDNI.Text;
            oCliente.TipoCliente = txtTipoCliente.Text;
            oCliente.Email = txtEmail.Text;
            oCliente.Ruc = txtRUC.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Foto = oUtilitarios.Image2Bytes(pbFoto.Image);
            oCliente.Insertar();
            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oCliente.Mensaje;
            tiempo = 50;
            dgvClientes.DataSource = oCliente.Listar();
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Recuperar el idCliente
            string idCliente = txtIdCliente.Text;
            oCliente.IdCliente = idCliente; // Para ubicar el id cliente dentro de la tabla cliente
                                            // Verificar si el cliente ya existe en la base de datos
            bool clienteExistente = oCliente.ExisteCliente();

            if (clienteExistente)
            {
                // Si el cliente ya existe, llamar al método para actualizarlo
                ActualizarCliente();
            }
            else
            {
                // Si el cliente no existe, llamar al método para insertarlo
                InsertarCliente();
            }
        }

        private void ActualizarCliente()
        {
            oCliente.IdCliente = txtIdCliente.Text;
            oCliente.Nombre = txtNombre.Text;
            oCliente.Dni = txtDNI.Text;
            oCliente.TipoCliente = txtTipoCliente.Text;
            oCliente.Email = txtEmail.Text;
            oCliente.Ruc = txtRUC.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Foto = oUtilitarios.Image2Bytes(pbFoto.Image);
            oCliente.Modificar();
            timer1.Enabled = true;
            lblMensaje.Visible = true;
            lblMensaje.Text = oCliente.Mensaje;
            tiempo = 50;
            dgvClientes.DataSource = oCliente.Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // -- limpiar atributos
            txtIdCliente.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtTipoCliente.Clear();
            txtEmail.Clear();
            txtRUC.Clear();
            txtDireccion.Clear();
            pbFoto.Image = imagenDefault;
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el IdCliente de la fila seleccionada
                string idClienteEliminar = dgvClientes.SelectedRows[0].Cells["IdCliente"].Value.ToString();
                oCliente.IdCliente = idClienteEliminar;

                // Eliminar el registro correspondiente de la tabla TCliente usando la clase LCliente
                oCliente.Eliminar();
                timer1.Enabled = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = oCliente.Mensaje;
                tiempo = 50;
                dgvClientes.DataSource = oCliente.Listar();
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
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvClientes.SelectedRows[0].Index;

                // Obtener los valores de las celdas de la fila seleccionada
                string idCliente = dgvClientes.Rows[indiceFilaSeleccionada].Cells["IdCliente"].Value.ToString();
                string nombre = dgvClientes.Rows[indiceFilaSeleccionada].Cells["Nombre"].Value.ToString();
                string dni = dgvClientes.Rows[indiceFilaSeleccionada].Cells["DNI"].Value.ToString();
                string tipoCliente = dgvClientes.Rows[indiceFilaSeleccionada].Cells["TipoCliente"].Value.ToString();
                string email = dgvClientes.Rows[indiceFilaSeleccionada].Cells["Email"].Value.ToString();
                string ruc = dgvClientes.Rows[indiceFilaSeleccionada].Cells["RUC"].Value.ToString();
                string direccion = dgvClientes.Rows[indiceFilaSeleccionada].Cells["Direccion"].Value.ToString();

                // Rellena los controles del formulario con los valores obtenidos
                txtIdCliente.Text = idCliente;
                oCliente.IdCliente = idCliente; // Para ubicar el id cliente dentro de la tabla cliente
                txtNombre.Text = nombre;
                txtDNI.Text = dni;
                txtTipoCliente.Text = tipoCliente;
                txtEmail.Text = email;
                txtRUC.Text = ruc;
                txtDireccion.Text = direccion;

                // Obtener la foto del cliente desde la base de datos
                byte[] fotoBytes = oCliente.ObtenerFoto();

                // Convertir el arreglo de bytes en una imagen
                if (fotoBytes == null)
                {
                    // Si no hay foto guardada, puedes mostrar una imagen por defecto o dejar el PictureBox vacío.
                    pbFoto.Image = imagenDefault;
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream(fotoBytes))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }
                /*
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
                    pbFoto.Image = imagenDefault;
                }
                */
                // Habilita la edición de los campos que se pueden modificar
                txtNombre.Enabled = true;
                txtDNI.Enabled = true;
                txtTipoCliente.Enabled = true;
                txtEmail.Enabled = true;
                txtRUC.Enabled = true;
                txtDireccion.Enabled = true;
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
            // Listar clientes con determinadas opciones
            dgvClientes.DataSource = oCliente.Buscar(campoSeleccionado, valorBuscado);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = oCliente.Listar();
            // Limpiar el campo de texto
            txtTexto.Text = "";
            // Deseleccionar el ítem en el cbCampo
            cbCampo.SelectedItem = null;
        }
    }
}
