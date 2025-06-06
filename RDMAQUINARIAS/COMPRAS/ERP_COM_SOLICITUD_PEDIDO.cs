using CAPA_DATOS;
using CAPA_DATOS.COMPRAS;
using CAPA_DATOS.INVENTARIO;
using CAPA_NEGOCIOS.COMPRAS;
using CAPA_NEGOCIOS.INVENTARIO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using RDMAQUINARIAS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RDMAQUINARIAS.COMPRAS
{
    public partial class ERP_COM_SOLICITUD_PEDIDO: Form
    {
        public ERP_COM_SOLICITUD_PEDIDO()
        {
            InitializeComponent();

            //fun.estiloDataGridView(dgvListado);
            //fun.estiloDataGridView(dgvDetProductos);
            //fun.estiloDataGridView(dgvDetServicios);
            string noFrom = CLASES.ERP_GLOBALES.formpermisos;

        }
        NEG_ALM_PRODUCTOS neg = new NEG_ALM_PRODUCTOS();
        NEG_COM_SOLICITUD_PEDIDO negCom = new NEG_COM_SOLICITUD_PEDIDO();
        NEG_ALM_PRODUCTOS negInv = new NEG_ALM_PRODUCTOS();
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        SqlConnection cn = new SqlConnection(Conexion.cadena);
        int opc;
        private void ERP_COM_SOLICITUD_PEDIDO_Load(object sender, EventArgs e)
        {
            #region LLENAR COMBO
            negCom.Opcion = 1;
            negCom.Criterio = "";
            negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtDoc = DAT_COM_SOLICITUD_PEDIDO.SP_ERP_COM_TIPO_DOCUMENTO_LS(negCom);
            fun.llenar_Combo(dtDoc, cbocoDoc, "deDoc", "coDoc");

            negCom.Opcion = 1;
            negCom.Criterio = "";
            negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtcoCond = DAT_COM_SOLICITUD_PEDIDO.SP_ERP_COM_CONDICION_PAGO_LS(negCom);
            fun.llenar_Combo(dtcoCond, cbocoCond, "deCond", "coCond");
            cbocoCond.SelectedIndex = 0;

            cbocoMon.SelectedIndex = 0;
            #endregion

            listarGrid(1, txtBuscar.Text);
            vistaGrid();
            
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

        private void listarGrid(int opcion, string criterio)
        {
            try
            {
                negCom.Opcion = opcion;
                negCom.Criterio = criterio;
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negCom.CoSuc = "";
                DataTable dt = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_LS(negCom);
                dgvListado.DataSource = dt;

                for (int i = 1; i < dgvListado.Columns.Count; i++)
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
                //dgvListado.Columns["btnEditarCol"].DefaultCellStyle=de

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnVistaGrid_Click(object sender, EventArgs e)
        {
            vistaGrid();
        }
        private void vistaGrid()
        {

            #region CAMBIO DE COLOR
            btnVistaGrid.BackColor = Color.FromArgb(42, 127, 184);
            btnVistaGrid.ForeColor = Color.White;
            btnVistaGrid.FlatAppearance.BorderColor = Color.FromArgb(42, 127, 184);
            #endregion


            panelForm.Visible = !true;
            panelListado.Visible = true;
            panelListado.Dock = DockStyle.Fill;

        }
        private void vistaFormulario()
        {
            panelForm.Visible = true;
            panelListado.Visible = !true;
            panelForm.Dock = DockStyle.Fill;
        }

        private void editarRegistro_click(string idPed)
        {
            opc = 2;
            listarCabeceraParaFormulario(idPed);
            fun.habilidarControles(panelForm, tabControlDetalle, true);
            dgvDetProductos.AllowUserToAddRows = true;
            dgvDetServicios.AllowUserToAddRows = true;
            vistaBotones(opc, panelNav,btnNuevo,btnGrabar,btnEditar,btnCancelar,btnImprimir);
            vistaFormulario();
        }
        private void listarCabeceraParaFormulario(string idPedido)
        {
            #region LISTAR CABECERA
            negCom.Opcion = 0;
            negCom.Criterio = idPedido;
            negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            negCom.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
            DataTable dt = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_LS(negCom);
            if (dt.Rows.Count > 0)
            {
                txtidPed.Text = dt.Rows[0]["idPed"].ToString();
                txtnuPed.Text = dt.Rows[0]["nuPed"].ToString();
                cbocoDoc.SelectedValue = dt.Rows[0]["coDoc"].ToString();
                txtnumero.Text = dt.Rows[0]["numero"].ToString();
                txtcoProvCli.Text = dt.Rows[0]["coProvCli"].ToString();
                txtdeProvCli.Text = dt.Rows[0]["deProvCli"].ToString();
                txtdirProvCli.Text = dt.Rows[0]["dirProvCli"].ToString();
                txttcVen.Text = dt.Rows[0]["tcVen"].ToString();
                cbocoCond.SelectedValue = dt.Rows[0]["coCond"].ToString();
                txtdeObsInt.Text = dt.Rows[0]["deObsInt"].ToString();
                txtdeObsProv.Text = dt.Rows[0]["deObsProv"].ToString();
                cbocoCond.SelectedValue= dt.Rows[0]["coCond"].ToString();
                //txtcos_u.Text = Convert.ToDecimal(dt.Rows[0]["cos_u"]).ToString("N2");
                txtimp_n_nac.Text = Convert.ToDecimal(dt.Rows[0]["imp_n_nac"]).ToString("N2");
                txtimp_i_nac.Text = Convert.ToDecimal(dt.Rows[0]["imp_i_nac"]).ToString("N2");
                txtimp_t_nac.Text = Convert.ToDecimal(dt.Rows[0]["imp_t_nac"]).ToString("N2");

                #region VISUALIZAR BOTONES PROPIOS DEL FORMULARIO
                if (Convert.ToBoolean(dt.Rows[0]["stSolicitud"]) == true)
                {
                    btnEnviarCorreo.Visible = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["stEnviado"]) == true)
                {
                    btnEnviarCorreo.Text = "Reenviar Sol.";
                    btnOrdenCompra.Visible = true;
                }

                if (Convert.ToBoolean(dt.Rows[0]["stOrdenado"]) == true)
                {
                    btnEnviarCorreo.Visible = false;
                    btnEnviarOrden.Visible = true;
                }
                panelNav.Controls.SetChildIndex(btnEnviarCorreo, 0);
                panelNav.Controls.SetChildIndex(btnOrdenCompra, 0);
                panelNav.Controls.SetChildIndex(btnEnviarOrden, 0);
                #endregion

                #region LISTAR DETALLE PRODUCTOS
                negCom.Opcion = 0;
                negCom.Criterio = txtnuPed.Text;
                negCom.TipoBien = "B";
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtDetPro = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_DET_LS(negCom);
                dgvDetProductos.Rows.Clear();
                for (int i = 0; i < dtDetPro.Rows.Count; i++)
                {
                    dgvDetProductos.Rows.Add();
                    dgvDetProductos.Rows[i].Cells["idPedDetP"].Value = dtDetPro.Rows[i]["idPedDet"].ToString();
                    dgvDetProductos.Rows[i].Cells["itemP"].Value = dtDetPro.Rows[i]["item"].ToString();
                    dgvDetProductos.Rows[i].Cells["coProdP"].Value = dtDetPro.Rows[i]["coProd"].ToString();
                    dgvDetProductos.Rows[i].Cells["deProdP"].Value = dtDetPro.Rows[i]["deProd"].ToString();
                    dgvDetProductos.Rows[i].Cells["cantP"].Value = dtDetPro.Rows[i]["cant"].ToString();
                    dgvDetProductos.Rows[i].Cells["coUmP"].Value = dtDetPro.Rows[i]["coUm"].ToString();
                    dgvDetProductos.Rows[i].Cells["imp_u_nacP"].Value = dtDetPro.Rows[i]["imp_u_nac"].ToString();
                    dgvDetProductos.Rows[i].Cells["porDctoP"].Value = Convert.ToDecimal(dtDetPro.Rows[i]["porDcto"]);
                    dgvDetProductos.Rows[i].Cells["imp_d_nacP"].Value = dtDetPro.Rows[i]["imp_d_nac"].ToString();

                    dgvDetProductos.Rows[i].Cells["imp_n_nacP"].Value = Convert.ToDecimal(dtDetPro.Rows[i]["imp_n_nac"]);
                    dgvDetProductos.Rows[i].Cells["porImpP"].Value = Convert.ToDecimal(dtDetPro.Rows[i]["porImp"]);
                    dgvDetProductos.Rows[i].Cells["imp_i_nacP"].Value = Convert.ToDecimal(dtDetPro.Rows[i]["imp_i_nac"]);

                    dgvDetProductos.Rows[i].Cells["imp_t_nacP"].Value = dtDetPro.Rows[i]["imp_t_nac"].ToString();
                    dgvDetProductos.Rows[i].Cells["deObsP"].Value = dtDetPro.Rows[i]["deObs"].ToString();
                }
                #endregion

                #region LISTAR DETALLE SERVICIOS
                negCom.Opcion = 0;
                negCom.Criterio = txtnuPed.Text;
                negCom.TipoBien = "S";
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtDetSer = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_DET_LS(negCom);
                dgvDetServicios.Rows.Clear();
                for (int i = 0; i < dtDetSer.Rows.Count; i++)
                {
                    dgvDetServicios.Rows.Add();
                    dgvDetServicios.Rows[i].Cells["idPedDetS"].Value = dtDetSer.Rows[i]["idPedDet"].ToString();
                    dgvDetServicios.Rows[i].Cells["itemS"].Value = dtDetSer.Rows[i]["item"].ToString();
                    dgvDetServicios.Rows[i].Cells["coProdS"].Value = dtDetSer.Rows[i]["coProd"].ToString();
                    dgvDetServicios.Rows[i].Cells["deProdS"].Value = dtDetSer.Rows[i]["deProd"].ToString();
                    dgvDetServicios.Rows[i].Cells["cantS"].Value = dtDetSer.Rows[i]["cant"].ToString();
                    dgvDetServicios.Rows[i].Cells["coUmS"].Value = dtDetSer.Rows[i]["coUm"].ToString();
                    dgvDetServicios.Rows[i].Cells["imp_u_nacS"].Value = dtDetSer.Rows[i]["imp_u_nac"].ToString();
                    dgvDetServicios.Rows[i].Cells["porDctoS"].Value = Convert.ToDecimal(dtDetSer.Rows[i]["porDcto"]);
                    dgvDetServicios.Rows[i].Cells["imp_d_nacS"].Value = dtDetSer.Rows[i]["imp_d_nac"].ToString();

                    dgvDetServicios.Rows[i].Cells["imp_n_nacS"].Value = Convert.ToDecimal(dtDetSer.Rows[i]["imp_n_nac"]);
                    dgvDetServicios.Rows[i].Cells["porImpS"].Value = Convert.ToDecimal(dtDetSer.Rows[i]["porImp"]);
                    dgvDetServicios.Rows[i].Cells["imp_i_nacS"].Value = Convert.ToDecimal(dtDetSer.Rows[i]["imp_i_nac"]);

                    dgvDetServicios.Rows[i].Cells["imp_t_nacS"].Value = dtDetSer.Rows[i]["imp_t_nac"].ToString();
                    dgvDetServicios.Rows[i].Cells["deObsS"].Value = dtDetSer.Rows[i]["deObs"].ToString();
                }
                #endregion
            }
            #endregion
        }
        private void ver_click(string idPed)
        {
            try
            {
                opc = 0;
                fun.habilidarControles(panelForm, tabControlDetalle, false);
                dgvDetProductos.AllowUserToAddRows = false;
                dgvDetServicios.AllowUserToAddRows = false;
                vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
                listarCabeceraParaFormulario(idPed);
                vistaFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void eliminarRegistro_click(string titulo)
        {
            try
            {
                if (MessageBox.Show("CONFIRMAR ELIMINACIÓN.", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    neg.CoProd = titulo;
                    neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    int i = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_ELIM(neg);
                    listarGrid(1, txtBuscar.Text);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVistaGrid_Click_1(object sender, EventArgs e)
        {
            listarGrid(1, txtBuscar.Text);
            vistaGrid();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opc = 1;
            txtcoProvCli.ReadOnly = false;
            fun.habilidarControles(panelForm, tabControlDetalle, true);
            fun.lipiarControles(panelForm, tabControlDetalle, true);
            vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
            vistaFormulario();
            txtnuPed.Text = "[Nuevo]";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opc = -1;
            vistaGrid();
            vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);

        }
        private void txtcoProvCli_Leave(object sender, EventArgs e)
        {
            try
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
                        txtdirProvCli.Text = dt.Rows[0]["dirProvCli"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("PROVEEDOR NO EXISTE.", "Sistema");
                        txtdeProvCli.Clear();
                        txtdirProvCli.Clear();
                        txtcoProvCli.Select();
                        return;
                    }
                }
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
                    negCom.Opc = opc;
                    negCom.CoDoc = cbocoDoc.SelectedValue.ToString();
                    negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    int i = DAT_COM_SOLICITUD_PEDIDO.SP_ERP_COM_TIPO_DOCUMENTO_GENERAR(negCom);
                    txtnumero.Text = i.ToString("00000000");
                    txtnuPed.Text = cbocoDoc.SelectedValue.ToString() + "-" + txtnumero.Text;
                }


                SqlCommand cmdCab = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_CAB_GB", cn);
                cmdCab.CommandType = CommandType.StoredProcedure;
                cmdCab.Parameters.Add("@opc", SqlDbType.Char).Value = opc;
                cmdCab.Parameters.Add("@coDoc", SqlDbType.Char).Value = cbocoDoc.SelectedValue.ToString();
                cmdCab.Parameters.Add("@numero", SqlDbType.Char).Value = txtnumero.Text;
                cmdCab.Parameters.Add("@nuPed", SqlDbType.VarChar).Value = txtnuPed.Text;
                cmdCab.Parameters.Add("@coProvCli", SqlDbType.VarChar).Value = txtcoProvCli.Text;
                cmdCab.Parameters.Add("@dirEnt", SqlDbType.VarChar).Value = txtdirProvCli.Text;
                cmdCab.Parameters.Add("@fePed", SqlDbType.DateTime).Value = dtpfePed.Value;
                cmdCab.Parameters.Add("@feRec", SqlDbType.DateTime).Value = dtpfeRec.Value;
                if (cbocoMon.Text == "DOLARES")
                {
                    cmdCab.Parameters.Add("@coMon", SqlDbType.VarChar).Value = "D";
                }
                else
                {
                    cmdCab.Parameters.Add("@coMon", SqlDbType.VarChar).Value = "S";
                }
                cmdCab.Parameters.Add("@tcVen", SqlDbType.Decimal).Value = Convert.ToDecimal(txttcVen.Text);
                cmdCab.Parameters.Add("@coCond", SqlDbType.Char).Value = cbocoCond.SelectedValue.ToString();
                cmdCab.Parameters.Add("@deObsInt", SqlDbType.VarChar).Value = txtdeObsInt.Text;
                cmdCab.Parameters.Add("@deObsProv", SqlDbType.VarChar).Value = txtdeObsProv.Text;

                cmdCab.Parameters.Add("@imp_n_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(txtimp_n_nac.Text);
                cmdCab.Parameters.Add("@imp_i_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(txtimp_i_nac.Text);
                cmdCab.Parameters.Add("@imp_t_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(txtimp_t_nac.Text);

                cmdCab.Parameters.Add("@estado", SqlDbType.Char).Value = "P"; //S = SOLICITUD / E = SOL.ENVIADA / O = ORDEN DE COMPRA
                cmdCab.Parameters.Add("@coEmp", SqlDbType.Char).Value = CLASES.ERP_GLOBALES.CoEmp;
                cmdCab.Parameters.Add("@coSuc", SqlDbType.Char).Value = CLASES.ERP_GLOBALES.CoSuc;
                cmdCab.Parameters.Add("@co_usua_crea", SqlDbType.VarChar).Value = CLASES.ERP_GLOBALES.CoUsu;
                cn.Open();
                cmdCab.ExecuteNonQuery();
                cn.Close();

                #region GRABAR DETALLE PRODUCTOS
                for (int i = 0; i < dgvDetProductos.Rows.Count - 1; i++)
                {
                    SqlCommand cmdDetPro = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_DET_GB", cn);
                    cmdDetPro.CommandType = CommandType.StoredProcedure;
                    cmdDetPro.Parameters.Add("@idPedDet", SqlDbType.Int).Value =Convert.ToInt64(dgvDetProductos.Rows[i].Cells["idPedDetP"].Value);
                    cmdDetPro.Parameters.Add("@nuPed", SqlDbType.Char).Value = txtnuPed.Text;
                    cmdDetPro.Parameters.Add("@item", SqlDbType.Int).Value = Convert.ToInt64(dgvDetProductos.Rows[i].Cells["itemP"].Value);
                    cmdDetPro.Parameters.Add("@coProd", SqlDbType.VarChar).Value = dgvDetProductos.Rows[i].Cells["coProdP"].Value.ToString();
                    cmdDetPro.Parameters.Add("@deProd", SqlDbType.VarChar).Value = dgvDetProductos.Rows[i].Cells["deProdP"].Value.ToString();
                    cmdDetPro.Parameters.Add("@tipoBien", SqlDbType.Char).Value = "B";
                    cmdDetPro.Parameters.Add("@cant", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["cantP"].Value);
                    cmdDetPro.Parameters.Add("@coUm", SqlDbType.Char).Value = dgvDetProductos.Rows[i].Cells["coUmP"].Value.ToString();
                    cmdDetPro.Parameters.Add("@imp_u_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_u_nacP"].Value);
                    cmdDetPro.Parameters.Add("@porDcto", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["porDctoP"].Value);
                    cmdDetPro.Parameters.Add("@imp_d_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_d_nacP"].Value);

                    cmdDetPro.Parameters.Add("@imp_n_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_n_nacP"].Value);
                    cmdDetPro.Parameters.Add("@porImp", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["porImpP"].Value);
                    cmdDetPro.Parameters.Add("@imp_i_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_i_nacP"].Value);

                    cmdDetPro.Parameters.Add("@imp_t_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_t_nacP"].Value);
                    cmdDetPro.Parameters.Add("@deObs", SqlDbType.VarChar).Value = dgvDetProductos.Rows[i].Cells["deObsP"].Value.ToString();
                    cmdDetPro.Parameters.Add("@coEmp", SqlDbType.Char).Value = CLASES.ERP_GLOBALES.CoEmp;
                    cn.Open();
                    cmdDetPro.ExecuteNonQuery();
                    cn.Close();
                }
                #endregion

                #region GRABAR DETALLE SERVICIOS
                for (int i = 0; i < dgvDetServicios.Rows.Count - 1; i++)
                {
                    SqlCommand cmdDetSer = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_DET_GB", cn);
                    cmdDetSer.CommandType = CommandType.StoredProcedure;
                    cmdDetSer.Parameters.Add("@idPedDet", SqlDbType.Int).Value =Convert.ToInt64(dgvDetServicios.Rows[i].Cells["idPedDetS"].Value);
                    cmdDetSer.Parameters.Add("@nuPed", SqlDbType.Char).Value = txtnuPed.Text;
                    cmdDetSer.Parameters.Add("@item", SqlDbType.Int).Value = Convert.ToInt64(dgvDetServicios.Rows[i].Cells["itemS"].Value);
                    cmdDetSer.Parameters.Add("@coProd", SqlDbType.VarChar).Value = dgvDetServicios.Rows[i].Cells["coProdS"].Value.ToString();
                    cmdDetSer.Parameters.Add("@deProd", SqlDbType.VarChar).Value = dgvDetServicios.Rows[i].Cells["deProdS"].Value.ToString();
                    cmdDetSer.Parameters.Add("@tipoBien", SqlDbType.Char).Value = "S";
                    cmdDetSer.Parameters.Add("@cant", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["cantS"].Value);
                    cmdDetSer.Parameters.Add("@coUm", SqlDbType.Char).Value = dgvDetServicios.Rows[i].Cells["coUmS"].Value.ToString();
                    cmdDetSer.Parameters.Add("@imp_u_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["imp_u_nacS"].Value);
                    cmdDetSer.Parameters.Add("@porDcto", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["porDctoS"].Value);
                    cmdDetSer.Parameters.Add("@imp_d_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["imp_d_nacS"].Value);

                    cmdDetSer.Parameters.Add("@imp_n_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["imp_n_nacS"].Value);
                    cmdDetSer.Parameters.Add("@porImp", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["porImpS"].Value);
                    cmdDetSer.Parameters.Add("@imp_i_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["imp_i_nacS"].Value);

                    cmdDetSer.Parameters.Add("@imp_t_nac", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvDetServicios.Rows[i].Cells["imp_t_nacS"].Value);
                    cmdDetSer.Parameters.Add("@deObs", SqlDbType.VarChar).Value = dgvDetServicios.Rows[i].Cells["deObsS"].Value.ToString();
                    cmdDetSer.Parameters.Add("@coEmp", SqlDbType.Char).Value = CLASES.ERP_GLOBALES.CoEmp;
                    cn.Open();
                    cmdDetSer.ExecuteNonQuery();
                    cn.Close();
                }
                #endregion


                opc = 0;
                listarGrid(1, txtBuscar.Text);
                vistaGrid();
                vistaBotones(-1, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            listarGrid(1, txtBuscar.Text);
        }
        private void dgvDetProductos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "coProdP")
                {
                    agregarFilaProducto(dgvDetProductos.CurrentRow.Index);
                }
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "porDctoP")
                {
                    decimal por = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value) * 100;
                    dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value = Convert.ToDecimal(por).ToString("N4");
                }
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "porImpP")
                {
                    decimal porImp = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porImpP"].Value) * 100;
                    dgvDetProductos.Rows[e.RowIndex].Cells["porImpP"].Value = Convert.ToDecimal(porImp).ToString("N2");
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
                    || dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_u_nacP"
                    || dgvDetProductos.Columns[e.ColumnIndex].Name == "porDctoP"
                    || dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_d_nacP"
                    || dgvDetProductos.Columns[e.ColumnIndex].Name == "porImpP"
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
                    if(dgvDetProductos.Rows[e.RowIndex].Cells["coProdP"].Value != null || dgvDetProductos.Rows[e.RowIndex].Cells["coProdP"].Value.ToString() != "")
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
               if (dgvDetProductos.Columns[e.ColumnIndex].Name == "porDctoP")
                {
                    //dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Style.Format = "P2";
                    decimal por = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value) / 100;
                    dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value = Convert.ToDecimal(por);
                }
                if (dgvDetProductos.Columns[e.ColumnIndex].Name == "porImpP")
                {
                    //dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Style.Format = "P2";
                    decimal porImp = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porImpP"].Value) / 100;
                    dgvDetProductos.Rows[e.RowIndex].Cells["porImpP"].Value = Convert.ToDecimal(porImp);
                }

                if ((e.RowIndex) != dgvDetProductos.Rows.Count - 1)
                {
                    #region CALCULOS POR FILA
                    if (dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_u_nacP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "cantP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "porDctoP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_n_nacP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "porImpP"
                        || dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_t_nacP")
                    {
                        decimal imp_u_nac = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["imp_u_nacP"].Value);
                        decimal cant = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["cantP"].Value);
                        decimal precioXcant = precioXcantidad(imp_u_nac, cant);
                        decimal porDcto =Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porDctoP"].Value);
                        decimal imp_d_nac = importeDecuento(precioXcant, porDcto);
                        decimal imp_n_nac = importeTotal(precioXcant, imp_d_nac);
                        decimal porImpP = Convert.ToDecimal(dgvDetProductos.Rows[e.RowIndex].Cells["porImpP"].Value);
                        decimal imp_i_nac = impuesto(imp_n_nac, porImpP);
                        decimal imp_t_nac = precioVentaTotal(imp_n_nac, imp_i_nac);

                        dgvDetProductos.Rows[e.RowIndex].Cells["imp_d_nacP"].Value = imp_d_nac;
                        dgvDetProductos.Rows[e.RowIndex].Cells["imp_n_nacP"].Value = imp_n_nac;
                        dgvDetProductos.Rows[e.RowIndex].Cells["imp_i_nacP"].Value = imp_i_nac;
                        dgvDetProductos.Rows[e.RowIndex].Cells["imp_t_nacP"].Value = imp_t_nac;
                        sumarTotales();
                    }


                    if (dgvDetProductos.Columns[e.ColumnIndex].Name == "imp_d_nacP")
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
                    }
                    #endregion
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
                if (dgvDetProductos.Rows[fila].Cells["coProdP"].Value==null 
                    || dgvDetProductos.Rows[fila].Cells["coProdP"].Value.ToString() == "")
                {
                    dgvDetProductos.Rows[fila].Cells["idPedDetP"].Value = "0";
                    dgvDetProductos.Rows[fila].Cells["itemP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["coProdP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["deProdP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["cantP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["coUmP"].Value = "";
                    dgvDetProductos.Rows[fila].Cells["imp_u_nacP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["porDctoP"].Value = Convert.ToDecimal(0);
                    dgvDetProductos.Rows[fila].Cells["imp_d_nacP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["imp_t_nacP"].Value = "0.00";
                    dgvDetProductos.Rows[fila].Cells["deObsP"].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregarFilaServicio(int fila)
        {
            try
            {
                if (dgvDetServicios.Rows[fila].Cells["coProdS"].Value == null
                    || dgvDetServicios.Rows[fila].Cells["coProdS"].Value.ToString() == "")
                {
                    dgvDetServicios.Rows[fila].Cells["idPedDetS"].Value = "0";
                    dgvDetServicios.Rows[fila].Cells["itemS"].Value = "0";
                    dgvDetServicios.Rows[fila].Cells["coProdS"].Value = "";
                    dgvDetServicios.Rows[fila].Cells["deProdS"].Value = "";
                    dgvDetServicios.Rows[fila].Cells["cantS"].Value = "0.00";
                    dgvDetServicios.Rows[fila].Cells["coUmS"].Value = "UNI";
                    dgvDetServicios.Rows[fila].Cells["imp_u_nacS"].Value = "0.00";
                    dgvDetServicios.Rows[fila].Cells["porDctoS"].Value = Convert.ToDecimal(0);
                    dgvDetServicios.Rows[fila].Cells["imp_d_nacS"].Value = "0.00";
                    dgvDetServicios.Rows[fila].Cells["imp_t_nacS"].Value = "0.00";
                    dgvDetServicios.Rows[fila].Cells["deObsS"].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                opc = 2;
                fun.habilidarControles(panelForm, tabControlDetalle, true);
                dgvDetProductos.AllowUserToAddRows = true;
                dgvDetServicios.AllowUserToAddRows = true;
                vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




           
        }
        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            CLASES.ERP_GLOBALES.NumDocu = txtnuPed.Text;
            CLASES.ERP_GLOBALES.TituloPed = "Solicitud de Cotización";
            CLASES.ERP_GLOBALES.ErpAccion = 0;
            generarArchivoPDF(txtnuPed.Text);
            ERP_COM_ENVIAR_CORREO frm = new ERP_COM_ENVIAR_CORREO();
            frm.ShowDialog();
            if(CLASES.ERP_GLOBALES.ErpAccion == 1)
            {
                opc = -1;
                vistaGrid();
                vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
            }
        }
        private void generarArchivoPDF(string codDocumento)
        {
            try
            {
                ERP_COM_REPORTES.DS_COM_DATOS ds = new ERP_COM_REPORTES.DS_COM_DATOS();

                negCom.Opcion = 0;
                negCom.Criterio = "1";
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negCom.CoSuc = CLASES.ERP_GLOBALES.CoSuc;

                DataTable dtCab = ds.EPR_COM_ORDEN_PEDIDO_CAB;
                DataTable dt = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_LS(negCom);
                if (dt.Rows.Count > 0)
                {
                    DataRow filaCab = dtCab.NewRow();
                    filaCab["nuPed"] = dt.Rows[0]["nuPed"].ToString();
                    filaCab["coProvCli"] = dt.Rows[0]["coProvCli"].ToString();
                    filaCab["deProvCli"] = dt.Rows[0]["deProvCli"].ToString();
                    filaCab["tituloPed"] = CLASES.ERP_GLOBALES.TituloPed;
                    dtCab.Rows.Add(filaCab);
                }

                ReportDocument rpt = new ERP_COM_REPORTES.CR_COM_SOLICITUD_PEDIDO();
                rpt.SetDataSource(ds);
                string rutaBin = Application.StartupPath;
                string codigo = codDocumento;
                //Environment.GetFolderPath(Environment.SpecialFolder.Desktop) //ruta especifica escritorio
                string rutaPDF = Path.Combine(rutaBin, codDocumento +".pdf");
                rpt.ExportToDisk(ExportFormatType.PortableDocFormat, rutaPDF);

                /*if (File.Exists(rutaPDF))
                {
                    Process.Start(rutaPDF);
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el archivo PDF.");
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void generarArchivoIMPRIMIBLE(string codDocumento)
        {
            try
            {
                ERP_COM_REPORTES.DS_COM_DATOS ds = new ERP_COM_REPORTES.DS_COM_DATOS();

                negCom.Opcion = 0;
                negCom.Criterio = "1";
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negCom.CoSuc = CLASES.ERP_GLOBALES.CoSuc;

                DataTable dtCab = ds.EPR_COM_ORDEN_PEDIDO_CAB;
                DataTable dt = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_LS(negCom);
                if (dt.Rows.Count > 0)
                {
                    DataRow filaCab = dtCab.NewRow();
                    filaCab["nuPed"] = dt.Rows[0]["nuPed"].ToString();
                    filaCab["coProvCli"] = dt.Rows[0]["coProvCli"].ToString();
                    filaCab["deProvCli"] = dt.Rows[0]["deProvCli"].ToString();
                    filaCab["tituloPed"] = CLASES.ERP_GLOBALES.TituloPed;
                    dtCab.Rows.Add(filaCab);
                }

                ReportDocument rpt = new ERP_COM_REPORTES.CR_COM_SOLICITUD_PEDIDO();
                rpt.SetDataSource(ds);
                string rutaBin = Application.StartupPath;
                string codigo = codDocumento;
                //Environment.GetFolderPath(Environment.SpecialFolder.Desktop) //ruta especifica escritorio
                string rutaPDF = Path.Combine(rutaBin, codDocumento + ".pdf");
                rpt.ExportToDisk(ExportFormatType.PortableDocFormat, rutaPDF);

                if (File.Exists(rutaPDF))
                {
                    Process.Start(rutaPDF);
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el archivo PDF.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetServicios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetServicios.Columns[e.ColumnIndex].Name == "deProdS")
                {
                    negInv.Opcion = 2;
                    negInv.Criterio = dgvDetServicios.Rows[e.RowIndex].Cells["deProdS"].Value.ToString().Trim();
                    negInv.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    negInv.CoSuc = "";
                    DataTable dt = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_SERVICIOS_LS(negInv);
                    if (dt.Rows.Count == 0)
                    {
                        dgvDetServicios.Rows[e.RowIndex].Cells["itemS"].Value = (e.RowIndex + 1);
                        dgvDetServicios.Rows[e.RowIndex].Cells["coProdS"].Value = "-";
                    }
                }

                if (dgvDetServicios.Columns[e.ColumnIndex].Name == "porDctoS")
                {
                    decimal por = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value) / 100;
                    dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value = Convert.ToDecimal(por);
                }
                if (dgvDetServicios.Columns[e.ColumnIndex].Name == "porImpS")
                {
                    decimal porImp = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value) / 100;
                    dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value = Convert.ToDecimal(porImp);
                }
                if ((e.RowIndex) != dgvDetServicios.Rows.Count - 1)
                {
                    #region CALCULOS POR FILA

                    if (dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_u_nacS"
                        || dgvDetServicios.Columns[e.ColumnIndex].Name == "cantS"
                        || dgvDetServicios.Columns[e.ColumnIndex].Name == "porDctoS"

                        || dgvDetServicios.Columns[e.ColumnIndex].Name == "porImpS"
                        || dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_t_nacS")
                    {
                        decimal imp_u_nac = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["imp_u_nacS"].Value);
                        decimal cant = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["cantS"].Value);
                        decimal precioXcant = precioXcantidad(imp_u_nac, cant);
                        decimal porDcto = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value);
                        decimal imp_d_nac = importeDecuento(precioXcant, porDcto);
                        decimal imp_n_nac = importeTotal(precioXcant, imp_d_nac);
                        decimal porImp = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value);
                        decimal imp_i_nac = impuesto(imp_n_nac, porImp);
                        decimal imp_t_nac = precioVentaTotal(imp_n_nac, imp_i_nac);





                        dgvDetServicios.Rows[e.RowIndex].Cells["imp_d_nacS"].Value = Math.Round(imp_d_nac, 4);
                        dgvDetServicios.Rows[e.RowIndex].Cells["imp_n_nacS"].Value = Math.Round(imp_n_nac, 4);
                        dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value = Math.Round(porImp, 4);
                        dgvDetServicios.Rows[e.RowIndex].Cells["imp_i_nacS"].Value = Math.Round(imp_i_nac, 4);
                        dgvDetServicios.Rows[e.RowIndex].Cells["imp_t_nacS"].Value = Math.Round(imp_t_nac, 4);



                        sumarTotales();
                    }


                    if (dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_d_nacS")
                    {
                        #region CALCULAR PORCENTAJE DECUENTO (DESDE EL IMPORTE DCTO)
                        decimal imp_u_nac = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["imp_u_nacS"].Value);
                        decimal cant = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["cantS"].Value);
                        decimal precioXcant = precioXcantidad(imp_u_nac, cant);
                        decimal imp_d_nac = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["imp_d_nacS"].Value);
                        decimal porDcto = porcentajeDecuento(precioXcant, imp_d_nac);
                        //decimal imp_t_nac = importeTotal(precioXcant, imp_d_nac);

                        decimal imp_n_nac = importeTotal(precioXcant, imp_d_nac);
                        decimal porImp = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value);
                        decimal imp_i_nac = impuesto(imp_n_nac, porImp);
                        decimal imp_t_nac = precioVentaTotal(imp_n_nac, imp_i_nac);




                        dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value = porDcto;
                        //dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value = Math.Round(porDcto, 4);
                        #endregion

                        dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value = Convert.ToDecimal(porDcto);
                        //dgvDetServicios.Rows[e.RowIndex].Cells["imp_t_nacS"].Value = imp_t_nac;
                        dgvDetServicios.Rows[e.RowIndex].Cells["imp_i_nacS"].Value = Math.Round(imp_i_nac, 4);
                        dgvDetServicios.Rows[e.RowIndex].Cells["imp_t_nacS"].Value = Math.Round(imp_t_nac, 4);

                        sumarTotales();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetServicios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvDetServicios.Columns[e.ColumnIndex].Name == "coProdS"
                || dgvDetServicios.Columns[e.ColumnIndex].Name == "cantS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "deProdS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_u_nacS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "porDctoS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_d_nacS")
            {
                agregarFilaServicio(dgvDetServicios.CurrentRow.Index);
            }
            if (dgvDetServicios.Columns[e.ColumnIndex].Name == "porDctoS")
            {
                decimal por = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value) * 100;
                dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value = Convert.ToDecimal(por).ToString("N4");
            }
            if (dgvDetServicios.Columns[e.ColumnIndex].Name == "porImpS")
            {
                decimal por = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value) * 100;
                dgvDetServicios.Rows[e.RowIndex].Cells["porImpS"].Value = Convert.ToDecimal(por).ToString("N2");
            }

        }

        private void dgvDetServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetServicios.Columns[e.ColumnIndex].Name == "cantS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "deProdS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_u_nacS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "porDctoS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "imp_d_nacS"
                    || dgvDetServicios.Columns[e.ColumnIndex].Name == "porImpS")
                {
                    dgvDetServicios.BeginEdit(true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetServicios.Columns[e.ColumnIndex].Name == "btnBuscarServ")
                {
                    CLASES.ERP_GLOBALES.ErpAccion = 0;
                    ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS frm = new ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.ErpAccion == 1)
                    {
                        //dgvDetServicios.Rows.Add();

                        negInv.Opcion = 0;
                        negInv.Criterio = CLASES.ERP_GLOBALES.CoProd;
                        negInv.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        negInv.CoSuc = "";
                        DataTable dt = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_SERVICIOS_LS(negInv);
                        if (dt.Rows.Count > 0)
                        {
                            agregarFilaServicio(dgvDetServicios.CurrentRow.Index);
                            dgvDetServicios.Rows[e.RowIndex].Cells["itemS"].Value = (e.RowIndex + 1);
                            dgvDetServicios.Rows[e.RowIndex].Cells["coProdS"].Value = dt.Rows[0]["coProd"].ToString();
                            dgvDetServicios.Rows[e.RowIndex].Cells["deProdS"].Value = dt.Rows[0]["deProd"].ToString();
                            dgvDetServicios.Rows[e.RowIndex].Cells["coUmS"].Value = dt.Rows[0]["coUm"].ToString();


                        }
                    }
                    if (dgvDetServicios.Columns[e.ColumnIndex].Name == "porDctoS")
                    {
                        decimal por = Convert.ToDecimal(dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value) * 100;
                        dgvDetServicios.Rows[e.RowIndex].Cells["porDctoS"].Value = Convert.ToDecimal(por).ToString("N0");
                    }
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
                decimal netoProductos = 0;
                decimal impProductos = 0;
                decimal totProductos = 0;
                for (int i = 0; i < dgvDetProductos.Rows.Count - 1; i++)
                {
                    netoProductos += Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_n_nacP"].Value);
                    impProductos += Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_i_nacP"].Value);
                    totProductos += Convert.ToDecimal(dgvDetProductos.Rows[i].Cells["imp_t_nacP"].Value);
                }

                decimal netoServicios = 0;
                decimal impServicios = 0;
                decimal totServicios = 0;
                for (int s = 0; s < dgvDetServicios.Rows.Count - 1; s++)
                {
                    netoServicios += Convert.ToDecimal(dgvDetServicios.Rows[s].Cells["imp_n_nacS"].Value);
                    impServicios += Convert.ToDecimal(dgvDetServicios.Rows[s].Cells["imp_i_nacS"].Value);
                    totServicios += Convert.ToDecimal(dgvDetServicios.Rows[s].Cells["imp_t_nacS"].Value);
                }

                decimal neto = (netoProductos + netoServicios);
                decimal impuesto = (impProductos + impServicios);
                //decimal porImp = Convert.ToDecimal(txtporImp.Text);
                decimal total = (totProductos + totServicios);
                //decimal imp_t_nac = precioVentaTotal(total, impuesto);
                txtimp_n_nac.Text = neto.ToString("N2");
                txtimp_i_nac.Text = impuesto.ToString("N2");
                txtimp_t_nac.Text = total.ToString("N2");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvListado.Columns[e.ColumnIndex].Name == "btnEditarCol")
            {
                string idPed = dgvListado.CurrentRow.Cells["idPed"].Value.ToString();
                opc = 2;
                listarCabeceraParaFormulario(idPed);
                fun.habilidarControles(panelForm, tabControlDetalle, true);
                dgvDetProductos.AllowUserToAddRows = true;
                dgvDetServicios.AllowUserToAddRows = true;
                vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
                vistaFormulario();
            }
            if (dgvListado.Columns[e.ColumnIndex].Name == "btnVer")
            {
                string idPed = dgvListado.CurrentRow.Cells["idPed"].Value.ToString();
                opc = 0;
                fun.habilidarControles(panelForm, tabControlDetalle, false);
                dgvDetProductos.AllowUserToAddRows = false;
                dgvDetServicios.AllowUserToAddRows = false;
                vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
                listarCabeceraParaFormulario(idPed);
                vistaFormulario();
            }                   
            
        }

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string estado = e.Value.ToString();

                    if (estado == "Solicitud [RFQ]")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(138, 208, 219);
                        e.CellStyle.ForeColor = Color.Black;
                        //e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    else if (estado == "Sol. Envíado")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(138, 208, 219);
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (estado == "Orden de Compra [OC]")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(146, 211, 160);
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CLASES.ERP_GLOBALES.TituloPed = "Solciitud de cotización";
                CLASES.ERP_GLOBALES.NumDocu = txtnuPed.Text;
                CLASES.ERP_GLOBALES.ErpAccion = 0;
                generarArchivoIMPRIMIBLE(txtnuPed.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                btnEditar.Visible = true;
                btnImprimir.Visible = true;


                //btnEnviarCorreo.Visible = true;
                //pnlBotonesEspeciales.Visible = true;
                //vistaBotonesEspeciales(Convert.ToInt32(txtidPed.Text));

                pnl.Controls.SetChildIndex(btnEditar, 0);
                pnl.Controls.SetChildIndex(btnImprimir, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);
                //pnl.Controls.SetChildIndex(btnEnviarCorreo, 0);

            }
            else if (opc == 1) //nuevo
            {
                btnCancelar.Visible = true;
                btnGrabar.Visible = true;
                //pnlBotonesEspeciales.Visible = false;

                pnl.Controls.SetChildIndex(btnGrabar, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);
            }
            else if (opc == 2)//editar
            {
                btnCancelar.Visible = true;
                btnGrabar.Visible = true;
                //pnlBotonesEspeciales.Visible = false;

                pnl.Controls.SetChildIndex(btnGrabar, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);
            }
            else //inicio
            {
                btnNuevo.Visible = true;
               // pnlBotonesEspeciales.Visible = false;
            }
        }

        private void btnOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                /*#region VALIDAR ORDEN DE COMPRA
                negCom.Opcion = 0;
                negCom.Criterio = txtidPed.Text;
                negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negCom.CoSuc = "";
                DataTable dtOC = DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_LS(negCom);
                if (Convert.ToBoolean(dtOC.Rows[0]["stOrdenado"]) == true)
                {
                    MessageBox.Show("EL DOCUMENTO YA FUÉ REGISTRADO COMO ORDEN DE COMPRA.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion*/

                if(MessageBox.Show("DESEA GENERAR ORDEN DE COMPRA ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    negCom.NuPed = txtnuPed.Text;
                    negCom.Estado = "O";
                    negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO_ORDEN_COMPRA(negCom);

                    #region RECARGAR FORMULARIO
                    string idPed = txtidPed.Text; //dgvListado.CurrentRow.Cells["idPed"].Value.ToString();
                    listarCabeceraParaFormulario(idPed);
                    #endregion


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEnviarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                CLASES.ERP_GLOBALES.NumDocu = txtnuPed.Text;
                CLASES.ERP_GLOBALES.TituloPed = "Orden de Compra";
                CLASES.ERP_GLOBALES.ErpAccion = 0;
                generarArchivoPDF(txtnuPed.Text);
                ERP_COM_ENVIAR_CORREO frm = new ERP_COM_ENVIAR_CORREO();
                frm.ShowDialog();
                if (CLASES.ERP_GLOBALES.ErpAccion == 1)
                {
                    opc = -1;
                    vistaGrid();
                    vistaBotones(opc, panelNav, btnNuevo, btnGrabar, btnEditar, btnCancelar, btnImprimir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
