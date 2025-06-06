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
    public partial class ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO : Form
    {
        public ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO()
        {
            InitializeComponent();
        }
        NEG_SOP_LOGIN negMod = new NEG_SOP_LOGIN();
        private void ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO_Activated(object sender, EventArgs e)
        {
            //this.SendToBack();
        }

        private void ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO_Load(object sender, EventArgs e)
        {
            
            listar(1, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoUsu);
            txtFiltro.Select();
        }
        private void listar(int opcion, string coEmp, string coSuc, string coUsu)
        {
            try
            {
                negMod.Opcion = 1;
                negMod.Criterio = txtFiltro.Text;
                negMod.CoEmp = coEmp;
                negMod.CoSuc = coSuc;
                negMod.CoUsu = coUsu;
                negMod.CoMod = "0000";
                negMod.CoMenu = "00000";
                negMod.CoSubMenu = "000000";
                negMod.CoSubSubMenu = "0000000";
                DataTable dtPermisos = DAT_SOP_LOGIN.SP_ERP_SOP_LISTAR_PERMISOS_LISTAR_MODULOS(negMod);
                panelFlowModulos.Controls.Clear();
                for (int t = 0; t < dtPermisos.Rows.Count; t++)
                {
                    Button btnModulo = new Button();

                    btnModulo.Name = dtPermisos.Rows[t]["coMod"].ToString().Trim();
                    btnModulo.Text = dtPermisos.Rows[t]["noMod"].ToString().Trim();
                    btnModulo.Width = 100;
                    btnModulo.Height = 100;
                    btnModulo.TextAlign = ContentAlignment.BottomCenter;
                    btnModulo.TextImageRelation = TextImageRelation.ImageAboveText;
                    btnModulo.BackColor = Color.White;
                    btnModulo.Font = new Font(familyName: "Segoe UI", 7);
                    btnModulo.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnModulo.Click += new EventHandler(btnModulo_Click);
                    panelFlowModulos.Controls.Add(btnModulo);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModulo_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string coMod = btn.Name;
                string noMod = btn.Text;
                CLASES.ERP_GLOBALES.CoMod = coMod;
                CLASES.ERP_GLOBALES.NoMod = noMod;
                if (CLASES.ERP_GLOBALES.CoMod == "0001")
                {
                    SOPORTE.ERP_SOP_MENUPRINCIPAL frm = new SOPORTE.ERP_SOP_MENUPRINCIPAL();
                    frm.Show();
                }
                if (CLASES.ERP_GLOBALES.CoMod == "0005")
                {
                    INVENTARIO.ERP_ALM_MENUPRINCIPAL frm = new INVENTARIO.ERP_ALM_MENUPRINCIPAL();
                    frm.Show();
                }
                if (CLASES.ERP_GLOBALES.CoMod == "0006")
                {
                    COMPRAS.ERP_COM_MENUPRINCIPAL frm = new COMPRAS.ERP_COM_MENUPRINCIPAL();
                    frm.Show();
                }                
                
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            listar(1, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoUsu);
        }
        int cerrar = 1;
        private void ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
