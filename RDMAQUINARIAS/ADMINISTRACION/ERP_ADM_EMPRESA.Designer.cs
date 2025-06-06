
namespace RDMAQUINARIAS.ADMINISTRACION
{
    partial class ERP_ADM_EMPRESA
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxCab = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvSucursal = new System.Windows.Forms.DataGridView();
            this.txtnombreArchivo = new System.Windows.Forms.TextBox();
            this.chkestado = new System.Windows.Forms.CheckBox();
            this.btnExaminarLogo = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.pbximgEmp = new System.Windows.Forms.PictureBox();
            this.txturlEmp = new System.Windows.Forms.TextBox();
            this.txttelEmp = new System.Windows.Forms.TextBox();
            this.txtdirEmp = new System.Windows.Forms.TextBox();
            this.txtcomEmp = new System.Windows.Forms.TextBox();
            this.txtnoEmp = new System.Windows.Forms.TextBox();
            this.txtrucEmp = new System.Windows.Forms.TextBox();
            this.txtcoEmp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbxListado = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblReg = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnSel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEditarFila = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbxCab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbximgEmp)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbxListado.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(80, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(731, 379);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxCab);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(723, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GESTIONAR EMPRESA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbxCab
            // 
            this.gbxCab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCab.Controls.Add(this.btnAdd);
            this.gbxCab.Controls.Add(this.label10);
            this.gbxCab.Controls.Add(this.label9);
            this.gbxCab.Controls.Add(this.dgvSucursal);
            this.gbxCab.Controls.Add(this.txtnombreArchivo);
            this.gbxCab.Controls.Add(this.chkestado);
            this.gbxCab.Controls.Add(this.btnExaminarLogo);
            this.gbxCab.Controls.Add(this.txtRuta);
            this.gbxCab.Controls.Add(this.pbximgEmp);
            this.gbxCab.Controls.Add(this.txturlEmp);
            this.gbxCab.Controls.Add(this.txttelEmp);
            this.gbxCab.Controls.Add(this.txtdirEmp);
            this.gbxCab.Controls.Add(this.txtcomEmp);
            this.gbxCab.Controls.Add(this.txtnoEmp);
            this.gbxCab.Controls.Add(this.txtrucEmp);
            this.gbxCab.Controls.Add(this.txtcoEmp);
            this.gbxCab.Controls.Add(this.label8);
            this.gbxCab.Controls.Add(this.label7);
            this.gbxCab.Controls.Add(this.label6);
            this.gbxCab.Controls.Add(this.label5);
            this.gbxCab.Controls.Add(this.label4);
            this.gbxCab.Controls.Add(this.label3);
            this.gbxCab.Controls.Add(this.label2);
            this.gbxCab.Controls.Add(this.label1);
            this.gbxCab.Location = new System.Drawing.Point(3, -2);
            this.gbxCab.Name = "gbxCab";
            this.gbxCab.Size = new System.Drawing.Size(716, 347);
            this.gbxCab.TabIndex = 1;
            this.gbxCab.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(665, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 24);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "Sedes:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(473, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Estado:";
            // 
            // dgvSucursal
            // 
            this.dgvSucursal.AllowUserToAddRows = false;
            this.dgvSucursal.BackgroundColor = System.Drawing.Color.White;
            this.dgvSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.coSuc,
            this.noSuc,
            this.telSuc,
            this.dirSuc,
            this.estado,
            this.btnEditarFila});
            this.dgvSucursal.Location = new System.Drawing.Point(24, 211);
            this.dgvSucursal.Name = "dgvSucursal";
            this.dgvSucursal.ReadOnly = true;
            this.dgvSucursal.RowTemplate.Height = 19;
            this.dgvSucursal.Size = new System.Drawing.Size(640, 128);
            this.dgvSucursal.TabIndex = 20;
            this.dgvSucursal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursal_CellContentClick);
            // 
            // txtnombreArchivo
            // 
            this.txtnombreArchivo.Location = new System.Drawing.Point(475, 39);
            this.txtnombreArchivo.Name = "txtnombreArchivo";
            this.txtnombreArchivo.Size = new System.Drawing.Size(35, 22);
            this.txtnombreArchivo.TabIndex = 19;
            this.txtnombreArchivo.Visible = false;
            // 
            // chkestado
            // 
            this.chkestado.AutoSize = true;
            this.chkestado.Location = new System.Drawing.Point(476, 170);
            this.chkestado.Name = "chkestado";
            this.chkestado.Size = new System.Drawing.Size(34, 18);
            this.chkestado.TabIndex = 18;
            this.chkestado.Text = "--";
            this.chkestado.UseVisualStyleBackColor = true;
            this.chkestado.CheckedChanged += new System.EventHandler(this.chkestado_CheckedChanged);
            // 
            // btnExaminarLogo
            // 
            this.btnExaminarLogo.Location = new System.Drawing.Point(621, 38);
            this.btnExaminarLogo.Name = "btnExaminarLogo";
            this.btnExaminarLogo.Size = new System.Drawing.Size(75, 24);
            this.btnExaminarLogo.TabIndex = 17;
            this.btnExaminarLogo.Text = "Examinar";
            this.btnExaminarLogo.UseVisualStyleBackColor = true;
            this.btnExaminarLogo.Click += new System.EventHandler(this.btnExaminarLogo_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(475, 39);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(145, 22);
            this.txtRuta.TabIndex = 16;
            // 
            // pbximgEmp
            // 
            this.pbximgEmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbximgEmp.Image = global::RDMAQUINARIAS.Properties.Resources.no_fotos;
            this.pbximgEmp.Location = new System.Drawing.Point(475, 63);
            this.pbximgEmp.Name = "pbximgEmp";
            this.pbximgEmp.Size = new System.Drawing.Size(221, 83);
            this.pbximgEmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbximgEmp.TabIndex = 15;
            this.pbximgEmp.TabStop = false;
            // 
            // txturlEmp
            // 
            this.txturlEmp.Location = new System.Drawing.Point(199, 168);
            this.txturlEmp.Name = "txturlEmp";
            this.txturlEmp.Size = new System.Drawing.Size(271, 22);
            this.txturlEmp.TabIndex = 14;
            // 
            // txttelEmp
            // 
            this.txttelEmp.Location = new System.Drawing.Point(24, 168);
            this.txttelEmp.Name = "txttelEmp";
            this.txttelEmp.Size = new System.Drawing.Size(172, 22);
            this.txttelEmp.TabIndex = 13;
            // 
            // txtdirEmp
            // 
            this.txtdirEmp.Location = new System.Drawing.Point(24, 124);
            this.txtdirEmp.Name = "txtdirEmp";
            this.txtdirEmp.Size = new System.Drawing.Size(446, 22);
            this.txtdirEmp.TabIndex = 12;
            // 
            // txtcomEmp
            // 
            this.txtcomEmp.Location = new System.Drawing.Point(24, 81);
            this.txtcomEmp.Name = "txtcomEmp";
            this.txtcomEmp.Size = new System.Drawing.Size(446, 22);
            this.txtcomEmp.TabIndex = 11;
            // 
            // txtnoEmp
            // 
            this.txtnoEmp.Location = new System.Drawing.Point(199, 39);
            this.txtnoEmp.Name = "txtnoEmp";
            this.txtnoEmp.Size = new System.Drawing.Size(271, 22);
            this.txtnoEmp.TabIndex = 10;
            // 
            // txtrucEmp
            // 
            this.txtrucEmp.Location = new System.Drawing.Point(80, 39);
            this.txtrucEmp.Name = "txtrucEmp";
            this.txtrucEmp.Size = new System.Drawing.Size(116, 22);
            this.txtrucEmp.TabIndex = 9;
            // 
            // txtcoEmp
            // 
            this.txtcoEmp.Location = new System.Drawing.Point(24, 39);
            this.txtcoEmp.Name = "txtcoEmp";
            this.txtcoEmp.Size = new System.Drawing.Size(53, 22);
            this.txtcoEmp.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(473, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "Logo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(197, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Página Web:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Teléfono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre Comercial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Razón Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "R.U.C.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbxListado);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(723, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LISTA DE EMPRESAS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbxListado
            // 
            this.gbxListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxListado.Controls.Add(this.statusStrip1);
            this.gbxListado.Controls.Add(this.dgvDatos);
            this.gbxListado.Controls.Add(this.txtFiltro);
            this.gbxListado.Location = new System.Drawing.Point(4, -3);
            this.gbxListado.Name = "gbxListado";
            this.gbxListado.Size = new System.Drawing.Size(719, 350);
            this.gbxListado.TabIndex = 1;
            this.gbxListado.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblReg});
            this.statusStrip1.Location = new System.Drawing.Point(3, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(713, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Registros:";
            // 
            // lblReg
            // 
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(17, 17);
            this.lblReg.Text = "--";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSel});
            this.dgvDatos.Location = new System.Drawing.Point(5, 36);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 19;
            this.dgvDatos.Size = new System.Drawing.Size(708, 285);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // btnSel
            // 
            this.btnSel.HeaderText = "Select";
            this.btnSel.Name = "btnSel";
            this.btnSel.Text = "Select";
            this.btnSel.ToolTipText = "Select";
            this.btnSel.UseColumnTextForButtonValue = true;
            this.btnSel.Width = 50;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(4, 10);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(709, 22);
            this.txtFiltro.TabIndex = 0;
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
            this.pnlMenu.Location = new System.Drawing.Point(0, 43);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(80, 379);
            this.pnlMenu.TabIndex = 9;
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuditoria.Location = new System.Drawing.Point(0, 150);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(80, 25);
            this.btnAuditoria.TabIndex = 6;
            this.btnAuditoria.Text = "Auditoría";
            this.btnAuditoria.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImprimir.Location = new System.Drawing.Point(0, 125);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(80, 25);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCancelar.Location = new System.Drawing.Point(0, 100);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 25);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminar.Location = new System.Drawing.Point(0, 75);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 25);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditar.Location = new System.Drawing.Point(0, 50);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 25);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrabar.Location = new System.Drawing.Point(0, 25);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(80, 25);
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
            this.btnNuevo.Size = new System.Drawing.Size(80, 25);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(811, 43);
            this.pnlTitulo.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 20;
            // 
            // coSuc
            // 
            this.coSuc.HeaderText = "Cod.";
            this.coSuc.Name = "coSuc";
            this.coSuc.ReadOnly = true;
            this.coSuc.Width = 30;
            // 
            // noSuc
            // 
            this.noSuc.HeaderText = "Sucursal";
            this.noSuc.Name = "noSuc";
            this.noSuc.ReadOnly = true;
            this.noSuc.Width = 150;
            // 
            // telSuc
            // 
            this.telSuc.HeaderText = "Teléfono";
            this.telSuc.Name = "telSuc";
            this.telSuc.ReadOnly = true;
            // 
            // dirSuc
            // 
            this.dirSuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dirSuc.HeaderText = "Dirección";
            this.dirSuc.Name = "dirSuc";
            this.dirSuc.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 50;
            // 
            // btnEditarFila
            // 
            this.btnEditarFila.HeaderText = "btnEditarFila";
            this.btnEditarFila.Name = "btnEditarFila";
            this.btnEditarFila.ReadOnly = true;
            this.btnEditarFila.Text = "Editar";
            this.btnEditarFila.UseColumnTextForButtonValue = true;
            this.btnEditarFila.Width = 60;
            // 
            // ERP_ADM_EMPRESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 422);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ERP_ADM_EMPRESA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ERP_ADM_EMPRESA";
            this.Load += new System.EventHandler(this.ERP_ADM_EMPRESA_Load);
            this.Shown += new System.EventHandler(this.ERP_ADM_EMPRESA_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbxCab.ResumeLayout(false);
            this.gbxCab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbximgEmp)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gbxListado.ResumeLayout(false);
            this.gbxListado.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbxCab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbxListado;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblReg;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.DataGridViewButtonColumn btnSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.PictureBox pbximgEmp;
        private System.Windows.Forms.TextBox txturlEmp;
        private System.Windows.Forms.TextBox txttelEmp;
        private System.Windows.Forms.TextBox txtdirEmp;
        private System.Windows.Forms.TextBox txtcomEmp;
        private System.Windows.Forms.TextBox txtnoEmp;
        private System.Windows.Forms.TextBox txtrucEmp;
        private System.Windows.Forms.TextBox txtcoEmp;
        private System.Windows.Forms.Button btnExaminarLogo;
        private System.Windows.Forms.CheckBox chkestado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtnombreArchivo;
        private System.Windows.Forms.DataGridView dgvSucursal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn coSuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn noSuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn telSuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirSuc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estado;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditarFila;
    }
}