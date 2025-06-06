using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDMAQUINARIAS.Properties;
using System.Drawing;
using DevComponents.DotNetBar.Controls;

namespace RDMAQUINARIAS.CLASES
{
    public class ERP_FUNCIONES
    {
        public void llenar_Combo(DataTable tbl, ComboBox cbo, string strDisplayMember, string strValueMember)
        {
            cbo.DataSource = tbl;
            cbo.DisplayMember = strDisplayMember;
            cbo.ValueMember = strValueMember;
        }
        public DataTable Retorna_Tabla(string strSQLConsulta)
        {

            SqlConnection cnx = new SqlConnection(Conexion.cadena);
            cnx.Open();
            SqlCommand comando = new SqlCommand(strSQLConsulta, cnx);
            comando.CommandTimeout = 200;
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tbl = new DataTable();
            adaptador.Fill(tbl);
            cnx.Close();
            return tbl;
        }
        public void ERP_Habilitar_Botones(Form frm, Button btNnuevo, Button btnGrabar, Button btnEliminar, Button btnEditar,
        Button btnCancelar, Button btnReporteLista, Button btnAuditoria, bool bolSw, string strCoUsuario, string strCoSucursal, string strCoEmpresa, string strNoForm)/*, string strCodigo_Menu*/
        {
            ERP_FUNCIONES funciones = new ERP_FUNCIONES();

            bool bolSwInterno = false;
            btNnuevo.Text = "Nuevo";
            btnGrabar.Text = "Grabar";
            btnEliminar.Text = "Eliminar";
            btnEditar.Text = "Editar";
            btnCancelar.Text = "Cancelar";
            btnReporteLista.Text = "imprimir";
            btnAuditoria.Text = "Auditoria";
            if (bolSw == true)
            {
                bolSwInterno = false;
                DataTable dtVer = funciones.Retorna_Tabla("SELECT * FROM ( " +
                "         SELECT M.noMod AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte' FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_MODULO M ON M.coMod = SOP.coMod" +
                "         WHERE M.stRegistro = 1 AND M.form = 1 AND SOP.coMod IS NOT NULL AND SOP.coEmp = '" + strCoEmpresa + "' AND SOP.coSuc = '" + strCoSucursal + "' AND SOP.coUsu = '" + strCoUsuario + "' AND M.noMod='" + strNoForm + "'" +
                "         UNION ALL" +
                "         SELECT M.noMenu AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte'  FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_MENU M ON M.coMenu = SOP.coMenu" +
                "         WHERE M.stRegistro = 1 AND M.form = 1 AND SOP.coMenu IS NOT NULL AND SOP.coEmp = '" + strCoEmpresa + "' AND SOP.coSuc = '" + strCoSucursal + "' AND SOP.coUsu = '" + strCoUsuario + "' AND M.noMenu='" + strNoForm + "' " +
                "         UNION ALL" +
                "         SELECT M.noSubMenu AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte'  FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_SUBMENU M ON M.coSubMenu = SOP.coSubMenu" +
                "         WHERE M.stRegistro = 1 AND M.form = 1 AND SOP.coSubMenu IS NOT NULL AND SOP.coEmp = '" + strCoEmpresa + "' AND SOP.coSuc = '" + strCoSucursal + "' AND SOP.coUsu = '" + strCoUsuario + "' AND M.noSubMenu='" + strNoForm + "' " +
                "         UNION ALL" +
                "         SELECT M.noSubSubMenu AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte'  FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_SUBSUBMENU M ON M.coSubSubMenu = SOP.coSubSubMenu" +
                "         WHERE M.stRegistro = 1 AND M.form = 1 AND SOP.coSubSubMenu IS NOT NULL AND SOP.coEmp = '" + strCoEmpresa + "' AND SOP.coSuc = '" + strCoSucursal + "' AND SOP.coUsu = '" + strCoUsuario + "'  AND M.noSubSubMenu='" + strNoForm + "'" +
                "   ) TAB ");


                if (dtVer.Rows.Count == 0)
                {
                    btNnuevo.Enabled = bolSwInterno;
                    btnGrabar.Enabled = bolSwInterno;
                    btnEditar.Enabled = bolSwInterno;
                    btnEliminar.Enabled = bolSwInterno;
                    btnCancelar.Enabled = bolSwInterno;
                    btnReporteLista.Enabled = bolSwInterno;
                    btnAuditoria.Enabled = bolSwInterno;
                }
                else
                {
                    switch (dtVer.Rows[0]["stGrabar"].ToString())
                    {
                        case "False": btnGrabar.Enabled = false; btNnuevo.Enabled = false; break;
                        case "True": btnGrabar.Enabled = false; btNnuevo.Enabled = true; break;
                    }
                    switch (dtVer.Rows[0]["stEditar"].ToString())
                    {
                        case "False": btnEditar.Enabled = false; break;
                        case "True": btnEditar.Enabled = true; break;
                    }
                    switch (dtVer.Rows[0]["stEliminar"].ToString())
                    {
                        case "False": btnEliminar.Enabled = false; break;
                        case "True": btnEliminar.Enabled = true; break;
                    }
                    switch (dtVer.Rows[0]["stReporte"].ToString())
                    {
                        case "False": btnReporteLista.Enabled = false; break;
                        case "True": btnReporteLista.Enabled = true; break;
                    }
                    btnAuditoria.Enabled = bolSw;
                }

            }
            else if (bolSw == false)
            {
                bolSwInterno = true;
                btNnuevo.Enabled = bolSw; btnEditar.Enabled = bolSw; btnAuditoria.Enabled = bolSw; btnEliminar.Enabled = bolSw; btnReporteLista.Enabled = bolSw;
                btnCancelar.Enabled = bolSwInterno;
                btnGrabar.Enabled = true;
            }
        }

