namespace RDMAQUINARIAS.COMPRAS
{
    partial class ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtdeProd = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicios";
            // 
            // txtdeProd
            // 
            this.txtdeProd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdeProd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdeProd.Location = new System.Drawing.Point(20, 41);
            this.txtdeProd.Name = "txtdeProd";
            this.txtdeProd.Size = new System.Drawing.Size(358, 15);
            this.txtdeProd.TabIndex = 58;
            this.txtdeProd.TextChanged += new System.EventHandler(this.txtdeProd_TextChanged);
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(11, 35);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(376, 27);
            this.button12.TabIndex = 57;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSel});
            this.dgvServicios.Location = new System.Drawing.Point(11, 65);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.Size = new System.Drawing.Size(475, 283);
            this.dgvServicios.TabIndex = 59;
            this.dgvServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellContentClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(388, 34);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(99, 28);
            this.btnNuevo.TabIndex = 60;
            this.btnNuevo.Text = "Nuevo Servicio";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSel
            // 
            this.btnSel.HeaderText = "btnSel";
            this.btnSel.Name = "btnSel";
            this.btnSel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnSel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnSel.Text = "Seleccionar";
            this.btnSel.UseColumnTextForButtonValue = true;
            this.btnSel.Width = 80;
            // 
            // ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 379);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.txtdeProd);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS";
            this.Load += new System.EventHandler(this.ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdeProd;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewButtonColumn btnSel;
    }
}