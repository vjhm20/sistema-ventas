using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        public string UsuarioSes { get; set; }
        public FrmIniciarSesion frmIniciarSesion = new FrmIniciarSesion();
        public FrmPrincipal()
        {
            InitializeComponent();
            // Deshabilitar el menú strip al inicio
            menuStrip1.Enabled = false;
        }

        private void MantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmEmpleado emp = new Mantenimiento.FrmEmpleado();
            emp.Show();
        }

        private void OpcionSalir_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Abres el formulario de inicio de sesión y pasas el formulario principal como argumento
            frmIniciarSesion.ShowDialog();
            // Verificar si el inicio de sesión fue exitoso
            if (frmIniciarSesion.InicioSesionExitoso)
            {
                // Si la sesión se inició correctamente, habilitar el menú strip
                if (frmIniciarSesion.cargo == "SuperAdministrador")
                {
                    menuStrip1.Enabled = true; // Todo
                    UsuarioSes = frmIniciarSesion.usuarioSesion;
                    Actualizar();
                }                    
                else if (frmIniciarSesion.cargo == "Administrador")
                {
                    menuStrip1.Enabled = true; // -- config
                    // Mantenimiento
                    opcionMantenimiento.Enabled = true; 
                    // Procesos
                    opcionProcesos.Enabled = true;
                    opcionVentas.Enabled = false;
                    // Reportes
                    opcionReportes.Enabled = true;
                    // Consultas
                    opcionConsultas.Enabled = true;
                    // Seguridad
                    opcionSeguridad.Enabled = true;

                    UsuarioSes = frmIniciarSesion.usuarioSesion;
                    Actualizar();
                }
                else if (frmIniciarSesion.cargo == "Vendedor")
                {
                    menuStrip1.Enabled = true; // -- config
                    // Mantenimiento
                    opcionMantenimiento.Enabled = true;
                    opcionProducto.Enabled = false;
                    // Procesos
                    opcionProcesos.Enabled = true;
                    opcionAnularComprobante.Enabled = false;
                    opcionCompras.Enabled = false;
                    // Reportes
                    opcionReportes.Enabled = true;
                    empleadosReportes.Enabled = false;
                    clientesReportes.Enabled = false;
                    productosReportes.Enabled = false;
                    kardexReportes.Enabled = false;
                    // Consultas
                    opcionConsultas.Enabled = true;
                    // Seguridad
                    opcionSeguridad.Enabled = true;
                    cambiarEstadoSeguridad.Enabled = false;

                    UsuarioSes = frmIniciarSesion.usuarioSesion;
                    Actualizar();
                }
                    
            }
            else
            {
                // Si el inicio de sesión no fue exitoso, cerrar la aplicación
                Close();
            }
        }

        private void CambiarEstadoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seguridad.FrmCambiarEstado frmCambiarEstado = new Seguridad.FrmCambiarEstado();
            frmCambiarEstado.Show();
        }

        private void CambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Asignas el nombre de usuario al formulario FrmCambiarContrasenia
            Seguridad.FrmCambiarContrasenia frmContra = new Seguridad.FrmCambiarContrasenia();
            // Reemplaza "nombreUsuario" con el valor del nombre de usuario que tienes en FrmPrincipal
            frmContra.UsuarioSesion = UsuarioSes;
            // Mostrar el formulario FrmCambiarContrasenia
            frmContra.ShowDialog();
            //frmContra.Show();
        }

        private void OpcionCliente_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmCliente frmCliente = new Mantenimiento.FrmCliente();
            frmCliente.Show();
        }

        private void OpcionProducto_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmProducto frmProducto = new Mantenimiento.FrmProducto();
            frmProducto.Show();
        }

        public void Actualizar()
        {
            tssUserPC.Text = Environment.UserName;
            tssNombreMaquina.Text = Environment.UserDomainName;
            tssNombreUsuario.Text = UsuarioSes;
            tssFecha.Text = DateTime.Now.ToString("yyyy/MM/dd");
            tssHora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void OpcionSISalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpcionVentas_Click(object sender, EventArgs e)
        {
            Procesos.frmVentas frmVent = new Procesos.frmVentas();
            frmVent.usuario = UsuarioSes;
            frmVent.ShowDialog();
            //frmVent.Show();
        }

        private void OpcionCompras_Click(object sender, EventArgs e)
        {
            Procesos.frmCompras frmComp = new Procesos.frmCompras();
            frmComp.usuario = UsuarioSes;
            frmComp.ShowDialog();
        }

        private void OpcionAnularComprobante_Click(object sender, EventArgs e)
        {
            Procesos.frmAnularComprobante frmAnula = new Procesos.frmAnularComprobante();
            frmAnula.Show();
        }

        private void OpcionProveedor_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmProveedor frmPro = new Mantenimiento.FrmProveedor();
            frmPro.Show();
        }

        private void KardexReportes_Click(object sender, EventArgs e)
        {
            Reportes.frmKardex frmKrd = new Reportes.frmKardex();
            frmKrd.Show();
        }
    }
}
