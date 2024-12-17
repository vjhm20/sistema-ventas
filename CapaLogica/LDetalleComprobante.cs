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
    public class LDetalleComprobante
    {
        public int IdDetalle { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdComprobante { get; set; }
        public string IdProducto { get; set; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public DataTable Listar(string IdComprobante)
        {
            return oDatos.TraerDataTable("usp_ListarDetalleComprobante",IdComprobante);
        }

        public bool Insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarDetalleComprobante", Cantidad, PrecioUnitario, IdComprobante, IdProducto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Eliminar(int IdDetalle)
        {
            DataRow oFila = oDatos.TraerDataRow("usp_EliminarDetalleComprobante", IdDetalle);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public DataTable ListarProductos(int IdComprobante)
        {
            return oDatos.TraerDataTable("usp_ListarProductosPorComprobante", IdComprobante);
        }
    }
}
