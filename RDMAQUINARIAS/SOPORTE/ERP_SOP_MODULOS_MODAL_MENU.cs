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
    public partial class ERP_SOP_MODULOS_MODAL_MENU : Form
    {
        public ERP_SOP_MODULOS_MODAL_MENU()
        {
            InitializeComponent();
        }
        NEG_SOP_MODULOS negMod= new NEG_SOP_MODULOS();
        NEG_SOP_PERMISOS neg = new NEG_SOP_PERMISOS();
        CLASES.ERP_FUNCIONES fun=new CLASES.ERP_FUNCIONES();
        private void ERP_SOP_MODULOS_MODAL_MENU_Load(object sender, EventArgs e)
        {
            #region LLENAR COMBO
            neg.Opcion = 1;
            neg.Criterio = "";
            neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtMod = DAT_SOP_MODULOS.SP_ERP_SOP_MODULO(neg);
            fun.llenar_Combo(dtMod, cbocoMod, "noMod", "coMod");
            cbocoMod.SelectedValue = CLASES.ERP_GLOBALES.CoMod;
            #endregion

            if (CLASES.ERP_GLOBALES.AccionCrud == "EDITAR")
            {
                negMod.Opcion = 2;
                negMod.Criterio = CLASES.ERP_GLOBALES.Criterio;
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoMod=CLASES.ERP_GLOBALES.CoMod;
                DataTable dt = DAT_SOP_MODULOS.SP_ERP_SOP_MENU(negMod);
                if (dt.Rows.Count > 0)
                {
                    txtcoMenu.Text = dt.Rows[0]["coMenu"].ToString();
                    txtnoMenu.Text = dt.Rows[0]["noMenu"].ToString();
                    txtnuOrd.Text = dt.Rows[0]["nuOrd"].ToString();
                    chkForm.Checked = Convert.ToBoolean(dt.Rows[0]["form"]);
                }
            }
            txtnoMenu.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (CLASES.ERP_GLOBALES.AccionCrud == "NUEVO")
            {
                grabar(1);
            }
            if (CLASES.ERP_GLOBALES.AccionCrud == "EDITAR")
            {
                grabar(2);
            }
        }
        private void grabar(int opc)
        {
            try
            {
                negMod.Opc = opc;
                negMod.CoMenu=txtcoMenu.Text;
                negMod.NoMenu = txtnoMenu.Text;
                negMod.CoMod = cbocoMod.SelectedValue.ToString();
                negMod.Form= chkForm.Checked;   
                negMod.NuOrd=Convert.ToInt32(txtnuOrd.Text);
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                DAT_SOP_MODULOS.SP_ERP_SOP_MENU_GB(negMod);
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
