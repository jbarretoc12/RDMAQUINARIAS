namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_MODULOS_MODAL_MODULO
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkForm = new System.Windows.Forms.CheckBox();
            this.txtcoMod = new System.Windows.Forms.TextBox();
            this.txtnoMod = new System.Windows.Forms.TextBox();
            this.txtnuOrd = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(14, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(118, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "NUEVO REGISTRO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modulo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Orden:";
            // 
            // chkForm
            // 
            this.chkForm.AutoSize = true;
            this.chkForm.Location = new System.Drawing.Point(138, 103);
            this.chkForm.Name = "chkForm";
            this.chkForm.Size = new System.Drawing.Size(102, 17);
            this.chkForm.TabIndex = 4;
            this.chkForm.Text = "Es un formulario";
            this.chkForm.UseVisualStyleBackColor = true;
            // 
            // txtcoMod
            // 
            this.txtcoMod.Enabled = false;
            this.txtcoMod.Location = new System.Drawing.Point(81, 53);
            this.txtcoMod.Name = "txtcoMod";
            this.txtcoMod.Size = new System.Drawing.Size(159, 21);
            this.txtcoMod.TabIndex = 5;
            // 
            // txtnoMod
            // 
            this.txtnoMod.Location = new System.Drawing.Point(81, 77);
            this.txtnoMod.Name = "txtnoMod";
            this.txtnoMod.Size = new System.Drawing.Size(333, 21);
            this.txtnoMod.TabIndex = 6;
            // 
            // txtnuOrd
            // 
            this.txtnuOrd.Location = new System.Drawing.Point(81, 101);
            this.txtnuOrd.Name = "txtnuOrd";
            this.txtnuOrd.Size = new System.Drawing.Size(51, 21);
            this.txtnuOrd.TabIndex = 7;
            this.txtnuOrd.Text = "0";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(279, 140);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(135, 23);
            this.btnGrabar.TabIndex = 11;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // ERP_SOP_MODULOS_MODAL_MODULO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 175);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtnuOrd);
            this.Controls.Add(this.txtnoMod);
            this.Controls.Add(this.txtcoMod);
            this.Controls.Add(this.chkForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ERP_SOP_MODULOS_MODAL_MODULO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP_SOP_MODULOS_MODAL_MODULO";
            this.Load += new System.EventHandler(this.ERP_SOP_MODULOS_MODAL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkForm;
        private System.Windows.Forms.TextBox txtcoMod;
        private System.Windows.Forms.TextBox txtnoMod;
        private System.Windows.Forms.TextBox txtnuOrd;
        private System.Windows.Forms.Button btnGrabar;
    }
}