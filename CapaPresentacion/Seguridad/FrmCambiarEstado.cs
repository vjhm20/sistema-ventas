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

namespace CapaPresentacion.Seguridad
{
    public partial class FrmCambiarEstado : Form
    {
        // -- Atributos
        LUsuario oUsuario = new LUsuario();
        // Propiedad para almacenar el nombre de usuario
        public string id { get; set; }
        public FrmCambiarEstado()
        {
            InitializeComponent();
            dgvUsuarios.DataSource = oUsuario.Listar();
        }
        // Boton para seleccionar usuario
        private void Button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvUsuarios.SelectedRows[0].Index;

                // Obtener los valores de las celdas de la fila seleccionada
                string usuario = dgvUsuarios.Rows[indiceFilaSeleccionada].Cells["Usuario"].Value.ToString();
                bool estado = (bool)dgvUsuarios.Rows[indiceFilaSeleccionada].Cells["Estado"].Value;
                string idEmpleado = dgvUsuarios.Rows[indiceFilaSeleccionada].Cells["IdEmpleado"].Value.ToString();

                // Rellena los controles del formulario con los valores obtenidos
                txtUsuario.Text = usuario;
                if (estado == true)
                    cbEstado.Text = "Activado";
                else
                    cbEstado.Text = "Desactivado";
                id = idEmpleado;
                // Deshabilita la edición de los campos que no se pueden modificar
                txtUsuario.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            int valor;
            if (cbEstado.Text == "Activado")
                valor = 1;
            else
                valor = 0;
            bool resultado = oUsuario.CambiarEstadoUsuario(id,valor);
            if (resultado == true)
            {
                dgvUsuarios.DataSource = oUsuario.Listar();
                MessageBox.Show(oUsuario.Mensaje);
                txtUsuario.Text = "";
                cbEstado.SelectedItem = null;
            }
            else
                MessageBox.Show(oUsuario.Mensaje);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cbCampo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un campo para buscar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                MessageBox.Show("Ingrese un valor para buscar.");
                return;
            }

            string campoSeleccionado = cbCampo.SelectedItem.ToString();
            string valorBuscado = txtTexto.Text;
            // Listar empleados con determinadas opciones
            dgvUsuarios.DataSource = oUsuario.Buscar(campoSeleccionado, valorBuscado);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = oUsuario.Listar();
            // Limpiar el campo de texto
            txtTexto.Text = "";
            // Deseleccionar el ítem en el cbCampo
            cbCampo.SelectedItem = null;
            // Desactivar
            txtUsuario.Text = "";
            cbEstado.SelectedItem = null;
        }
    }
}
