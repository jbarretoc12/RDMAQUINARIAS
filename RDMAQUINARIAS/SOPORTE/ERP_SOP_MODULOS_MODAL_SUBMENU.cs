using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_MODULOS_MODAL_SUBMENU : Form
    {
        public ERP_SOP_MODULOS_MODAL_SUBMENU()
        {
            InitializeComponent();
        }
        NEG_SOP_MODULOS neg = new NEG_SOP_MODULOS();
        NEG_SOP_PERMISOS negPer = new NEG_SOP_PERMISOS();

        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        private void ERP_SOP_MODULOS_MODAL_SUBMENU_Load(object sender, EventArgs e)
        {
            #region LLENAR COMBO
            negPer.Opcion = 1;
            negPer.Criterio = "";
            negPer.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtMod = DAT_SOP_MODULOS.SP_ERP_SOP_MODULO(negPer);
            fun.llenar_Combo(dtMod, cbocoMod, "noMod", "coMod");
            cbocoMod.SelectedValue = CLASES.ERP_GLOBALES.CoMod;


            neg.Opcion = 2;
            neg.Criterio = CLASES.ERP_GLOBALES.CoMenu;
            neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            neg.CoMod = CLASES.ERP_GLOBALES.CoMod;
            DataTable dtMenu= DAT_SOP_MODULOS.SP_ERP_SOP_MENU(neg);
            fun.llenar_Combo(dtMenu, cbocoMenu, "noMenu", "coMenu");
            cbocoMenu.SelectedValue = CLASES.ERP_GLOBALES.CoMenu;
            #endregion

            if (CLASES.ERP_GLOBALES.AccionCrud == "EDITAR")
            {
                neg.Opcion = 2;
                neg.Criterio = CLASES.ERP_GLOBALES.Criterio;
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                neg.CoMod = CLASES.ERP_GLOBALES.CoMod;
                neg.CoMenu = CLASES.ERP_GLOBALES.CoMenu;
                DataTable dt = DAT_SOP_MODULOS.SP_ERP_SOP_SUBMENU(neg);
                if (dt.Rows.Count > 0)
                {
                    txtcoSubMenu.Text = dt.Rows[0]["coSubMenu"].ToString();
                    txtnoSubMenu.Text = dt.Rows[0]["noSubMenu"].ToString();
                    txtnuOrd.Text = dt.Rows[0]["nuOrd"].ToString();
                    chkForm.Checked = Convert.ToBoolean(dt.Rows[0]["form"]);
                }
            }
            txtnoSubMenu.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int opc = 0;
            if (CLASES.ERP_GLOBALES.AccionCrud == "NUEVO")
            {
                opc = 1;
            }
            if (CLASES.ERP_GLOBALES.AccionCrud == "EDITAR")
            {
                opc = 2;
            }
            grabar(opc);
        }
        private void grabar(int opc)
        {
            try
            {
                neg.Opc = opc;
                neg.CoSubMenu = txtcoSubMenu.Text;
                neg.NoSubMenu = txtnoSubMenu.Text;
                neg.CoMod = cbocoMod.SelectedValue.ToString();
                neg.CoMenu = cbocoMenu.SelectedValue.ToString();
                neg.NuOrd = Convert.ToInt32(txtnuOrd.Text);
                neg.Form = chkForm.Checked;
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                neg.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                DAT_SOP_MODULOS.SP_ERP_SOP_SUBMENU_GB(neg);
                CLASES.ERP_GLOBALES.Accion = 1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
