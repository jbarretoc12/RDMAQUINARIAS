
namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_PERMISOS
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.coUsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noUsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.txtnoUsu = new System.Windows.Forms.TextBox();
            this.btnPrivilegios = new System.Windows.Forms.Button();
            this.trvPermisos = new System.Windows.Forms.TreeView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.cbocoEmp = new System.Windows.Forms.ComboBox();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.ColumnHeadersVisible = false;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coUsu,
            this.noUsu,
            this.coSuc});
            this.dgvUsuarios.Location = new System.Drawing.Point(348, 53);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.Size = new System.Drawing.Size(252, 119);
            this.dgvUsuarios.TabIndex = 31;
            this.dgvUsuarios.Visible = false;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // coUsu
            // 
            this.coUsu.HeaderText = "coUsu";
            this.coUsu.Name = "coUsu";
            this.coUsu.ReadOnly = true;
            this.coUsu.Visible = false;
            // 
            // noUsu
            // 
            this.noUsu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noUsu.HeaderText = "noUsu";
            this.noUsu.Name = "noUsu";
            this.noUsu.ReadOnly = true;
            // 
            // coSuc
            // 
            this.coSuc.HeaderText = "coSuc";
            this.coSuc.Name = "coSuc";
            this.coSuc.ReadOnly = true;
            this.coSuc.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "USUARIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "SEDE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "EMPRESA:";
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(348, 33);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(12, 21);
            this.txtUsu.TabIndex = 21;
            this.txtUsu.Visible = false;
            // 
            // txtnoUsu
            // 
            this.txtnoUsu.Location = new System.Drawing.Point(350, 33);
            this.txtnoUsu.Name = "txtnoUsu";
            this.txtnoUsu.Size = new System.Drawing.Size(250, 21);
            this.txtnoUsu.TabIndex = 27;
            this.txtnoUsu.TextChanged += new System.EventHandler(this.txtnoUsu_TextChanged);
            // 
            // btnPrivilegios
            // 
            this.btnPrivilegios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrivilegios.Location = new System.Drawing.Point(607, 529);
            this.btnPrivilegios.Name = "btnPrivilegios";
            this.btnPrivilegios.Size = new System.Drawing.Size(179, 23);
            this.btnPrivilegios.TabIndex = 26;
            this.btnPrivilegios.Text = "Privilegios de Formulario";
            this.btnPrivilegios.UseVisualStyleBackColor = true;
            // 
            // trvPermisos
            // 
            this.trvPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvPermisos.CheckBoxes = true;
            this.trvPermisos.Location = new System.Drawing.Point(5, 60);
            this.trvPermisos.Name = "trvPermisos";
            this.trvPermisos.Size = new System.Drawing.Size(703, 433);
            this.trvPermisos.TabIndex = 24;
            this.trvPermisos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvPermisos_NodeMouseDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(601, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 24);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Ver Permisos";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(181, 33);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(164, 21);
            this.cboSucursal.TabIndex = 22;
            // 
            // cbocoEmp
            // 
            this.cbocoEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocoEmp.Enabled = false;
            this.cbocoEmp.FormattingEnabled = true;
            this.cbocoEmp.Location = new System.Drawing.Point(6, 33);
            this.cbocoEmp.Name = "cbocoEmp";
            this.cbocoEmp.Size = new System.Drawing.Size(172, 21);
            this.cbocoEmp.TabIndex = 20;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(788, 40);
            this.pnlTitulo.TabIndex = 32;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnAuditoria);
            this.pnlMenu.Controls.Add(this.btnImprimir);
            this.pnlMenu.Controls.Add(this.btnCancelar);
            this.pnlMenu.Controls.Add(this.btnEliminar);
            this.pnlMenu.Controls.Add(this.btnEditar);
            this.pnlMenu.Controls.Add(this.btnGrabar);
            this.pnlMenu.Controls.Add(this.btnNuevo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 40);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(60, 526);
            this.pnlMenu.TabIndex = 33;
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuditoria.Location = new System.Drawing.Point(0, 138);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(60, 23);
            this.btnAuditoria.TabIndex = 6;
            this.btnAuditoria.Text = "Auditoría";
            this.btnAuditoria.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImprimir.Location = new System.Drawing.Point(0, 115);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 23);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCancelar.Location = new System.Drawing.Point(0, 92);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminar.Location = new System.Drawing.Point(0, 69);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditar.Location = new System.Drawing.Point(0, 46);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrabar.Location = new System.Drawing.Point(0, 23);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevo.Location = new System.Drawing.Point(0, 0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(60, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 526);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(720, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PERMISOS DE USUARIO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboSucursal);
            this.groupBox1.Controls.Add(this.txtUsu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtnoUsu);
            this.groupBox1.Controls.Add(this.dgvUsuarios);
            this.groupBox1.Controls.Add(this.cbocoEmp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trvPermisos);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 499);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // ERP_SOP_PERMISOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(788, 566);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.btnPrivilegios);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ERP_SOP_PERMISOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ERP_PRI_PERMISOS";
            this.Load += new System.EventHandler(this.ERP_PRI_PERMISOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn coUsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn noUsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn coSuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.TextBox txtnoUsu;
        private System.Windows.Forms.Button btnPrivilegios;
        private System.Windows.Forms.TreeView trvPermisos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.ComboBox cbocoEmp;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}