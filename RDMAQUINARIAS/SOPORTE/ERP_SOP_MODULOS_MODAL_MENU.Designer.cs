namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_MODULOS_MODAL_MENU
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
            this.txtnuOrd = new System.Windows.Forms.TextBox();
            this.txtnoMenu = new System.Windows.Forms.TextBox();
            this.txtcoMenu = new System.Windows.Forms.TextBox();
            this.chkForm = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cbocoMod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtnuOrd
            // 
            this.txtnuOrd.Location = new System.Drawing.Point(79, 124);
            this.txtnuOrd.Name = "txtnuOrd";
            this.txtnuOrd.Size = new System.Drawing.Size(51, 21);
            this.txtnuOrd.TabIndex = 18;
            this.txtnuOrd.Text = "0";
            // 
            // txtnoMenu
            // 
            this.txtnoMenu.Location = new System.Drawing.Point(79, 100);
            this.txtnoMenu.Name = "txtnoMenu";
            this.txtnoMenu.Size = new System.Drawing.Size(333, 21);
            this.txtnoMenu.TabIndex = 17;
            // 
            // txtcoMenu
            // 
            this.txtcoMenu.Enabled = false;
            this.txtcoMenu.Location = new System.Drawing.Point(79, 76);
            this.txtcoMenu.Name = "txtcoMenu";
            this.txtcoMenu.Size = new System.Drawing.Size(159, 21);
            this.txtcoMenu.TabIndex = 16;
            // 
            // chkForm
            // 
            this.chkForm.AutoSize = true;
            this.chkForm.Location = new System.Drawing.Point(136, 126);
            this.chkForm.Name = "chkForm";
            this.chkForm.Size = new System.Drawing.Size(102, 17);
            this.chkForm.TabIndex = 15;
            this.chkForm.Text = "Es un formulario";
            this.chkForm.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Orden:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Menu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Codigo:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(161, 18);
            this.lblTitulo.TabIndex = 11;
            this.lblTitulo.Text = "NUEVO REGISTRO MENU";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(283, 168);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(129, 26);
            this.btnGrabar.TabIndex = 19;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cbocoMod
            // 
            this.cbocoMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocoMod.Enabled = false;
            this.cbocoMod.FormattingEnabled = true;
            this.cbocoMod.Location = new System.Drawing.Point(79, 52);
            this.cbocoMod.Name = "cbocoMod";
            this.cbocoMod.Size = new System.Drawing.Size(333, 21);
            this.cbocoMod.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Modulo:";
            // 
            // ERP_SOP_MODULOS_MODAL_MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbocoMod);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtnuOrd);
            this.Controls.Add(this.txtnoMenu);
            this.Controls.Add(this.txtcoMenu);
            this.Controls.Add(this.chkForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ERP_SOP_MODULOS_MODAL_MENU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP_SOP_MODULOS_MODAL_MENU";
            this.Load += new System.EventHandler(this.ERP_SOP_MODULOS_MODAL_MENU_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtnuOrd;
        private System.Windows.Forms.TextBox txtnoMenu;
        private System.Windows.Forms.TextBox txtcoMenu;
        private System.Windows.Forms.CheckBox chkForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox cbocoMod;
        private System.Windows.Forms.Label label1;
    }
}