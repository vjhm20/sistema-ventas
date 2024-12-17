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
    public partial class FrmCambiarContrasenia : Form
    {
        // -- Atributos
        LUsuario oUsuario = new LUsuario();
        // Propiedad para almacenar el nombre de usuario
        public string UsuarioSesion { get; set; }
        public FrmCambiarContrasenia()
        {
            InitializeComponent();
        }

        private void RecuperarUsuario()
        {
            if (UsuarioSesion != null)
                txtUsuario.Text = UsuarioSesion;
            else
                txtUsuario.Text = "-----";
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            //oUsuario.CambiarContrasenia(Usuario,txt);
            if (string.IsNullOrWhiteSpace(txtContraseniaActual.Text))
            {
                MessageBox.Show("Complete la Contraseña Actual");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNuevaContrasenia.Text))
            {
                MessageBox.Show("Complete la Contraseña Nueva");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmacionNuevaContrasenia.Text))
            {
                MessageBox.Show("Complete la confirmacion de la Contraseña Nueva");
                return;
            }
            if (txtNuevaContrasenia.Text.ToString() != txtConfirmacionNuevaContrasenia.Text.ToString())
            {
                MessageBox.Show("Complete de manera igual los campos de la Contraseña Nueva y su confirmacion");
                return;
            }
            bool resultado = oUsuario.CambiarContrasenia(UsuarioSesion, txtContraseniaActual.Text.ToString(),txtNuevaContrasenia.Text.ToString());
            if (resultado == true)
            {
                MessageBox.Show(oUsuario.Mensaje);
                txtContraseniaActual.Text = "";
                txtNuevaContrasenia.Text = "";
                txtConfirmacionNuevaContrasenia.Text = "";
            }                
            else
            {
                MessageBox.Show(oUsuario.Mensaje);
            }
                
        }

        // Boton cancelar
        private void Button1_Click(object sender, EventArgs e)
        {
            txtContraseniaActual.Text = "";
            txtNuevaContrasenia.Text = "";
            txtConfirmacionNuevaContrasenia.Text = "";
        }

        private void FrmCambiarContrasenia_Load(object sender, EventArgs e)
        {
            RecuperarUsuario();
        }
    }
}
