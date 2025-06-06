using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS.ADMINISTRACION;
using CAPA_NEGOCIOS.ADMINISTRACION;
using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;

namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_LOGIN : Form
    {
        public ERP_SOP_LOGIN()
        {
            InitializeComponent();
        }
        NEG_ADM_EMPRESA neg = new NEG_ADM_EMPRESA();
        NEG_SOP_LOGIN negLog = new NEG_SOP_LOGIN();
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        private void ERP_PRI_LOGIN_Load(object sender, EventArgs e)
        {
            cargarForm();
        }
        private void cargarForm()
        {
            try
            {
                #region LISTAR EMPRESA
                neg.Opcion = 1;
                neg.Criterio = "";
                DataTable dtEmp = DAT_ADM_EMPRESA.SP_ERP_ADM_EMPRESA_LS(neg);
                fun.llenar_Combo(dtEmp, cbocoEmp, "noEmp", "coEmp");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            verificar();
        }
        private void verificar()
        {
            try
            {
                negLog.CoEmp = cbocoEmp.SelectedValue.ToString().Trim();
                negLog.CoUsu = txtCoUsu.Text.Trim();
                negLog.NoClave = txtNoCla.Text.Trim();
                DataTable dt = DAT_SOP_LOGIN.SP_ERP_SOP_LOGEO(negLog);
                if (dt.Rows.Count == 1)
                {
                    CLASES.ERP_GLOBALES.CoUsu = dt.Rows[0]["coUsu"].ToString().Trim();
                    CLASES.ERP_GLOBALES.NoUsu = dt.Rows[0]["noUsu"].ToString().Trim();
                    CLASES.ERP_GLOBALES.CoEmp = dt.Rows[0]["coEmp"].ToString().Trim();
                    CLASES.ERP_GLOBALES.NoEmp = dt.Rows[0]["NoEmp"].ToString().Trim();
                    CLASES.ERP_GLOBALES.CoSuc = dt.Rows[0]["coSuc"].ToString().Trim();
                    CLASES.ERP_GLOBALES.NoSuc = dt.Rows[0]["noSuc"].ToString().Trim();
                    CLASES.ERP_GLOBALES.CoAre = dt.Rows[0]["coAre"].ToString().Trim();
                    CLASES.ERP_GLOBALES.NoAre = dt.Rows[0]["deAre"].ToString().Trim();
                    CLASES.ERP_GLOBALES.CoCar = dt.Rows[0]["coCar"].ToString().Trim();
                    CLASES.ERP_GLOBALES.NoCar = dt.Rows[0]["noCar"].ToString().Trim();
                    CLASES.ERP_GLOBALES.Accion = 1;
                    //ERP_SOP_MENUPRINCIPAL_GENERAL frm = new ERP_SOP_MENUPRINCIPAL_GENERAL();
                    ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO frm = new ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO();
                    //ERP_SOP_PRINCIPAL frm = new ERP_SOP_PRINCIPAL();
                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
