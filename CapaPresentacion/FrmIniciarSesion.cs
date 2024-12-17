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

namespace CapaPresentacion
{
    public partial class FrmIniciarSesion : Form
    {
        // -- Atributos
        LUsuario oUsuario = new LUsuario();
        
        //cUtilitarios oUtilitarios = new cUtilitarios();
        //int tiempo = 50;
        //Image imagenMonigote = Properties.Resources.monigote;
        //FrmPrincipal formularioPrincipal;
        // Propiedad para indicar si el inicio de sesión fue exitoso
        public bool InicioSesionExitoso { get; set; }
        public string cargo { get; set; }
        public bool estado { get; set; }
        public string usuarioSesion { get; set; }

        int contadorIntentos = 0;

        FrmPrincipal frm;

        public FrmIniciarSesion()
        {
            InitializeComponent();
            InicioSesionExitoso = false; // Inicializar como falso al inicio
            frm = this.MdiParent as FrmPrincipal;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;

            // Verificar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = oUsuario.IniciarSesion(usuario,contrasenia);
            //string mensaje = oUsuario.Mensaje;

            // Aquí verificas el inicio de sesión y si es exitoso, haces lo siguiente:
            if (resultado == true)
            {
                if (oUsuario.MostrarEstado(usuario) == true)
                {
                    // Indicar que el inicio de sesión es exitoso
                    InicioSesionExitoso = true;
                    cargo = oUsuario.RecuperarCargoUsuario(usuario);
                    oUsuario.MostrarUsuario(usuario);
                    usuarioSesion = usuario;
                    //frm.Actualizar(usuarioSesion);
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cierras el formulario de inicio de sesión
                }
                else
                {
                    MessageBox.Show("El usuario está inhabilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Cerrar ambos formularios (FrmIniciarSesion y FrmPrincipal)
                    this.Close();
                    Application.Exit();
                }                
            }
            else
            {
                // Incrementar el contador de intentos fallidos
                contadorIntentos++;

                // Mostrar el contador de intentos en el TextBox
                txtContador.Text = contadorIntentos.ToString();

                // Verificar si se alcanzó el límite de 3 intentos fallidos
                if (contadorIntentos == 3)
                {
                    MessageBox.Show("Se alcanzó el límite de intentos fallidos. La aplicación se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Cerrar ambos formularios (FrmIniciarSesion y FrmPrincipal)
                    this.Close();
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
