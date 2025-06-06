
namespace RDMAQUINARIAS.SOPORTE
{
    partial class ERP_SOP_PRINCIPAL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvModulos = new System.Windows.Forms.DataGridView();
            this.nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAcceder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaPeriodo = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvModulos);
            this.panel1.Location = new System.Drawing.Point(6, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 309);
            this.panel1.TabIndex = 1;
            // 
            // dgvModulos
            // 
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.AllowUserToResizeRows = false;
            this.dgvModulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModulos.BackgroundColor = System.Drawing.Color.White;
            this.dgvModulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulos.ColumnHeadersVisible = false;
            this.dgvModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nro,
            this.coMod,
            this.noMod,
            this.btnAcceder});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(27)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModulos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvModulos.Location = new System.Drawing.Point(5, 6);
            this.dgvModulos.Name = "dgvModulos";
            this.dgvModulos.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(27)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvModulos.RowHeadersVisible = false;
            this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulos.Size = new System.Drawing.Size(392, 298);
            this.dgvModulos.TabIndex = 6;
            this.dgvModulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModulos_CellContentClick);
            // 
            // nro
            // 
            this.nro.HeaderText = "nro";
            this.nro.Name = "nro";
            this.nro.ReadOnly = true;
            this.nro.Width = 30;
            // 
            // coMod
            // 
            this.coMod.HeaderText = "coMod";
            this.coMod.Name = "coMod";
            this.coMod.ReadOnly = true;
            this.coMod.Visible = false;
            // 
            // noMod
            // 
            this.noMod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noMod.HeaderText = "noMod";
            this.noMod.Name = "noMod";
            this.noMod.ReadOnly = true;
            // 
            // btnAcceder
            // 
            this.btnAcceder.HeaderText = "btnAcceder";
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.ReadOnly = true;
            this.btnAcceder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnAcceder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnAcceder.Text = "Abrir";
            this.btnAcceder.ToolTipText = "Abrir";
            this.btnAcceder.UseColumnTextForButtonValue = true;
            this.btnAcceder.Width = 50;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(288, 371);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 35);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir del Sistema";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Principal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FECHA PERIODO:";
            // 
            // dtpFechaPeriodo
            // 
            this.dtpFechaPeriodo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPeriodo.Location = new System.Drawing.Point(103, 35);
            this.dtpFechaPeriodo.Margin = new System.Windows.Forms.Padding(8);
            this.dtpFechaPeriodo.Name = "dtpFechaPeriodo";
            this.dtpFechaPeriodo.Size = new System.Drawing.Size(104, 22);
            this.dtpFechaPeriodo.TabIndex = 5;
            this.dtpFechaPeriodo.Value = new System.DateTime(2024, 3, 25, 11, 50, 38, 0);
            // 
            // ERP_SOP_PRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 409);
            this.ControlBox = false;
            this.Controls.Add(this.dtpFechaPeriodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ERP_SOP_PRINCIPAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP_SOP_PRINCIPAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ERP_SOP_PRINCIPAL_FormClosing);
            this.Load += new System.EventHandler(this.ERP_SOP_PRINCIPAL_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvModulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro;
        private System.Windows.Forms.DataGridViewTextBoxColumn coMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn noMod;
        private System.Windows.Forms.DataGridViewButtonColumn btnAcceder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaPeriodo;
    }
}