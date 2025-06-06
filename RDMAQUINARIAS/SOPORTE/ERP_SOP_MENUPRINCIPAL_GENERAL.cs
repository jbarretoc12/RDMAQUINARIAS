using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;
using System;
using System.Data;
using System.Windows.Forms;

namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_MENUPRINCIPAL_GENERAL : Form //DevComponents.DotNetBar.Office2007Form 
    {
        public ERP_SOP_MENUPRINCIPAL_GENERAL()
        {
            InitializeComponent();
            /*ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO frm = new ERP_SOP_MENUPRINCIPAL_GENERAL_FONDO();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();*/
        }
        NEG_SOP_LOGIN neg = new NEG_SOP_LOGIN();
        private void ERP_PRI_MENUPRINCIPAL_Load(object sender, EventArgs e)
        {
            //cargarForm();
            lblnoMod.Text = CLASES.ERP_GLOBALES.NoMod;
            mnuPrincipal.Items.Clear();
            listar(1, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoUsu);
        }
        private void cargarForm()
        {

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
                    ToolStripMenuItem modulo = new ToolStripMenuItem();
                    modulo.Name = dtPermisos.Rows[t]["coMod"].ToString().Trim();
                    modulo.Text = dtPermisos.Rows[t]["noMod"].ToString().Trim();
                    mnuPrincipal.Items.Add(modulo);


                    neg.Opcion = 6;
                    neg.CoEmp = coEmp;
                    neg.CoSuc = coSuc;
                    neg.CoUsu = coUsu;
                    neg.CoMod = dtPermisos.Rows[t]["coMod"].ToString();
                    neg.CoMenu = "00000";
                    neg.CoSubMenu = "000000";
                    neg.CoSubSubMenu = "0000000";
                    DataTable dtMenu = DAT_SOP_LOGIN.SP_ERP_SOP_LISTAR_PERMISOS(neg);
                    for (int h = 0; h < dtMenu.Rows.Count; h++)
                    {
                        ToolStripMenuItem menu = new ToolStripMenuItem();
                        menu.Name = dtMenu.Rows[h]["coMenu"].ToString().Trim();
                        menu.Text = dtMenu.Rows[h]["noMenu"].ToString().Trim();
                        //menu.Click += new EventHandler(menuClick);
                        modulo.DropDownItems.Add(menu);

                        //SUB MENUS
                        neg.Opcion = 7;
                        neg.CoUsu = coUsu;
                        neg.CoEmp = coEmp;
                        neg.CoSuc = coSuc;
                        neg.CoMod = dtPermisos.Rows[t]["coMod"].ToString();
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
                            menu.DropDownItems.Add(subMenu);

                            //SUB SUB MENUS
                            neg.Opcion = 8;
                            neg.CoEmp = coEmp;
                            neg.CoSuc = coSuc;
                            neg.CoUsu = coUsu;
                            neg.CoMod = dtPermisos.Rows[t]["coMod"].ToString();
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
                }
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
                if (sender.ToString().Trim() == "Gestionar Empresas")
                {
                    AbrirFormulario_SubMenu(new ADMINISTRACION.ERP_ADM_EMPRESA(), sender.ToString().Trim());
                }
                if (sender.ToString().Trim() == "Accesos de Usuario")
                {
                    AbrirFormulario_SubMenu(new SOPORTE.ERP_SOP_PERMISOS(), sender.ToString().Trim());
                }
                if (sender.ToString().Trim() == "Gestionar Módulos")
                {
                    AbrirFormulario_SubMenu(new SOPORTE.ERP_SOP_MODULOS(), sender.ToString().Trim());
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AbrirFormulario_SubMenu(object formHijo,string formPermisos)
        {
            CLASES.ERP_GLOBALES.formpermisos = formPermisos;
            Form frm = formHijo as Form;
            frm.MdiParent = this;
            frm.Show();
        }

        //int cerrar = 1;
        private void ERP_PRI_MENUPRINCIPAL_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (cerrar == 1)
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
            }*/
        }
    }
}
