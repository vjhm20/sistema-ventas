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
    public class LProducto
    {
        // Atributos
        string idProducto;
        string denominacion;
        int cantidad;
        decimal precioUnitario;
        int stockInicial;
        int stockActual;

        // Métodos get y set
        public string IdProducto { get => idProducto; set => idProducto = value; }
        public string Denominacion { get => denominacion; set => denominacion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int StockInicial { get => stockInicial; set => stockInicial = value; }
        public int StockActual { get => stockActual; set => stockActual = value; }

        cDatos oDatos = new cDatosSQL();

        public string Mensaje;

        public bool Insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_InsertarProducto", idProducto, denominacion, cantidad, precioUnitario, stockInicial, stockActual);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ActualizarProducto", idProducto, denominacion, cantidad, precioUnitario, stockInicial, stockActual);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public bool Eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_EliminarProducto", idProducto);
            Mensaje = oFila["Mensaje"].ToString();
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("usp_ListarProductos");
        }

        public DataTable Buscar(string Campo, string Contenido)
        {
            return oDatos.TraerDataTable("usp_BuscarProducto", Campo, Contenido);
        }

        public string GenerarCodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_GenerarCodigoProducto");
            string Codigo = oFila["Codigo"].ToString();
            return Codigo;
        }

        public bool ExisteProducto()
        {
            DataRow oFila = oDatos.TraerDataRow("usp_ExisteProducto", idProducto);
            byte CodError = Convert.ToByte(oFila["CodError"]);
            if (CodError == 1)
                return true;
            else
                return false;
        }

        public DataTable Kardex()
        {
            return oDatos.TraerDataTable("usp_ListarKardexCompleto");
        }
    }
}
