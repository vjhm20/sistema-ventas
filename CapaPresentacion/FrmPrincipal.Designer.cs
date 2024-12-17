namespace CapaPresentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionProveedor = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionReiniciar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionAnularComprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasDelDiaReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasEntreFechasReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.productosReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.kardexReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarEstadoSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseniaSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionSISalir = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionNOSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssUserPC = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssNombreMaquina = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssNombreUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionMantenimiento,
            this.opcionProcesos,
            this.opcionReportes,
            this.opcionConsultas,
            this.opcionSeguridad,
            this.opcionSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionMantenimiento
            // 
            this.opcionMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionEmpleado,
            this.opcionCliente,
            this.opcionProducto,
            this.opcionProveedor,
            this.opcionReiniciar});
            this.opcionMantenimiento.Name = "opcionMantenimiento";
            this.opcionMantenimiento.Size = new System.Drawing.Size(122, 24);
            this.opcionMantenimiento.Text = "Mantenimiento";
            this.opcionMantenimiento.Click += new System.EventHandler(this.MantenimientoToolStripMenuItem_Click);
            // 
            // opcionEmpleado
            // 
            this.opcionEmpleado.Name = "opcionEmpleado";
            this.opcionEmpleado.Size = new System.Drawing.Size(152, 26);
            this.opcionEmpleado.Text = "Empleado";
            this.opcionEmpleado.Click += new System.EventHandler(this.EmpleadoToolStripMenuItem_Click);
            // 
            // opcionCliente
            // 
            this.opcionCliente.Name = "opcionCliente";
            this.opcionCliente.Size = new System.Drawing.Size(152, 26);
            this.opcionCliente.Text = "Cliente";
            this.opcionCliente.Click += new System.EventHandler(this.OpcionCliente_Click);
            // 
            // opcionProducto
            // 
            this.opcionProducto.Name = "opcionProducto";
            this.opcionProducto.Size = new System.Drawing.Size(152, 26);
            this.opcionProducto.Text = "Producto";
            this.opcionProducto.Click += new System.EventHandler(this.OpcionProducto_Click);
            // 
            // opcionProveedor
            // 
            this.opcionProveedor.Name = "opcionProveedor";
            this.opcionProveedor.Size = new System.Drawing.Size(152, 26);
            this.opcionProveedor.Text = "Proveedor";
            this.opcionProveedor.Click += new System.EventHandler(this.OpcionProveedor_Click);
            // 
            // opcionReiniciar
            // 
            this.opcionReiniciar.Name = "opcionReiniciar";
            this.opcionReiniciar.Size = new System.Drawing.Size(152, 26);
            this.opcionReiniciar.Text = "Reiniciar";
            // 
            // opcionProcesos
            // 
            this.opcionProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionVentas,
            this.opcionAnularComprobante,
            this.opcionCompras});
            this.opcionProcesos.Name = "opcionProcesos";
            this.opcionProcesos.Size = new System.Drawing.Size(79, 24);
            this.opcionProcesos.Text = "Procesos";
            // 
            // opcionVentas
            // 
            this.opcionVentas.Name = "opcionVentas";
            this.opcionVentas.Size = new System.Drawing.Size(223, 26);
            this.opcionVentas.Text = "Ventas";
            this.opcionVentas.Click += new System.EventHandler(this.OpcionVentas_Click);
            // 
            // opcionAnularComprobante
            // 
            this.opcionAnularComprobante.Name = "opcionAnularComprobante";
            this.opcionAnularComprobante.Size = new System.Drawing.Size(223, 26);
            this.opcionAnularComprobante.Text = "Anular Comprobante";
            this.opcionAnularComprobante.Click += new System.EventHandler(this.OpcionAnularComprobante_Click);
            // 
            // opcionCompras
            // 
            this.opcionCompras.Name = "opcionCompras";
            this.opcionCompras.Size = new System.Drawing.Size(223, 26);
            this.opcionCompras.Text = "Compras";
            this.opcionCompras.Click += new System.EventHandler(this.OpcionCompras_Click);
            // 
            // opcionReportes
            // 
            this.opcionReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasDelDiaReportes,
            this.ventasEntreFechasReportes,
            this.empleadosReportes,
            this.productosReportes,
            this.clientesReportes,
            this.kardexReportes});
            this.opcionReportes.Name = "opcionReportes";
            this.opcionReportes.Size = new System.Drawing.Size(80, 24);
            this.opcionReportes.Text = "Reportes";
            // 
            // ventasDelDiaReportes
            // 
            this.ventasDelDiaReportes.Name = "ventasDelDiaReportes";
            this.ventasDelDiaReportes.Size = new System.Drawing.Size(216, 26);
            this.ventasDelDiaReportes.Text = "Ventas del dia";
            // 
            // ventasEntreFechasReportes
            // 
            this.ventasEntreFechasReportes.Name = "ventasEntreFechasReportes";
            this.ventasEntreFechasReportes.Size = new System.Drawing.Size(216, 26);
            this.ventasEntreFechasReportes.Text = "Ventas entre fechas";
            // 
            // empleadosReportes
            // 
            this.empleadosReportes.Name = "empleadosReportes";
            this.empleadosReportes.Size = new System.Drawing.Size(216, 26);
            this.empleadosReportes.Text = "Empleados";
            // 
            // productosReportes
            // 
            this.productosReportes.Name = "productosReportes";
            this.productosReportes.Size = new System.Drawing.Size(216, 26);
            this.productosReportes.Text = "Productos";
            // 
            // clientesReportes
            // 
            this.clientesReportes.Name = "clientesReportes";
            this.clientesReportes.Size = new System.Drawing.Size(216, 26);
            this.clientesReportes.Text = "Clientes";
            // 
            // kardexReportes
            // 
            this.kardexReportes.Name = "kardexReportes";
            this.kardexReportes.Size = new System.Drawing.Size(216, 26);
            this.kardexReportes.Text = "Kardex";
            this.kardexReportes.Click += new System.EventHandler(this.KardexReportes_Click);
            // 
            // opcionConsultas
            // 
            this.opcionConsultas.Name = "opcionConsultas";
            this.opcionConsultas.Size = new System.Drawing.Size(84, 24);
            this.opcionConsultas.Text = "Consultas";
            // 
            // opcionSeguridad
            // 
            this.opcionSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarEstadoSeguridad,
            this.cambiarContraseniaSeguridad});
            this.opcionSeguridad.Name = "opcionSeguridad";
            this.opcionSeguridad.Size = new System.Drawing.Size(89, 24);
            this.opcionSeguridad.Text = "Seguridad";
            // 
            // cambiarEstadoSeguridad
            // 
            this.cambiarEstadoSeguridad.Name = "cambiarEstadoSeguridad";
            this.cambiarEstadoSeguridad.Size = new System.Drawing.Size(243, 26);
            this.cambiarEstadoSeguridad.Text = "Cambiar Estado Usuario";
            this.cambiarEstadoSeguridad.Click += new System.EventHandler(this.CambiarEstadoUsuarioToolStripMenuItem_Click);
            // 
            // cambiarContraseniaSeguridad
            // 
            this.cambiarContraseniaSeguridad.Name = "cambiarContraseniaSeguridad";
            this.cambiarContraseniaSeguridad.Size = new System.Drawing.Size(243, 26);
            this.cambiarContraseniaSeguridad.Text = "Cambiar Contraseña";
            this.cambiarContraseniaSeguridad.Click += new System.EventHandler(this.CambiarContraseñaToolStripMenuItem_Click);
            // 
            // opcionSalir
            // 
            this.opcionSalir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionSISalir,
            this.opcionNOSalir});
            this.opcionSalir.Name = "opcionSalir";
            this.opcionSalir.Size = new System.Drawing.Size(50, 24);
            this.opcionSalir.Text = "Salir";
            this.opcionSalir.Click += new System.EventHandler(this.OpcionSalir_Click);
            // 
            // opcionSISalir
            // 
            this.opcionSISalir.Name = "opcionSISalir";
            this.opcionSISalir.Size = new System.Drawing.Size(104, 26);
            this.opcionSISalir.Text = "Si";
            this.opcionSISalir.Click += new System.EventHandler(this.OpcionSISalir_Click);
            // 
            // opcionNOSalir
            // 
            this.opcionNOSalir.Name = "opcionNOSalir";
            this.opcionNOSalir.Size = new System.Drawing.Size(104, 26);
            this.opcionNOSalir.Text = "No";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssUserPC,
            this.tssNombreMaquina,
            this.tssFecha,
            this.tssHora,
            this.tssNombreUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssUserPC
            // 
            this.tssUserPC.Name = "tssUserPC";
            this.tssUserPC.Size = new System.Drawing.Size(110, 20);
            this.tssUserPC.Text = "NombreUserPC";
            // 
            // tssNombreMaquina
            // 
            this.tssNombreMaquina.Name = "tssNombreMaquina";
            this.tssNombreMaquina.Size = new System.Drawing.Size(122, 20);
            this.tssNombreMaquina.Text = "NombreMaquina";
            // 
            // tssFecha
            // 
            this.tssFecha.Name = "tssFecha";
            this.tssFecha.Size = new System.Drawing.Size(47, 20);
            this.tssFecha.Text = "Fecha";
            // 
            // tssHora
            // 
            this.tssHora.Name = "tssHora";
            this.tssHora.Size = new System.Drawing.Size(42, 20);
            this.tssHora.Text = "Hora";
            // 
            // tssNombreUsuario
            // 
            this.tssNombreUsuario.Name = "tssNombreUsuario";
            this.tssNombreUsuario.Size = new System.Drawing.Size(139, 20);
            this.tssNombreUsuario.Text = "Nombre de Usuario";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem opcionEmpleado;
        private System.Windows.Forms.ToolStripMenuItem opcionCliente;
        private System.Windows.Forms.ToolStripMenuItem opcionProducto;
        private System.Windows.Forms.ToolStripMenuItem opcionProcesos;
        private System.Windows.Forms.ToolStripMenuItem opcionVentas;
        private System.Windows.Forms.ToolStripMenuItem opcionAnularComprobante;
        private System.Windows.Forms.ToolStripMenuItem opcionReportes;
        private System.Windows.Forms.ToolStripMenuItem opcionConsultas;
        private System.Windows.Forms.ToolStripMenuItem opcionSeguridad;
        private System.Windows.Forms.ToolStripMenuItem cambiarEstadoSeguridad;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseniaSeguridad;
        private System.Windows.Forms.ToolStripMenuItem opcionSalir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssUserPC;
        private System.Windows.Forms.ToolStripStatusLabel tssNombreMaquina;
        private System.Windows.Forms.ToolStripStatusLabel tssFecha;
        private System.Windows.Forms.ToolStripStatusLabel tssHora;
        private System.Windows.Forms.ToolStripStatusLabel tssNombreUsuario;
        private System.Windows.Forms.ToolStripMenuItem opcionProveedor;
        private System.Windows.Forms.ToolStripMenuItem ventasDelDiaReportes;
        private System.Windows.Forms.ToolStripMenuItem ventasEntreFechasReportes;
        private System.Windows.Forms.ToolStripMenuItem empleadosReportes;
        private System.Windows.Forms.ToolStripMenuItem productosReportes;
        private System.Windows.Forms.ToolStripMenuItem clientesReportes;
        private System.Windows.Forms.ToolStripMenuItem kardexReportes;
        private System.Windows.Forms.ToolStripMenuItem opcionSISalir;
        private System.Windows.Forms.ToolStripMenuItem opcionNOSalir;
        private System.Windows.Forms.ToolStripMenuItem opcionCompras;
        private System.Windows.Forms.ToolStripMenuItem opcionReiniciar;
    }
}