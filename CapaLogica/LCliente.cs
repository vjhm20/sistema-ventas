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
    public class LCliente
    {
        // Atributos
        string idCliente;
        string nombre;
        string tipoCliente;
        string dni;
        string ruc;
        string email;
        string direccion;
        byte[] foto;

        // Metodos get y set
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string TipoCliente { get => tipoCliente; set => tipoCliente = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public byte[] Foto { get => foto; set => foto = value; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public bool Insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarCliente", idCliente, nombre, tipoCliente, dni, ruc, email, direccion, foto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ActualizarCliente", idCliente, nombre, tipoCliente, dni, ruc, email, direccion, foto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_EliminarCliente", idCliente);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("usp_ListarClientes");
        }

        public DataTable Buscar(string Campo, string Contenido)
        {
            return oDatos.TraerDataTable("usp_BuscarCliente", Campo, Contenido);
        }

        public string GenerarCodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_GenerarCodigoCliente");
            string Codigo = oFila["Codigo"].ToString();
            return Codigo;
        }

        public byte[] ObtenerFoto()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerFotoCliente", idCliente);
            byte[] foto = (byte[])oFila["Foto"];
            return foto;
        }

        public bool ExisteCliente()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ExisteCliente", idCliente);
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public void MostrarCliente(string Id)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerClientePorId", Id);
            idCliente = oFila["IdCliente"].ToString();
            nombre = oFila["Nombre"].ToString();
            tipoCliente = oFila["TipoCliente"].ToString();
            dni = oFila["DNI"].ToString();
            ruc = oFila["RUC"].ToString();
            email = oFila["Email"].ToString();
            direccion = oFila["Direccion"].ToString();
            foto = (byte[])oFila["Foto"];         
        }
    }
}
