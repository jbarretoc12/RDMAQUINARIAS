using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;
namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_MODULOS_MODAL_MODULO :  Form
    {
        public ERP_SOP_MODULOS_MODAL_MODULO()
        {
            InitializeComponent();
        }
        NEG_SOP_PERMISOS neg = new NEG_SOP_PERMISOS();
        NEG_SOP_MODULOS negMod = new NEG_SOP_MODULOS();
        private void ERP_SOP_MODULOS_MODAL_Load(object sender, EventArgs e)
        {
            if (CLASES.ERP_GLOBALES.AccionCrud == "NUEVO")
            {
                neg.Opcion = 3;
                neg.Criterio = "";
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dt = DAT_SOP_MODULOS.SP_ERP_SOP_MODULO(neg);
                if (dt.Rows.Count > 0)
                {
                    txtcoMod.Text = dt.Rows[0]["coMod"].ToString();
                }
            }

            if (CLASES.ERP_GLOBALES.AccionCrud == "EDITAR")
            {
                lblTitulo.Text = "ACTUALIZAR REGISTRO";
                neg.Opcion = 2;
                neg.Criterio = CLASES.ERP_GLOBALES.Criterio;
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    //negMod.CoMod = CLASES.ERP_GLOBALES.CoMod;
                DataTable dt = DAT_SOP_MODULOS.SP_ERP_SOP_MODULO(neg);
                if (dt.Rows.Count > 0)
                {
                    txtcoMod.Text = dt.Rows[0]["coMod"].ToString();
                    txtnoMod.Text = dt.Rows[0]["noMod"].ToString();
                    txtnuOrd.Text = dt.Rows[0]["nuOrd"].ToString();
                    chkForm.Checked = Convert.ToBoolean(dt.Rows[0]["form"]);
                }
            }
            txtnoMod.Select();
        }

        private void btnNuevoModulo_Click(object sender, EventArgs e)
        {

        }
        private void grabar(int opc)
        {
            try
            {
                negMod.Opc = opc;
                negMod.CoMod = txtcoMod.Text;
                negMod.NoMod = txtnoMod.Text;
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                negMod.Form = chkForm.Checked;
                negMod.NuOrd = Convert.ToInt32(txtnuOrd.Text);
                DAT_SOP_MODULOS.SP_ERP_SOP_MODULO_GB(negMod);
                CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
                CLASES.ERP_GLOBALES.NoMod = txtnoMod.Text;
                CLASES.ERP_GLOBALES.Accion = 1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