        public void Llenar_CboEstado(Form frm, ComboBox cbo)
        {
            cbo.Items.Clear();
            cbo.Items.Add("[ Seleccione ]");
            cbo.Items.Add("Activo");
            cbo.Items.Add("Inactivo");
            cbo.SelectedIndex = 0;
        }
        public void Limpiar_Controles(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is TabControl)
                {
                    foreach (TabPage tbc in ctrl.Controls)
                    {
                        if (tbc is TabPage)
                        {
                            foreach (GroupBox grp in tbc.Controls)
                            {
                                if (grp is GroupBox)
                                {
                                    foreach (Control txt in grp.Controls)
                                    {
                                        if (txt is TextBox)
                                        {
                                            txt.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Habilitar_Controles(Form frm, bool bolSw)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is TabControl)
                {
                    foreach (TabPage tbc in ctrl.Controls)
                    {
                        if (tbc is TabPage)
                        {
                            foreach (GroupBox grp in tbc.Controls)
                            {
                                if (grp is GroupBox)
                                {
                                    grp.Enabled = bolSw;
                                }
                            }
                        }
                    }
                }
            }
        }

        /*public int evaluarPeriodoCerrado(DateTime fecha)
        {
            NEG_ALM_MOVIMIENTOS negMov = new NEG_ALM_MOVIMIENTOS();
            string varCoEje = "EJ" + fecha.Year.ToString();
            string varCoPer = "EJ" + fecha.Year.ToString().Substring(2, 2) + fecha.Month.ToString("00");
            negMov.Opcion = 1;
            negMov.CoEje = varCoEje;
            negMov.CoPer = varCoPer;
            negMov.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dt = DAT_ALM_MOVIMIENTOS.SP_ERP_CON_EJERCICIO_PERIODO_CIERRE_PERIODO_LS(negMov);
            return dt.Rows.Count;
        }*/
        public string nombreMes(string nuMes)
        {
            string mes = "";
            switch (nuMes)
            {
                case "1":
                    mes = "ENERO"; break;
                case "2":
                    mes = "FEBRERO"; break;
                case "3":
                    mes = "MARZO"; break;
                case "4":
                    mes = "ABRIL"; break;
                case "5":
                    mes = "MAYO"; break;
                case "6":
                    mes = "JUNIO"; break;
                case "7":
                    mes = "JULIO"; break;
                case "8":
                    mes = "AGOSTO"; break;
                case "9":
                    mes = "SETIEMBRE"; break;
                case "10":
                    mes = "OCTUBRE"; break;
                case "11":
                    mes = "NOVIEMBRE"; break;
                case "12":
                    mes = "DICIEMBRE"; break;
            }
            return mes;
        }


        public void AbrirFormularioEnPanel(Form formHijo,Panel pnl)
        {
            // Limpia el panel si ya hay algo
            if (pnl.Controls.Count > 0)
                pnl.Controls.RemoveAt(0);
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnl.Controls.Add(formHijo);
            pnl.Tag = formHijo;

            formHijo.Show();
        }
        public void habilidarControles(Panel pnl,TabControl tabControl,bool sw)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enabled = sw; // o false para deshabilitarlos
                }
                if (ctrl is ComboBox)
                {
                    ctrl.Enabled = sw; // o false para deshabilitarlos
                }
                if (ctrl is DateTimePicker)
                {
                    ctrl.Enabled = sw; // o false para deshabilitarlos
                }
                foreach (TabPage tab in tabControl.TabPages)
                {
                    foreach (Control ctrl2 in tab.Controls)
                    {
                        if (ctrl2 is DataGridView)
                        {
                            DataGridView dgv = (DataGridView)ctrl2;
                            dgv.ReadOnly = !sw; // o false para deshabilitarlos
                        }
                    }
                }
            }


        }

        public void lipiarControles(Panel pnl, TabControl tabControl, bool sw)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
                if (ctrl is ComboBox)
                {
                    ComboBox cbo = (ComboBox)ctrl;
                    if (cbo.Items.Count > 0)
                    {
                        cbo.SelectedIndex = 0;
                    }
                    
                }
                if (ctrl is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)ctrl;
                    dtp.Value = DateTime.Now;
                }
                foreach (TabPage tab in tabControl.TabPages)
                {
                    foreach (Control ctrl2 in tab.Controls)
                    {
                        if (ctrl2 is DataGridView)
                        {
                            DataGridView dgv = (DataGridView)ctrl2;
                            dgv.AllowUserToAddRows = false;
                            dgv.Rows.Clear();
                            dgv.AllowUserToAddRows = true;
                        }
                    }
                }
            }

        }

        public void vistaBotones(int opc, Panel pnl,Button btnNuevo,Button btnGrabar,Button btnEditar,Button btnCancelar,Button btnImprimir)
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

                pnl.Controls.SetChildIndex(btnEditar, 0);
                pnl.Controls.SetChildIndex(btnCancelar, 0);
                pnl.Controls.SetChildIndex(btnImprimir, 0);
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

        public void habilitarBotonesVista(/*Button btnCajas, Button btnGrid,*/Button btnBuscar,TextBox txtBuscar, bool sw)
        {

            /*btnCajas.Visible = sw;
            btnGrid.Visible = sw;*/

            btnBuscar.Visible = sw;
            txtBuscar.Visible = sw;
        }

        public void estiloDataGridView(DataGridView dgv)
        {
            // Estilo general del DataGridView
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.Gainsboro;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersBorderStyle= DataGridViewHeaderBorderStyle.None;

            // Estilo del encabezado de columnas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243); // Azul Material
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // Estilo de filas (normales)
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254); // Azul claro selección
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);

            // Estilo de filas alternas (efecto zebra)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Borde de celdas
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Bordes suaves y márgenes visuales
            dgv.RowTemplate.Height = 32;





            /*// Estilo general
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;

            // Estilo de columnas (encabezado)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Gris claro
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Estilo de celdas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Fila alterna (para efecto "zebra")
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);*/
        }




    }



}
