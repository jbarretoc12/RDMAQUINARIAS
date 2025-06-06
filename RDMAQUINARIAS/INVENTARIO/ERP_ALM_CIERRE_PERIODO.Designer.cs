namespace RDMAQUINARIAS.INVENTARIO
{
    partial class ERP_ALM_CIERRE_PERIODO
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
            this.panelNav = new System.Windows.Forms.Panel();
            this.pnlVistas = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.flowBotonMeses = new System.Windows.Forms.FlowLayoutPanel();
            this.panelNav.SuspendLayout();
            this.pnlVistas.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.pnlVistas);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 44);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(308, 29);
            this.panelNav.TabIndex = 22;
            // 
            // pnlVistas
            // 
            this.pnlVistas.Controls.Add(this.btnCerrar);
            this.pnlVistas.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlVistas.Location = new System.Drawing.Point(43, 0);
            this.pnlVistas.Name = "pnlVistas";
            this.pnlVistas.Size = new System.Drawing.Size(265, 29);
            this.pnlVistas.TabIndex = 28;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(145, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 29);
            this.btnCerrar.TabIndex = 27;
            this.btnCerrar.Text = "X Cerrar Formulario";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(308, 44);
            this.panelTitle.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cerrar Periodo";
            // 
            // cboAnio
            // 
            this.cboAnio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboAnio.BackColor = System.Drawing.Color.White;
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(14, 83);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(134, 21);
            this.cboAnio.TabIndex = 68;
            this.cboAnio.SelectionChangeCommitted += new System.EventHandler(this.cboAnio_SelectionChangeCommitted);
            // 
            // button15
            // 
            this.button15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button15.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(7, 80);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(146, 27);
            this.button15.TabIndex = 67;
            this.button15.UseVisualStyleBackColor = true;
            // 
            // flowBotonMeses
            // 
            this.flowBotonMeses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowBotonMeses.Location = new System.Drawing.Point(6, 114);
            this.flowBotonMeses.Name = "flowBotonMeses";
            this.flowBotonMeses.Size = new System.Drawing.Size(295, 247);
            this.flowBotonMeses.TabIndex = 69;
            // 
            // ERP_ALM_CIERRE_PERIODO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 368);
            this.Controls.Add(this.flowBotonMeses);
            this.Controls.Add(this.cboAnio);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ERP_ALM_CIERRE_PERIODO";
            this.Text = "ERP_ALM_CIERRE_PERIODO";
            this.Load += new System.EventHandler(this.ERP_ALM_CIERRE_PERIODO_Load);
            this.panelNav.ResumeLayout(false);
            this.pnlVistas.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel pnlVistas;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.FlowLayoutPanel flowBotonMeses;
    }
}