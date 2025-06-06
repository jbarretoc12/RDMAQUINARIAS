using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CAPA_NEGOCIOS.INVENTARIO;
using CAPA_DATOS.INVENTARIO;
using RDMAQUINARIAS.Properties;

namespace RDMAQUINARIAS.INVENTARIO
{
    public partial class ERP_ALM_PRODUCTOS: Form
    {
        public ERP_ALM_PRODUCTOS()
        {
            InitializeComponent();
        }
        NEG_ALM_PRODUCTOS neg = new NEG_ALM_PRODUCTOS();
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        int opc;
        private void ERP_ALM_PRODUCTOS_Load(object sender, EventArgs e)
        {
            #region LLENAR COMBO
            neg.Opcion = 1;
            neg.Criterio = "";
            neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtUm = DAT_ALM_PRODUCTOS.SP_ERP_ALM_UNIMED_LS(neg);
            fun.llenar_Combo(dtUm, cbocoUm, "deUm", "coUm");
            cbocoUm.SelectedIndex = 0;
            #endregion

            #region LLENAR MARCA AUTOCOMPLETADO
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            neg.Opcion = 1;
            neg.Criterio = "";
            neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtMarca = DAT_ALM_PRODUCTOS.SP_ERP_ALM_MARCA_LS(neg);
            for (int i = 0; i < dtMarca.Rows.Count; i++)
            {
                autoComplete.Add(dtMarca.Rows[i]["deMar"].ToString());
            }
            txtdeMar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtdeMar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtdeMar.AutoCompleteCustomSource = autoComplete;
            #endregion

            listarCajas(1, txtBuscar.Text);
            listar(1, txtBuscar.Text);
            vistaCajas();
        }
        private void listarCajas(int opcion, string criterio)
        {
            try
            {
                neg.Opcion = opcion;
                neg.Criterio = criterio;
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                neg.CoSuc = "";
                DataTable dt = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_LS(neg);

                panelListadoCaja.Controls.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string idProd = dt.Rows[i]["idProd"].ToString();
                    string coProd = dt.Rows[i]["coProd"].ToString();
                    string deProd = dt.Rows[i]["deProd"].ToString();
                    string cos_u = Convert.ToDecimal(dt.Rows[i]["cos_u"]).ToString("N0");

                    disenoCajas(panelListadoCaja, coProd, deProd, cos_u);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listar(int opcion, string criterio)
        {
            try
            {
                neg.Opcion = opcion;
                neg.Criterio = criterio;
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                neg.CoSuc = "";
                DataTable dt = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_LS(neg);
                dgvListado.DataSource = dt;

                dgvListado.Columns["idProd"].Visible = false;

                dgvListado.Columns["nro"].HeaderText = "Nro";
                dgvListado.Columns["nro"].Width = 40;
                dgvListado.Columns["coProd"].HeaderText = "Código";
                dgvListado.Columns["deProd"].HeaderText = "Descripción";
                dgvListado.Columns["deProd"].Width = 250;
                dgvListado.Columns["coUm"].HeaderText = "U.M.";
                dgvListado.Columns["coUm"].Width = 40;
                dgvListado.Columns["stockActual"].HeaderText = "Stock Actual";
                dgvListado.Columns["stockActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvListado.Columns["cos_u"].HeaderText = "Costo Unitario";
                dgvListado.Columns["cos_u"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvListado.Columns["deMar"].HeaderText = "Marca";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            listarCajas(1, txtBuscar.Text);
            listar(1, txtBuscar.Text);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opc = 1;
            txtcoProd.ReadOnly = false;
            limpiarControles(panelForm);
            vistaPanelForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            vistaCajas();
        }  
        
        private void editarRegistro_click(string titulo)
        {
            opc = 2;
            txtcoProd.ReadOnly = true;
            neg.Opcion = 2;
            neg.Criterio = titulo;
            neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            neg.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
            DataTable dt = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_LS(neg);
            if (dt.Rows.Count > 0)
            {
                
                txtcoProd.Text = dt.Rows[0]["coProd"].ToString();
                txtdeProd.Text = dt.Rows[0]["deProd"].ToString();
                cbocoUm.SelectedValue= dt.Rows[0]["coUm"].ToString();
                txtcoMar.Text= dt.Rows[0]["coMar"].ToString();
                txtdeMar.Text = dt.Rows[0]["deMar"].ToString();
                txtcos_u.Text = Convert.ToDecimal(dt.Rows[0]["cos_u"]).ToString("N2");
            }
            vistaPanelForm();
        }
        private void eliminarRegistro_click(string titulo)
        {
            try
            {
                if(MessageBox.Show("CONFIRMAR ELIMINACIÓN.", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    neg.CoProd = titulo;
                    neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    int i = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_ELIM(neg);
                    listarCajas(1, txtBuscar.Text);
                    listar(1, txtBuscar.Text);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void limpiarControles(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.Clear();
                }
                /*if (control is ComboBox cbo)
                {
                    cbo.SelectedIndex = 0;
                }*/
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                neg.Opc = opc;
                neg.CoProd = txtcoProd.Text;
                neg.DeProd = txtdeProd.Text;
                neg.CoUm = cbocoUm.SelectedValue.ToString();
                neg.CoMar = txtcoMar.Text;
                neg.Cos_u = Convert.ToDecimal(txtcos_u.Text);
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                neg.Estado = "A";
                neg.Co_usua_crea = CLASES.ERP_GLOBALES.CoUsu;
                DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_GB(neg);
                opc = 0;
                listarCajas(1,txtBuscar.Text);
                vistaCajas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtdeMar_Leave(object sender, EventArgs e)
        {
            try
            {
                if(txtdeMar.Text.Length > 0)
                {
                    neg.Opcion = 2;
                    neg.Criterio = txtdeMar.Text.Trim();
                    neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    DataTable dtMarca = DAT_ALM_PRODUCTOS.SP_ERP_ALM_MARCA_LS(neg);
                    if (dtMarca.Rows.Count > 0)
                    {
                        txtcoMar.Text = dtMarca.Rows[0]["coMar"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("LA MARCA NO ESTÁ REGISTRADO.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtcoMar.Clear();
                        txtdeMar.Clear();
                        txtdeMar.Select();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVistaCajas_Click(object sender, EventArgs e)
        {
            listarCajas(1, txtBuscar.Text);
            panelListado.Visible = !true;
            panelListadoCaja.Visible = true;
            panelListadoCaja.Dock = DockStyle.Fill;
            vistaCajas();
        }
        private void btnVistaGrid_Click(object sender, EventArgs e)
        {
            listar(1, txtBuscar.Text);
            vistaGrid();
        }
        private void vistaCajas()
        {
            panelForm.Visible = !true;
            panelListado.Visible = !true;
            panelListadoCaja.Visible = true;
            btnCancelar.Visible = !true;
            btnVistaCajas.Visible = true;
            btnVistaGrid.Visible = true;

            btnCancelar.Visible = !true;
            btnGrabar.Visible = !true;
            btnNuevo.Visible = true;

            panelListadoCaja.Dock = DockStyle.Fill;
            btnVistaCajas.BackColor = Color.FromArgb(42, 127, 184);
            btnVistaCajas.ForeColor = Color.White;
            btnVistaGrid.BackColor = Color.White;
            btnVistaGrid.ForeColor = Color.Black;
        }
        private void vistaGrid()
        {
            panelForm.Visible = !true;
            panelListado.Visible = true;
            panelListadoCaja.Visible = !true;
            panelListado.Dock = DockStyle.Fill;

            btnCancelar.Visible = !true;
            btnVistaCajas.Visible = true;
            btnVistaGrid.Visible = true;

            btnVistaCajas.BackColor = Color.White;
            btnVistaCajas.ForeColor = Color.Black;

            btnVistaGrid.BackColor = Color.FromArgb(42, 127, 184); 
            btnVistaGrid.ForeColor = Color.White;
        }
        private void vistaPanelForm()
        {
            panelForm.Visible = true;
            panelListado.Visible = !true;
            panelListadoCaja.Visible = !true;
            panelForm.Dock = DockStyle.Fill;

            btnCancelar.Visible = true;
            btnGrabar.Visible = true;
            btnNuevo.Visible = !true;

            btnVistaCajas.Visible = !true;
            btnVistaGrid.Visible = !true;
        }
        public void disenoCajas(FlowLayoutPanel panelListadoCaja, string str_titulo, string str_desc, string str_costo)
        {
            Panel pnlPrincipal;
            Panel pnlLeft;
            Panel pnlRight;
            PictureBox pbxImg;
            Label titulo;
            Label subTitulo;
            Label costo;
            Panel pnlAcciones;
            LinkLabel linkEditar;
            LinkLabel linkEliminar;
            panelListadoCaja.Padding = new Padding(5);
            panelListado.Padding = new Padding(5);

            /* for (int i = 0; i < 5; i++)
             {*/
            pnlPrincipal = new Panel();
            pnlPrincipal.Width = 300;
            pnlPrincipal.Height = 110;
            pnlPrincipal.BackColor = Color.White;
            pnlPrincipal.Padding = new Padding(5);

            #region IMAGEN
            pnlLeft = new Panel();
            pnlLeft.Width = 100;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.BackColor = Color.WhiteSmoke;
            pnlPrincipal.Controls.Add(pnlLeft);

            pbxImg = new PictureBox();
            pbxImg.Width = 100;
            pbxImg.Dock = DockStyle.Left;
            pbxImg.Image = Resources.no_fotos;
            pbxImg.SizeMode = PictureBoxSizeMode.CenterImage;
            pnlLeft.Controls.Add(pbxImg);
            #endregion


            #region DATOS PRINCIPALES
            pnlRight = new Panel();
            pnlRight.Width = 190;
            pnlRight.Dock = DockStyle.Right;
            //pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.BackColor = Color.White;
            pnlPrincipal.Controls.Add(pnlRight);


            titulo = new Label();
            titulo.Text = str_titulo; //"Titulo de Caja";
            titulo.ForeColor = Color.Gray;
            titulo.Padding = new Padding(5);
            titulo.Dock = DockStyle.Top;
            titulo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            pnlRight.Controls.Add(titulo);


            subTitulo = new Label();
            subTitulo.Text = str_desc;//"Descripción de Prueba del Producto";
            subTitulo.Padding = new Padding(5);
            subTitulo.Dock = DockStyle.Top;
            pnlRight.Controls.Add(subTitulo);

            costo = new Label();
            costo.Text = str_costo; //"50,000";
            costo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            costo.Padding = new Padding(5);
            costo.Dock = DockStyle.Top;
            pnlRight.Controls.Add(costo);


            pnlAcciones = new Panel();
            pnlAcciones.Dock = DockStyle.Top;
            pnlAcciones.Width = 190;
            pnlAcciones.Height = 30;
            pnlAcciones.Padding = new Padding(5);
            //pnlAcciones.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(pnlAcciones);


            linkEditar = new LinkLabel();
            linkEditar.Text = "Actualizar";
            linkEditar.Width = 60;
            //linkEditar.BorderStyle = BorderStyle.FixedSingle;
            linkEditar.TextAlign = ContentAlignment.MiddleRight;
            linkEditar.Dock = DockStyle.Right;
            linkEditar.LinkColor = Color.FromArgb(42, 127, 184);
            linkEditar.LinkBehavior = LinkBehavior.NeverUnderline;
            //linkEditar.Click += actualizar_click;
            string t = str_titulo;
            linkEditar.Click += (sender, e) => editarRegistro_click(t);
            pnlAcciones.Controls.Add(linkEditar);

            linkEliminar = new LinkLabel();
            linkEliminar.Text = "Eliminar";
            linkEliminar.Width = 60;
            //linkEliminar.BorderStyle = BorderStyle.FixedSingle;
            linkEliminar.TextAlign = ContentAlignment.MiddleRight;
            linkEliminar.Dock = DockStyle.Right;
            linkEliminar.LinkColor = Color.FromArgb(42, 127, 184);
            linkEliminar.LinkBehavior = LinkBehavior.NeverUnderline;
            linkEliminar.Click += (sender, e) => eliminarRegistro_click(t);
            pnlAcciones.Controls.Add(linkEliminar);

            #endregion


            pnlRight.Controls.SetChildIndex(titulo, 0);
            pnlRight.Controls.SetChildIndex(subTitulo, 0);
            pnlRight.Controls.SetChildIndex(costo, 0);
            pnlRight.Controls.SetChildIndex(pnlAcciones, 0);

            panelListadoCaja.Controls.Add(pnlPrincipal);
            /* }*/
        }


    }


}
