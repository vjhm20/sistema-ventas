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
    public class LEmpleado
    {
        // Atributos
        string idEmpleado;
        string nombre;
        string dni;
        string fechaNacimiento;
        string email;
        string direccion;
        string telefono;
        string cargo;
        byte[] foto;

        // Metodos get y set
        public string IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public byte[] Foto { get => foto; set => foto = value; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public bool Insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarEmpleado", idEmpleado, nombre, dni, fechaNacimiento, email, direccion, telefono, cargo, foto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ActualizarEmpleado", idEmpleado, nombre, dni, fechaNacimiento, email, direccion, telefono, cargo, foto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_EliminarEmpleado", idEmpleado);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("usp_ListarEmpleados");
        }

        public DataTable Buscar(string Campo, string Contenido)
        {
            return oDatos.TraerDataTable("usp_BuscarEmpleado", Campo, Contenido);
        }

        public string GenerarCodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_GenerarCodigoEmpleado");
            string Codigo = oFila["Codigo"].ToString();
            return Codigo;
        }

        public byte[] ObtenerFoto()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerFotoEmpleado", idEmpleado);
            byte[] foto = (byte[])oFila["Foto"];
            return foto;
        }

        public bool ExisteEmpleado()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ExisteEmpleado", idEmpleado);
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public void MostrarEmpleado(string IdEmpleado)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerEmpleadoPorId", IdEmpleado);
            idEmpleado = oFila["IdEmpleado"].ToString();
            nombre = oFila["Nombre"].ToString();
            dni = oFila["DNI"].ToString();
            fechaNacimiento = oFila["FechaNacimiento"].ToString();
            email = oFila["Email"].ToString();
            direccion = oFila["Direccion"].ToString();
            telefono = oFila["Telefono"].ToString();
            cargo = oFila["Cargo"].ToString();
            foto = (byte[])oFila["Foto"];
        }
    }
}
