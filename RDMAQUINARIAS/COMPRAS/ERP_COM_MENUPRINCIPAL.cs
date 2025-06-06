using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;
using RDMAQUINARIAS.INVENTARIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDMAQUINARIAS.COMPRAS
{
    public partial class ERP_COM_MENUPRINCIPAL: Form
    {
        public ERP_COM_MENUPRINCIPAL()
        {
            InitializeComponent();
            //ERP_COM_MENUPRINCIPAL_PENDIENTES frm = new ERP_COM_MENUPRINCIPAL_PENDIENTES();
            ERP_COM_SOLICITUD_PEDIDO frm = new ERP_COM_SOLICITUD_PEDIDO();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        NEG_SOP_LOGIN neg = new NEG_SOP_LOGIN();
        private void ERP_COM_MENUPRINCIPAL_Load(object sender, EventArgs e)
        {
            
        }
        private void listar(int opcion, string coEmp, string coSuc, string coUsu)
        {
            try
            {

                /*neg.Opcion = 5;
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
                    ToolStripMenuItem modulo = new ToolStripMenuItem();
                    modulo.Name = dtPermisos.Rows[t]["coMod"].ToString().Trim();
                    modulo.Text = dtPermisos.Rows[t]["noMod"].ToString().Trim();
                    mnuPrincipal.Items.Add(modulo);*/

                neg.Opcion = 6;
                neg.CoEmp = coEmp;
                neg.CoSuc = coSuc;
                neg.CoUsu = coUsu;
                neg.CoMod = CLASES.ERP_GLOBALES.CoMod; //"0004"; //dtPermisos.Rows[t]["coMod"].ToString();
                neg.CoMenu = "00000";
                neg.CoSubMenu = "000000";
                neg.CoSubSubMenu = "0000000";
                DataTable dtMenu = DAT_SOP_LOGIN.SP_ERP_SOP_LISTAR_PERMISOS(neg);
                for (int h = 0; h < dtMenu.Rows.Count; h++)
                {
                    ToolStripMenuItem modulo = new ToolStripMenuItem();
                    modulo.Name = dtMenu.Rows[h]["coMenu"].ToString().Trim();
                    modulo.Text = dtMenu.Rows[h]["noMenu"].ToString().Trim();
                    mnuPrincipal.Items.Add(modulo);

                    //SUB MENUS
                    neg.Opcion = 7;
                    neg.CoUsu = coUsu;
                    neg.CoEmp = coEmp;
                    neg.CoSuc = coSuc;
                    neg.CoMod = CLASES.ERP_GLOBALES.CoMod;//"0004";//dtPermisos.Rows[t]["coMod"].ToString();
                    neg.CoMenu = dtMenu.Rows[h]["coMenu"].ToString();
                    neg.CoSubMenu = "000000";
                    neg.CoSubSubMenu = "0000000";
                    DataTable dtSubMenu = DAT_SOP_LOGIN.SP_ERP_SOP_LISTAR_PERMISOS(neg);
                    for (int i = 0; i < dtSubMenu.Rows.Count; i++)
                    {
                        ToolStripMenuItem subMenu = new ToolStripMenuItem();
                        subMenu.Name = dtSubMenu.Rows[i]["coSubMenu"].ToString().Trim();
                        subMenu.Text = dtSubMenu.Rows[i]["noSubMenu"].ToString().Trim();
                        subMenu.Click += new EventHandler(subMenuClick);
                        //menu.DropDownItems.Add(subMenu);
                        modulo.DropDownItems.Add(subMenu);

                        //SUB SUB MENUS
                        neg.Opcion = 8;
                        neg.CoEmp = coEmp;
                        neg.CoSuc = coSuc;
                        neg.CoUsu = coUsu;
                        neg.CoMod = CLASES.ERP_GLOBALES.CoMod;//"0004";//dtPermisos.Rows[t]["coMod"].ToString();
                        neg.CoMenu = dtMenu.Rows[h]["coMenu"].ToString();
                        neg.CoSubMenu = dtSubMenu.Rows[i]["coSubMenu"].ToString();
                        neg.CoSubSubMenu = "0000000";
                        DataTable dtSubSubMenu = DAT_SOP_LOGIN.SP_ERP_SOP_LISTAR_PERMISOS(neg);
                        for (int j = 0; j < dtSubSubMenu.Rows.Count; j++)
                        {
                            ToolStripMenuItem subSubMenu = new ToolStripMenuItem();
                            subSubMenu.Name = dtSubSubMenu.Rows[j]["coSubSubMenu"].ToString().Trim();
                            subSubMenu.Text = dtSubSubMenu.Rows[j]["noSubSubMenu"].ToString().Trim();
                            //subSubMenu.Click += new EventHandler(subSubMenuClick);
                            subMenu.DropDownItems.Add(subSubMenu);
                        }
                    }
                }
                /*}*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void subMenuClick(object sender, EventArgs e)
        {
            try
            {
                CLASES.ERP_GLOBALES.nivelPermiso = 3;
                CLASES.ERP_GLOBALES.formpermisos = sender.ToString().Trim();
                if (sender.ToString().Trim() == "Registrar Producto")
                {
                    AbrirFormulario_SubMenu(new INVENTARIO.ERP_ALM_PRODUCTOS(), sender.ToString().Trim());
                }
                if (sender.ToString().Trim() == "Solicitud de Presupuesto")
                {
                    AbrirFormulario_SubMenu(new COMPRAS.ERP_COM_SOLICITUD_PEDIDO(), sender.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AbrirFormulario_SubMenu(object formHijo, string formPermisos)
        {
            CLASES.ERP_GLOBALES.formpermisos = formPermisos;
            Form frm = formHijo as Form;
            frm.MdiParent = this;
            frm.Show();
        }

        private void ERP_COM_MENUPRINCIPAL_Shown(object sender, EventArgs e)
        {
            mnuPrincipal.Items.Clear();
            listar(1, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoUsu);
        }
    }
}
