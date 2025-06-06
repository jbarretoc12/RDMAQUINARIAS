
namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_MENUPRINCIPAL_GENERAL
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
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panelModulosText = new System.Windows.Forms.Panel();
            this.lblnoMod = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.panelModulosText.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnuPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuPrincipal.Location = new System.Drawing.Point(182, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuPrincipal.Size = new System.Drawing.Size(674, 34);
            this.mnuPrincipal.TabIndex = 1;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.mnuPrincipal);
            this.pnlMenu.Controls.Add(this.panelModulosText);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(856, 34);
            this.pnlMenu.TabIndex = 3;
            // 
            // panelModulosText
            // 
            this.panelModulosText.Controls.Add(this.lblnoMod);
            this.panelModulosText.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelModulosText.Location = new System.Drawing.Point(0, 0);
            this.panelModulosText.Name = "panelModulosText";
            this.panelModulosText.Size = new System.Drawing.Size(182, 34);
            this.panelModulosText.TabIndex = 0;
            // 
            // lblnoMod
            // 
            this.lblnoMod.AutoSize = true;
            this.lblnoMod.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnoMod.Location = new System.Drawing.Point(6, 6);
            this.lblnoMod.Name = "lblnoMod";
            this.lblnoMod.Size = new System.Drawing.Size(16, 23);
            this.lblnoMod.TabIndex = 0;
            this.lblnoMod.Text = "-";
            // 
            // ERP_SOP_MENUPRINCIPAL_GENERAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 389);
            this.Controls.Add(this.pnlMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "ERP_SOP_MENUPRINCIPAL_GENERAL";
            this.Text = "ERP_SOP_MENUPRINCIPAL_GENERAL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ERP_PRI_MENUPRINCIPAL_FormClosing);
            this.Load += new System.EventHandler(this.ERP_PRI_MENUPRINCIPAL_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.panelModulosText.ResumeLayout(false);
            this.panelModulosText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panelModulosText;
        private System.Windows.Forms.Label lblnoMod;
    }
}