using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaLogica
{
    public class LUsuario
    {
        // Atributos
        string usuario;
        string contrasenia;
        bool estado;
        string idEmpleado;

        // Metodos get y set
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("usp_ListarUsuarios");
        }

        public bool IniciarSesion(string Usuario, string Contrasenia)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_IniciarSesion", Usuario, Contrasenia);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool CambiarContrasenia(string Usuario ,string ContraseniaActual, string NuevaContrasenia)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_CambiarContrasenia", Usuario, ContraseniaActual, NuevaContrasenia);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool CambiarEstadoUsuario(string IdEmpleado, int NuevoEstado)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_CambiarEstadoUsuario", IdEmpleado, NuevoEstado);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public string RecuperarNombreUsuario(string IdEmpleado)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_RecuperarNombreUsuario", IdEmpleado);
            string nombre = oFila["NombreUsuario"].ToString();
            return nombre;
        }

        public string RecuperarCargoUsuario(string Usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerCargoPorUsuario", Usuario);
            string nombre = oFila["Cargo"].ToString();
            return nombre;
        }

        public void MostrarUsuario(string Usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_MostrarUsuarioPorUsuario", Usuario);
            usuario = oFila["Usuario"].ToString();
            int est = (bool)oFila["Estado"] ? 1 : 0;
            if (est == 1)
                estado = true;
            else
                estado = false;            
            idEmpleado = oFila["IdEmpleado"].ToString();
        }

        public bool MostrarEstado(string Usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_MostrarUsuarioPorUsuario", Usuario);
            int est = (bool)oFila["Estado"] ? 1 : 0;
            if (est == 1)
                return true;
            else
                return false;
        }

        public string MostrarIdEmpleado(string Usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_MostrarUsuarioPorUsuario", Usuario);
            string Id = oFila["IdEmpleado"].ToString();
            return Id;
        }
        public DataTable Buscar(string Campo, string Contenido)
        {
            return oDatos.TraerDataTable("usp_BuscarUsuario", Campo, Contenido);
        }
    }
}
