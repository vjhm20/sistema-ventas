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
    public class LProveedor
    {
        string idProveedor;
        string razonSocial;
        string ruc;
        string direccion;
        string telefono;
        string correo;
        string fechaInscripcion;
        int estado;

        public string IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string RUC { get => ruc; set => ruc = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public int Estado { get => estado; set => estado = value; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public bool Insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarProveedor", idProveedor, razonSocial, ruc, direccion, telefono, correo, fechaInscripcion, estado);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            return CodError == 1;
        }

        public bool Modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ActualizarProveedor", idProveedor, razonSocial, ruc, direccion, telefono, correo, fechaInscripcion, estado);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            return CodError == 1;
        }

        public bool Eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_EliminarProveedor", idProveedor);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            return CodError == 1;
        }

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("usp_ListarProveedores");
        }

        public DataTable Buscar(string Campo, string Contenido)
        {
            return oDatos.TraerDataTable("usp_BuscarProveedor", Campo, Contenido);
        }

        public string GenerarCodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_GenerarCodigoProveedor");
            string Codigo = oFila["Codigo"].ToString();
            return Codigo;
        }

        public bool ExisteProveedor()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ExisteProveedor", idProveedor);
            byte CodError = Convert.ToByte(oFila["CodError"]);
            return CodError == 1;
        }

        public bool ExisteProveedorPorRUC(string RUC)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ExisteProveedorPorRUC", RUC);
            byte CodError = Convert.ToByte(oFila["CodError"]);
            return CodError == 1;
        }

        public void MostrarProveedor(string IdProveedor)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerProveedorPorId", IdProveedor);
            idProveedor = oFila["IdProveedor"].ToString();
            razonSocial = oFila["RazonSocial"].ToString();
            ruc = oFila["RUC"].ToString();
            direccion = oFila["Direccion"].ToString();
            telefono = oFila["Telefono"].ToString();
            correo = oFila["Correo"].ToString();
            fechaInscripcion = oFila["FechaInscripcion"].ToString();
            estado = Convert.ToByte(oFila["Estado"]);
        }

        public void MostrarProveedorPorRUC(string RUC)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerProveedorPorRUC", RUC);
            idProveedor = oFila["IdProveedor"].ToString();
            razonSocial = oFila["RazonSocial"].ToString();
            ruc = oFila["RUC"].ToString();
            direccion = oFila["Direccion"].ToString();
            telefono = oFila["Telefono"].ToString();
            correo = oFila["Correo"].ToString();
            fechaInscripcion = oFila["FechaInscripcion"].ToString();
            estado = Convert.ToByte(oFila["Estado"]);
        }
    }
}
