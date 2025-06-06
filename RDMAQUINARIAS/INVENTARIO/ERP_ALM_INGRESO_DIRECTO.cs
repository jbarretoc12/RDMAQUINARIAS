using CAPA_DATOS;
using CAPA_DATOS.COMPRAS;
using CAPA_DATOS.INVENTARIO;
using CAPA_NEGOCIOS.COMPRAS;
using CAPA_NEGOCIOS.INVENTARIO;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDMAQUINARIAS.INVENTARIO
{
    public partial class ERP_ALM_INGRESO_DIRECTO: Form
    {
        public ERP_ALM_INGRESO_DIRECTO()
        {
            InitializeComponent();
        }
        NEG_ALM_PRODUCTOS neg = new NEG_ALM_PRODUCTOS();
        NEG_ALM_ALMACENES negAlmacen = new NEG_ALM_ALMACENES();
        NEG_ALM_INGRESO_DIRECTO negAlm = new NEG_ALM_INGRESO_DIRECTO();
        NEG_ALM_OPERACIONES negOpe = new NEG_ALM_OPERACIONES();
        NEG_COM_SOLICITUD_PEDIDO negCom = new NEG_COM_SOLICITUD_PEDIDO();
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        SqlConnection cn = new SqlConnection(Conexion.cadena);
        string coOpe;
        string tiMov;
        int opc;
        private void ERP_ALM_INGRESO_COMPRA_Load(object sender, EventArgs e)
        {
            #region LLENAR COMBO
            /*negOpe.Opcion = 0;
            negOpe.Criterio = "";
            negOpe.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtSer = DAT_ALM_OPERACIONES.SP_ERP_ALM_NUMERADOR_LS(negOpe);
            fun.llenar_Combo(dtSer, cboseNum, "deNum", "seNum");*/

            negAlmacen.Opcion = 0;
            negAlmacen.Criterio = "";
            negAlmacen.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
            negAlmacen.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtAlmacen= DAT_ALM_ALMACENES.SP_ERP_ALM_ALMACENES_LS(negAlmacen);
            fun.llenar_Combo(dtAlmacen, cbocoAlm, "deAlm", "coAlm");
            cbocoAlm.SelectedIndex = 0;

            cbocoMon.SelectedIndex = 0;
            #endregion

            listarGrid(1, txtBuscar.Text, "I");
            vistaGrid();
        }
        private void vistaGrid()
        {

            /*#region CAMBIO DE COLOR
            btnVistaGrid.BackColor = Color.FromArgb(42, 127, 184);
            btnVistaGrid.ForeColor = Color.White;
            btnVistaGrid.FlatAppearance.BorderColor = Color.FromArgb(42, 127, 184);
            #endregion*/

            panelForm.Visible = !true;
            panelListado.Visible = true;
            panelListado.Dock = DockStyle.Fill;

        }
        private void listarGrid(int opcion, string criterio,string tiMov)
        {
            try
            {
                negAlm.Opcion = opcion;
                negAlm.Criterio = criterio;
                negAlm.TiMov = tiMov;
                negAlm.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negAlm.CoSuc = "";
                DataTable dt = DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_MOVIMIENTO_CAB_LS(negAlm);
                dgvListado.DataSource = dt;

                dgvListado.Columns["nro"].HeaderText = "Nro.";
                dgvListado.Columns["nro"].Width = 40;

                dgvListado.Columns["nuMov"].HeaderText = "Correlativo";
                dgvListado.Columns["nuMov"].Width = 120;

                dgvListado.Columns["deNum"].HeaderText = "Movimiento";
                dgvListado.Columns["deNum"].Width = 150;

                dgvListado.Columns["feMov"].HeaderText = "Fecha Movimiento";
                dgvListado.Columns["feMov"].Width = 90;

                dgvListado.Columns["deProvCli"].HeaderText = "Cliente";
                dgvListado.Columns["deProvCli"].Width = 250;

                dgvListado.Columns["nuDocRef"].HeaderText = "Doc. Referencia";
                dgvListado.Columns["nuDocRef"].Width = 100;

                dgvListado.Columns["coProy"].HeaderText = "Proyecto";
                dgvListado.Columns["coProy"].Width = 100;

                /*for (int i = 1; i < dgvListado.Columns.Count; i++)
                {
                    dgvListado.Columns[i].ReadOnly = true;
                }
                dgvListado.Columns["idPed"].Visible = false;
                dgvListado.Columns["Nro."].Width = 40;
                dgvListado.Columns["nuPed"].Width = 90;
                dgvListado.Columns["nuPed"].HeaderText = "Referencia";

                dgvListado.Columns["deProvCli"].Width = 250;
                dgvListado.Columns["deProvCli"].HeaderText = "Proveedor";

                dgvListado.Columns["co_usua_crea"].Width = 100;
                dgvListado.Columns["co_usua_crea"].HeaderText = "Responsable de compra";

                dgvListado.Columns["fePed"].Width = 80;
                dgvListado.Columns["fePed"].HeaderText = "Fecha Doc.";
                dgvListado.Columns["fePed"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvListado.Columns["feRec"].Width = 80;
                dgvListado.Columns["feRec"].HeaderText = "Fecha límite pedido";
                dgvListado.Columns["feRec"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvListado.Columns["coMon"].Width = 40;
                dgvListado.Columns["coMon"].HeaderText = "Mon.";

                dgvListado.Columns["imp_t_nac"].HeaderText = "Total";
                dgvListado.Columns["imp_t_nac"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvListado.Columns["btnEditarCol"].HeaderText = "-";
                //dgvListado.Columns["btnEditarCol"].DefaultCellStyle=de*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opc = 1;
            txtcoProvCli.ReadOnly = false;

            #region MOSTRAR SELCCION DE OPERACIONES
            panelOperaciones.Dock = DockStyle.Fill;
            panelOperaciones.Visible = true;
            listarOperacionesFlowIngreso();
            #endregion


            fun.habilidarControles(panelForm, tabControlDetalle, true);
            fun.lipiarControles(panelForm, tabControlDetalle, true);
            vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
            vistaFormulario();
            panelNav.Visible = false;

            txtnuMov.Text = "[Nuevo]";
        }
        private void listarOperacionesFlowIngreso()
        {
            try
            {
                Button btn;
                negOpe.Opcion = 0;
                negOpe.Criterio = "I";
                negOpe.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtOpe = DAT_ALM_OPERACIONES.SP_ERP_ALM_OPERACIONES_LS(negOpe);
                flowOperacionesIng.Controls.Clear();
                for (int i = 0; i < dtOpe.Rows.Count; i++)
                {
                    btn = new Button();
                    btn.Name = dtOpe.Rows[i]["coOpe"].ToString();
                    btn.Text = dtOpe.Rows[i]["deOpe"].ToString();
                    btn.Width = 120;
                    btn.Height = 80;
                    btn.Click += new EventHandler(btnSeleccionarOperacionIngreso_Click);
                    flowOperacionesIng.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionarOperacionIngreso_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            coOpe = btn.Name;
            tiMov = "I";

            //cboseNum.SelectedValue = coOpe;

            negOpe.Opcion = 1;
            negOpe.Criterio = coOpe;
            negOpe.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtSer = DAT_ALM_OPERACIONES.SP_ERP_ALM_NUMERADOR_LS(negOpe);
            fun.llenar_Combo(dtSer, cboseNum, "deNum", "seNum");

            panelNav.Visible = true;
            panelOperaciones.Visible = false;
        }
        public void vistaBotones(int opc, Panel pnl, Button btnNuevo, Button btnGrabar, Button btnEditar, Button btnCancelar, Button btnImprimir)
        {
            foreach (Control panel in pnl.Controls)
            {
                if (panel is Button btn)
                {
                    btn.Visible = false;
                }
            }

            if (opc == 0) //ver
            {
                btnCancelar.Visible = true;
                //btnEditar.Visible = true;
                btnImprimir.Visible = true;

                //pnl.Controls.SetChildIndex(btnEditar, 0);
                pnl.Controls.SetChildIndex(btnImprimir, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);

            }
            else if (opc == 1) //nuevo
            {
                btnCancelar.Visible = true;
                btnGrabar.Visible = true;

                pnl.Controls.SetChildIndex(btnGrabar, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);
            }
            else if (opc == 2)//editar
            {
                btnCancelar.Visible = true;
                btnGrabar.Visible = true;

                pnl.Controls.SetChildIndex(btnGrabar, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);
            }
            else //inicio
            {
                btnNuevo.Visible = true;
            }
        }
        private void vistaFormulario()
        {
            panelForm.Visible = true;
            panelListado.Visible = !true;
            panelForm.Dock = DockStyle.Fill;

            fun.habilitarBotonesVista(/*btnVistaCajas, btnVistaGrid,*/ btnBuscar, txtBuscar, false);
        }
        private void txtcoProvCli_Leave(object sender, EventArgs e)
        {
            if (txtcoProvCli.Text.Trim() != "")
            {
                negCom.Opcion = 0;
                negCom.Criterio = txtcoProvCli.Text;
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dt = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_PROVCLI_LS(negCom);
                if (dt.Rows.Count > 0)
                {
                    txtdeProvCli.Text = dt.Rows[0]["deProvCli"].ToString();
                }
                else
                {
                    MessageBox.Show("PROVEEDOR N1O EXISTE.", "Sistema");
                    txtdeProvCli.Clear();
                    txtcoProvCli.Select();
                    return;
                }
            }
            else
            {
                txtdeProvCli.Clear();
            }
        }
        private void dgvDetProductos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "coProdP")
                {
                    agregarFilaProducto(dgvDetProductos.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregarFilaProducto(int fila)
        {
            try
            {
                if (dgvDetProductos.Rows[fila].Cells["coProdP"].Value == null
                    || dgvDetProductos.Rows[fila].Cells["coProdP"].Value.ToString() == "")
                {
                    dgvDetProductos.Rows[fila].Cells["idMovDetP"].Value = "0";
                    dgvDetProductos.Rows[fila].Cells["itemP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["coProdP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["deProdP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["cantP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["coUmP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["cos_u_nacP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["cos_t_nacP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["deObsP"].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvDetProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "coProdP"
                    || dgvDetProductos.Columns[e.ColumnIndex].Name == "cantP"
                    || dgvDetProductos.Columns[e.ColumnIndex].Name == "cos_u_nacP"
                    )
                {
                    dgvDetProductos.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvDetProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "coProdP")
                {
                    if (dgvDetProductos.Rows[e.RowIndex].Cells["coProdP"].Value != null || dgvDetProductos.Rows[e.RowIndex].Cells["coProdP"].Value.ToString() != "")
                    {
                        neg.Opc = 0;
                        neg.Criterio = dgvDetProductos.Rows[e.RowIndex].Cells["coProdP"].Value.ToString();
                        neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        neg.CoSuc = "";
                        DataTable dtP = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_LS(neg);
                        if (dtP.Rows.Count > 0)
                        {
                            dgvDetProductos.Rows[e.RowIndex].Cells["itemP"].Value = (e.RowIndex + 1);
                            dgvDetProductos.Rows[e.RowIndex].Cells["deProdP"].Value = dtP.Rows[0]["deProd"].ToString();
                            dgvDetProductos.Rows[e.RowIndex].Cells["coUmP"].Value = dtP.Rows[0]["coUm"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("PRODUCTO NO REGISTRADO.", " Sistema");
                            dgvDetProductos.Rows[e.RowIndex].Cells["coProdP"].Value = "";
                            dgvDetProductos.Rows[e.RowIndex].Cells["deProdP"].Value = "";
                        }
                    }
                }


                if ((e.RowIndex) != dgvDetProductos.Rows.Count - 1)
                {
                    #region CALCULOS POR FILA
                    if (dgvDetProductos.Columns[e.ColumnIndex].Name == "cos_u_nacP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "cantP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "cos_t_nacP")
                    {
                        decimal cos_u_nac = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["cos_u_nacP"].Value);
                        decimal cant = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["cantP"].Value);
                        decimal precioXcant = precioXcantidad(cos_u_nac, cant);

                        dgvDetProductos.Rows[e.RowIndex].Cells["cos_t_nacP"].Value = precioXcant;
                        sumarTotales();
                    }




                   /* if (dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_d_nacP")
                    {
                        #region CALCULAR PORCENTAJE DECUENTO (DESDE EL IMPORTE DCTO)
                        decimal imp_u_nac = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["imp_u_nacP"].Value);
                        decimal cant = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["cantP"].Value);
                        decimal precioXcant = precioXcantidad(imp_u_nac, cant);
                        decimal imp_d_nac = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["imp_d_nacP"].Value);
                        decimal porDcto = porcentajeDecuento(precioXcant, imp_d_nac);
                        decimal imp_n_nac = importeTotal(precioXcant, imp_d_nac);
                        decimal porImpP = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porImpP"].Value);
                        decimal imp_i_nac = impuesto(imp_n_nac, porImpP);
                        decimal imp_t_nac = precioVentaTotal(imp_n_nac, imp_i_nac);

                        dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value = porDcto;
                        #endregion

                        dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value = Convert.ToDecimal(porDcto);
                        dgvDetProductos.Rows[e.RowIndex].Cells["imp_t_nacP"].Value = imp_t_nac;
                        sumarTotales();
                    }*/
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void sumarTotales()
        {
            try
            {
                decimal totProductos = 0;
                for (int i = 0; i < dgvDetProductos.Rows.Count - 1; i++)
                {
                    totProductos += Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["cos_t_nacP"].Value);
                }

                decimal total = (totProductos);
                txtcos_t_nac.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region FUNCIONES
        public static decimal precioXcantidad(decimal precioUnitario, decimal cantdad)
        {
            return precioUnitario * cantdad;
        }
        public static decimal importeDecuento(decimal precioTotal, decimal porDcto)
        {
            return Math.Round(precioTotal * porDcto, 2);
        }
        public static decimal porcentajeDecuento(decimal precioTotal, decimal importeDescuento)
        {
            return Math.Round(importeDescuento / precioTotal, 6);
        }
        public static decimal importeTotal(decimal precioTotal, decimal importeDecuento)
        {
            return Math.Round(precioTotal - importeDecuento, 2);
        }
        public static decimal impuesto(decimal importeNeto, decimal porImp)
        {
            return importeNeto * (porImp/* / 100*/);
        }
        public static decimal precioVentaTotal(decimal importeNeto, decimal importeImpuesto)
        {
            return importeNeto + importeImpuesto;
        }

        #endregion

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvListado.Columns[e.ColumnIndex].Name == "btnEditarCol")
                {
                    string nuMov = dgvListado.CurrentRow.Cells["nuMov"].Value.ToString();
                    opc = 2;
                    listarCabeceraParaFormulario(nuMov);
                    fun.habilidarControles(panelForm, tabControlDetalle, true);
                    dgvDetProductos.AllowUserToAddRows = true;
                    vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
                    vistaFormulario();
                }
                if (dgvListado.Columns[e.ColumnIndex].Name == "btnVer")
                {

                    string nuMov = dgvListado.CurrentRow.Cells["nuMov"].Value.ToString();
                    opc = 0;
                    fun.habilidarControles(panelForm, tabControlDetalle, false);
                    dgvDetProductos.AllowUserToAddRows = false;
                    vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
                    listarCabeceraParaFormulario(nuMov);
                    vistaFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listarCabeceraParaFormulario(string nuMov)
        {
            #region LISTAR CABECERA
            negAlm.Opcion = 0;
            negAlm.Criterio = nuMov;
            negAlm.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            negAlm.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
            DataTable dt = DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_MOVIMIENTO_CAB_LS(negAlm);
            if (dt.Rows.Count > 0)
            {
                #region LLENAR COMBO SERIE
                negOpe.Opcion = 1;
                negOpe.Criterio = dt.Rows[0]["coOpe"].ToString();
                negOpe.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtSer = DAT_ALM_OPERACIONES.SP_ERP_ALM_NUMERADOR_LS(negOpe);
                fun.llenar_Combo(dtSer, cboseNum, "deNum", "seNum");
                #endregion


                cboseNum.SelectedValue= dt.Rows[0]["seNum"].ToString();
                txtnumero.Text= dt.Rows[0]["numero"].ToString();
                txtnuMov.Text= dt.Rows[0]["nuMov"].ToString();
                dtpfeMov.Value = Convert.ToDateTime(dt.Rows[0]["feMov"]);
                dtpfeRef.Value = Convert.ToDateTime(dt.Rows[0]["feRef"]);
                cbocoAlm.SelectedValue= dt.Rows[0]["coAlm"].ToString();
                if (dt.Rows[0]["coMon"].ToString() == "D")
                {
                    cbocoMon.Text = "DOLARES";
                }
                else
                {
                    cbocoMon.Text = "SOLES";
                }
                txtcoProvCli.Text= dt.Rows[0]["coProvCli"].ToString();
                txtdeProvCli.Text= dt.Rows[0]["deProvCli"].ToString();
                txtdeObsInt.Text = dt.Rows[0]["deObsInt"].ToString();
                txtdeObsProv.Text = dt.Rows[0]["deObsProv"].ToString();
                txtcos_t_nac.Text = Math.Round(Convert.ToDecimal(dt.Rows[0]["cos_t_nac"]), 2).ToString();
                txttcVen.Text = dt.Rows[0]["tcVen"].ToString();
                txtnuDocRef.Text=dt.Rows[0]["nuDocRef"].ToString();
                txtcoProy.Text = dt.Rows[0]["coProy"].ToString();


                #region LISTAR DETALLE PRODUCTOS
                negAlm.Opcion = 0;
                negAlm.Criterio = txtnuMov.Text;
                negAlm.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtDetPro = DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_MOVIMIENTO_DET_LS(negAlm);
                dgvDetProductos.Rows.Clear();
                for (int i = 0; i < dtDetPro.Rows.Count; i++)
                {
                    dgvDetProductos.Rows.Add();
                    dgvDetProductos.Rows[i].Cells["idMovDetP"].Value = dtDetPro.Rows[i]["idMovDet"].ToString();
                    dgvDetProductos.Rows[i].Cells["itemP"].Value = dtDetPro.Rows[i]["item"].ToString();
                    dgvDetProductos.Rows[i].Cells["coProdP"].Value = dtDetPro.Rows[i]["coProd"].ToString();
                    dgvDetProductos.Rows[i].Cells["deProdP"].Value = dtDetPro.Rows[i]["deProd"].ToString();
                    dgvDetProductos.Rows[i].Cells["cantP"].Value = dtDetPro.Rows[i]["cant"].ToString();
                    dgvDetProductos.Rows[i].Cells["coUmP"].Value = dtDetPro.Rows[i]["coUm"].ToString();
                    dgvDetProductos.Rows[i].Cells["cos_u_nacP"].Value = dtDetPro.Rows[i]["cos_u_nac"].ToString();
                    dgvDetProductos.Rows[i].Cells["cos_t_nacP"].Value = dtDetPro.Rows[i]["cos_t_nac"].ToString();
                    dgvDetProductos.Rows[i].Cells["deObsP"].Value = dtDetPro.Rows[i]["deObs"].ToString();
                }
                #endregion

                #region LISTAR DETALLE SERVICIOS

                #endregion
            }
            #endregion
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opc = -1;
            vistaGrid();
            vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                opc = 2;
                fun.habilidarControles(panelForm, tabControlDetalle, true);
                dgvDetProductos.AllowUserToAddRows = true;
                vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            grabar();
        }
        private void grabar()
        {
            try
            {
                if (opc == 1)
                {
                    negAlm.Opc = opc;
                    negAlm.SeNum = cboseNum.SelectedValue.ToString();
                    negAlm.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    int i = Convert.ToInt32(DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_NUMERADOR_GENERAR(negAlm).Rows[0]["num"]);
                    txtnumero.Text = i.ToString("00000000");
                    txtnuMov.Text = coOpe + "-" + cboseNum.SelectedValue.ToString() + "-" + txtnumero.Text;
                }

                SqlCommand cmdc = new SqlCommand("SP_ERP_ALM_MOVIMIENTO_CAB_GB", cn);
                cmdc.CommandType = CommandType.StoredProcedure;
                cmdc.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                cmdc.Parameters.Add("@coOpe", SqlDbType.Char).Value = coOpe;
                cmdc.Parameters.Add("@seNum", SqlDbType.Char).Value = cboseNum.SelectedValue.ToString();
                cmdc.Parameters.Add("@numero", SqlDbType.Char).Value = txtnumero.Text;
                cmdc.Parameters.Add("@nuMov", SqlDbType.VarChar).Value = txtnuMov.Text;
                cmdc.Parameters.Add("@coProvCli", SqlDbType.VarChar).Value = txtcoProvCli.Text;
                cmdc.Parameters.Add("@tiMov", SqlDbType.Char).Value = tiMov;
                if (cbocoMon.Text == "DOLARES") { 
                    cmdc.Parameters.Add("@coMon", SqlDbType.Char).Value = "D";
                }
                else
                {
                    cmdc.Parameters.Add("@coMon", SqlDbType.Char).Value = "S";
                }
                cmdc.Parameters.Add("@tcVen", SqlDbType.Decimal).Value = Convert.ToDecimal(txttcVen.Text);
                cmdc.Parameters.Add("@feMov", SqlDbType.DateTime).Value = dtpfeMov.Value;
                cmdc.Parameters.Add("@feRef", SqlDbType.DateTime).Value = dtpfeRef.Value;
                cmdc.Parameters.Add("@origen", SqlDbType.Char).Value = "A";
                cmdc.Parameters.Add("@coAlm", SqlDbType.Char).Value = cbocoAlm.SelectedValue.ToString();
                cmdc.Parameters.Add("@coAlmDes", SqlDbType.Char).Value = DBNull.Value;
                cmdc.Parameters.Add("@coProy", SqlDbType.VarChar).Value = txtcoProy.Text;
                cmdc.Parameters.Add("@cos_t_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(txtcos_t_nac.Text);
                cmdc.Parameters.Add("@deObsInt", SqlDbType.VarChar).Value = txtdeObsInt.Text;
                cmdc.Parameters.Add("@deObsProv", SqlDbType.VarChar).Value = txtdeObsProv.Text;
                cmdc.Parameters.Add("@nuDocRef", SqlDbType.Char).Value = "";
                cmdc.Parameters.Add("@estado", SqlDbType.Char).Value = "A";
                cmdc.Parameters.Add("@co_usua_crea", SqlDbType.VarChar).Value = CLASES.ERP_GLOBALES.CoUsu;
                cmdc.Parameters.Add("@coEmp", SqlDbType.Char).Value = CLASES.ERP_GLOBALES.CoEmp;
                cn.Open();
                cmdc.ExecuteNonQuery();
                cn.Close();

                #region DETALLE PRODUCTOS
                for (int i = 0; i < dgvDetProductos.Rows.Count - 1; i++)
                {
                    SqlCommand cmdd = new SqlCommand("SP_ERP_ALM_MOVIMIENTO_DET_GB", cn);
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.Add("@idMovDet", SqlDbType.Int).Value = Convert.ToInt32(dgvDetProductos.Rows[i].Cells["idMovDetP"].Value);
                    cmdd.Parameters.Add("@item", SqlDbType.Int).Value = Convert.ToInt32(dgvDetProductos.Rows[i].Cells["itemP"].Value);
                    cmdd.Parameters.Add("@nuMov", SqlDbType.VarChar).Value = txtnuMov.Text;
                    cmdd.Parameters.Add("@tipoBien", SqlDbType.Char).Value = "B";
                    cmdd.Parameters.Add("@coProd", SqlDbType.VarChar).Value = dgvDetProductos.Rows[i].Cells["coProdP"].Value.ToString();
                    cmdd.Parameters.Add("@cant", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["cantP"].Value);
                    cmdd.Parameters.Add("@cos_u_nac", SqlDbType.Char).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["cos_u_nacP"].Value);
                    cmdd.Parameters.Add("@cos_t_nac", SqlDbType.Char).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["cos_t_nacP"].Value);
                    cmdd.Parameters.Add("@deObs", SqlDbType.Char).Value = dgvDetProductos.Rows[i].Cells["deObsP"].Value.ToString();
                    cn.Open();
                    cmdd.ExecuteNonQuery();
                    cn.Close();
                }
                #endregion


                opc = 0;
                listarGrid(1, txtBuscar.Text, "I");
                vistaGrid();
                vistaBotones(-1, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
