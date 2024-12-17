using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Mantenimiento.FrmEmpleado());
            //Application.Run(new FrmPrincipal());
            // Crear una instancia de FrmInicioSesion y FrmPrincipal
            //FrmIniciarSesion frmInicioSesion = new FrmIniciarSesion();
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.Show();
            //Consultas.frmBuscarProducto frm = new Consultas.frmBuscarProducto();
            //frm.Show();
            //Procesos.frmVentas frmven = new Procesos.frmVentas();
            //frmven.Show();

            Application.Run();
        }
    }
}
