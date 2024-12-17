namespace CapaPresentacion.Reportes
{
    partial class frmKardex
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
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(215, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 36);
            this.label10.TabIndex = 1;
            this.label10.Text = "Kardex";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(204, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 60);
            this.panel1.TabIndex = 2;
            // 
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardex.Location = new System.Drawing.Point(56, 153);
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.RowTemplate.Height = 24;
            this.dgvKardex.Size = new System.Drawing.Size(861, 240);
            this.dgvKardex.TabIndex = 3;
            // 
            // frmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 432);
            this.Controls.Add(this.dgvKardex);
            this.Controls.Add(this.panel1);
            this.Name = "frmKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKardex";
            this.Load += new System.EventHandler(this.FrmKardex_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvKardex;
    }
}