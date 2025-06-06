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
    public partial class ERP_SOP_PRINCIPAL : Form
    {
        public ERP_SOP_PRINCIPAL()
        {
            InitializeComponent();
        }
        NEG_SOP_LOGIN neg = new NEG_SOP_LOGIN();
        private void ERP_SOP_PRINCIPAL_Load(object sender, EventArgs e)
        {
            dgvModulos.Rows.Clear();
            listar(1, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoUsu);
        }
        private void listar(int opcion, string coEmp, string coSuc, string coUsu)
        {
            try
            {

                neg.Opcion = 5;
                neg.CoEmp = coEmp;
                neg.CoSuc = coSuc;
                neg.CoUsu = coUsu;
                neg.CoMod = "0000";
                neg.CoMenu = "00000";
                neg.CoSubMenu = "000000";
                neg.CoSubSubMenu = "0000000";
                DataTable dtPermisos = DAT_SOP_LOGIN.SP_ERP_SOP_LISTAR_PERMISOS(neg);
                for (int t = 0; t < dtPermisos.Rows.Count; t++)
                {
                    dgvModulos.Rows.Add();
                    dgvModulos.Rows[t].Cells["nro"].Value = (t + 1);
                    dgvModulos.Rows[t].Cells["coMod"].Value=dtPermisos.Rows[t]["coMod"].ToString().Trim();
                    dgvModulos.Rows[t].Cells["noMod"].Value = dtPermisos.Rows[t]["noMod"].ToString().Trim();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        int cerrar = 1;
        private void ERP_SOP_PRINCIPAL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrar == 1)
            {
                if (MessageBox.Show("ESTÁ SEGURO DE CERRAR EL SISTEMA ?", "RIVERA DIESEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                    cerrar += 1;
                    Application.Exit();
                }

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
      
             if (MessageBox.Show("ESTÁ SEGURO DE CERRAR EL SISTEMA ?", "RIVERA DIESEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                cerrar += 1;
                Application.Exit();
             }
        }
        private void dgvModulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvModulos.Columns[e.ColumnIndex].Name == "btnAcceder")
                {
                    CLASES.ERP_GLOBALES.FechaPeriodo = dtpFechaPeriodo.Value;
                    if (dgvModulos.CurrentRow.Cells["noMod"].Value.ToString() == "SOPORTE")//0001
                    {
                        CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString().Trim();
                        SOPORTE.ERP_SOP_MENUPRINCIPAL frm = new SOPORTE.ERP_SOP_MENUPRINCIPAL();
                        frm.Show();
                    }
                    if (dgvModulos.CurrentRow.Cells["noMod"].Value.ToString() == "ADMINISTRACIÓN")//0002
                    {
                        CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString().Trim();
                        ADMINISTRACION.ERP_ADM_MENUPRINCIPAL frm = new ADMINISTRACION.ERP_ADM_MENUPRINCIPAL();  
                        
                        frm.Show();
                    }
                    /*if (dgvModulos.CurrentRow.Cells["noMod"].Value.ToString() == "INVENTARIOS")//
                    {
                        CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString().Trim();
                        INVERNTARIOS.ERP_ALM_MENUPRINCIPAL frm = new INVERNTARIOS.ERP_ALM_MENUPRINCIPAL();                   
                        frm.Show();
                    }
                    if (dgvModulos.CurrentRow.Cells["noMod"].Value.ToString() == "COMERCIAL")//
                    {
                        CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString().Trim();
                        COMERCIAL.ERP_VTA_MENUPRINCIPAL frm = new COMERCIAL.ERP_VTA_MENUPRINCIPAL();                   
                        frm.Show();
                    }
                    if (dgvModulos.CurrentRow.Cells["noMod"].Value.ToString() == "COMPRAS")//
                    {
                        CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString().Trim();
                        LOGISTICA.COMPRAS.ERP_COM_MENUPRINCIPAL frm = new LOGISTICA.COMPRAS.ERP_COM_MENUPRINCIPAL();                   
                        frm.Show();
                    }      */            
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
