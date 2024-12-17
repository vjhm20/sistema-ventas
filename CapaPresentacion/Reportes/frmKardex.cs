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

namespace CapaPresentacion.Reportes
{
    public partial class frmKardex : Form
    {
        // -- Atributos
        LProducto oProducto = new LProducto();
        public frmKardex()
        {
            InitializeComponent();
        }

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            dgvKardex.DataSource = oProducto.Kardex();
        }
    }
}
