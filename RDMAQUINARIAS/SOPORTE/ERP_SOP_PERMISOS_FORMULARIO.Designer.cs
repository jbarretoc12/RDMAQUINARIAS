namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_PERMISOS_FORMULARIO
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
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.chkGrabar = new System.Windows.Forms.CheckBox();
            this.chkEditar = new System.Windows.Forms.CheckBox();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.chkReporte = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(375, 40);
            this.pnlTitulo.TabIndex = 6;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnCancelar);
            this.pnlMenu.Controls.Add(this.btnGrabar);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenu.Location = new System.Drawing.Point(0, 128);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(375, 36);
            this.pnlMenu.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(294, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Location = new System.Drawing.Point(217, 6);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(269, 51);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(100, 21);
            this.txtCod.TabIndex = 8;
            this.txtCod.Visible = false;
            // 
            // txtNom
            // 
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(80, 51);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(289, 21);
            this.txtNom.TabIndex = 9;
            // 
            // chkGrabar
            // 
            this.chkGrabar.AutoSize = true;
            this.chkGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGrabar.Location = new System.Drawing.Point(117, 78);
            this.chkGrabar.Name = "chkGrabar";
            this.chkGrabar.Size = new System.Drawing.Size(63, 18);
            this.chkGrabar.TabIndex = 10;
            this.chkGrabar.Text = "Grabar";
            this.chkGrabar.UseVisualStyleBackColor = true;
            // 
            // chkEditar
            // 
            this.chkEditar.AutoSize = true;
            this.chkEditar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEditar.Location = new System.Drawing.Point(117, 102);
            this.chkEditar.Name = "chkEditar";
            this.chkEditar.Size = new System.Drawing.Size(58, 18);
            this.chkEditar.TabIndex = 11;
            this.chkEditar.Text = "Editar";
            this.chkEditar.UseVisualStyleBackColor = true;
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEliminar.Location = new System.Drawing.Point(203, 78);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(72, 18);
            this.chkEliminar.TabIndex = 12;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            // 
            // chkReporte
            // 
            this.chkReporte.AutoSize = true;
            this.chkReporte.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReporte.Location = new System.Drawing.Point(203, 102);
            this.chkReporte.Name = "chkReporte";
            this.chkReporte.Size = new System.Drawing.Size(69, 18);
            this.chkReporte.TabIndex = 13;
            this.chkReporte.Text = "Reporte";
            this.chkReporte.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignar Permisos al Formulario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Formulario:";
            // 
            // ERP_SOP_PERMISOS_FORMULARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(375, 164);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkReporte);
            this.Controls.Add(this.chkEliminar);
            this.Controls.Add(this.chkEditar);
            this.Controls.Add(this.chkGrabar);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.txtNom);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ERP_SOP_PERMISOS_FORMULARIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP_SOP_PERMISOS_FORMULARIO";
            this.Load += new System.EventHandler(this.ERP_SOP_PERMISOS_FORMULARIO_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.CheckBox chkGrabar;
        private System.Windows.Forms.CheckBox chkEditar;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.CheckBox chkReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}