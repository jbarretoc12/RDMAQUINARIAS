namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFlowModulos = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::RDMAQUINARIAS.Properties.Resources.no_fotos;
            this.pictureBox1.Location = new System.Drawing.Point(691, 252);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 67);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelFlowModulos
            // 
            this.panelFlowModulos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelFlowModulos.Location = new System.Drawing.Point(160, 68);
            this.panelFlowModulos.Name = "panelFlowModulos";
            this.panelFlowModulos.Size = new System.Drawing.Size(437, 251);
            this.panelFlowModulos.TabIndex = 1;
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(167, 39);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(424, 16);
            this.txtFiltro.TabIndex = 2;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(160, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(437, 30);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(769, 331);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelFlowModulos);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO";
            this.Activated += new System.EventHandler(this.ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO_FormClosing);
            this.Load += new System.EventHandler(this.ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel panelFlowModulos;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button button1;
    }
}