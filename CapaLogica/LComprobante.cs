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
    public class LComprobante
    {
        public int IdComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string NroComprobante { get; set; }
        public string FechaEmision { get; set; }
        public decimal Monto { get; set; }
        public bool Estado { get; set; }
        public string IdEmpleado { get; set; }
        public string Tipo { get; set; }
        public string IdCliente { get; set; }
        public string IdProveedor { get; set; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public bool InsertarCliente()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarComprobanteCliente", TipoComprobante, NroComprobante, FechaEmision, Monto,1,IdEmpleado, "Venta", IdCliente);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool InsertarProveedor()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarComprobanteProveedor", TipoComprobante, NroComprobante, FechaEmision, Monto, 1, IdEmpleado, "Compra", IdProveedor);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool ActualizarMontoComprobante(int IdComprobante, decimal Monto)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ActualizarMontoComprobante", IdComprobante, Monto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public string GenerarNroComprobante(string TipoComprobante)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_GenerarNumeroComprobante", TipoComprobante);
            string Codigo = oFila["NroComprobante"].ToString();
            return Codigo;
        }

        public int ObtenerIdComprobanteCreado()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ObtenerUltimoIdComprobante");
            int id = (int)oFila["IdComprobante"];
            return id;
        }

        public bool AnularComprobante(string NroComprobante)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_AnularComprobante", NroComprobante);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool ActualizarStock(string Tipo, string NroComprobante)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ActualizarStockProductos", Tipo, NroComprobante);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }
    }
}
