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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_PERMISOS : Form
    {
        public ERP_SOP_PERMISOS()
        {
            InitializeComponent();
        }
        NEG_ADM_EMPRESA neg = new NEG_ADM_EMPRESA();
        NEG_ADM_SUCURSAL negSuc = new NEG_ADM_SUCURSAL();
        NEG_SOP_USUARIOS negUsu = new NEG_SOP_USUARIOS();
        NEG_SOP_PERMISOS negPer = new NEG_SOP_PERMISOS();
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        string formularioPermisos = "";
        private void ERP_PRI_PERMISOS_Load(object sender, EventArgs e)
        {
            formularioPermisos = "Accesos de Usuario";
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

                #region LISTAR SUCURSAL
                negSuc.Opcion = 1;
                negSuc.Criterio = CLASES.ERP_GLOBALES.CoSuc;
                negSuc.CoEmp = cbocoEmp.SelectedValue.ToString();
                DataTable dtSuc = DAT_ADM_SUCURSAL.SP_ERP_ADM_SUCURSAL_LS(negSuc);
                fun.llenar_Combo(dtSuc, cboSucursal, "noSuc", "coSuc");
                #endregion

                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, true, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, formularioPermisos);
                fun.Limpiar_Controles(this);
                fun.Habilitar_Controles(this, false);
                trvPermisos.Nodes.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtnoUsu_TextChanged(object sender, EventArgs e)
        {
            buscarUsuario();
        }
        private void buscarUsuario()
        {
            try
            {
                negUsu.Opcion = 1;
                negUsu.Criterio = txtnoUsu.Text;
                negUsu.CoEmp = cbocoEmp.SelectedValue.ToString();
                negUsu.CoSuc = cboSucursal.SelectedValue.ToString();
                DataTable dt = DAT_SOP_USUARIOS.SP_ERP_SOP_USUARIO_BUSCAR(negUsu);
                dgvUsuarios.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvUsuarios.Rows.Add();
                        dgvUsuarios.Rows[i].Cells["coUsu"].Value = dt.Rows[i]["coUsu"].ToString().Trim();
                        dgvUsuarios.Rows[i].Cells["noUsu"].Value = dt.Rows[i]["noUsu"].ToString().Trim();
                        dgvUsuarios.Rows[i].Cells["coSuc"].Value = dt.Rows[i]["coSuc"].ToString().Trim();
                    }
                    dgvUsuarios.Visible = true;
                }
                else
                {
                    dgvUsuarios.Visible = false;
                }

                if (txtnoUsu.Text.Trim() == "")
                {
                    dgvUsuarios.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarUsuario();

        }
        private void mostrarUsuario()
        {
            txtUsu.Text = dgvUsuarios.CurrentRow.Cells["coUsu"].Value.ToString().Trim();
            txtnoUsu.Text = dgvUsuarios.CurrentRow.Cells["noUsu"].Value.ToString().Trim();
            dgvUsuarios.Visible = false;
            btnBuscar.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*if (cbocoEmp.SelectedIndex == 0)
            {
                MessageBox.Show("SELECCIONAR LA EMPRESA.", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboSucursal.SelectedIndex == 0)
            {
                MessageBox.Show("SELECCIONAR LA SUCURSAL.", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/
            if (txtUsu.Text.Trim() == "" || txtnoUsu.Text.Trim()=="")
            {
                MessageBox.Show("SELECCIONAR USUARIO.", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            buscar();
        }

        private void buscar()
        {
            /*if (cbocoEmp.SelectedIndex == 0)
            {
                MessageBox.Show("* SELECCIONAR LA EMPRESA", "RIVERA DIESEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbocoEmp.Select();
                return;
            }
            if (cboSucursal.SelectedIndex == 0)
            {
                MessageBox.Show("* SELECCIONAR LA SUCURSAL", "RIVERA DIESEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSucursal.Select();
                return;
            }
            if (txtUsu.Text.Trim() == "")
            {
                MessageBox.Show("* SELECCIONAR EL USUARIO", "RIVERA DIESEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsu.Select();
                return;
            }*/

            listar(0, cbocoEmp.SelectedValue.ToString(), cboSucursal.SelectedValue.ToString(), txtUsu.Text);
            listar(1, cbocoEmp.SelectedValue.ToString(), cboSucursal.SelectedValue.ToString(), txtUsu.Text);
            /*trvPermisos.CheckBoxes = true;
            trvPermisos.Nodes.Add("Uno");
            trvPermisos.Nodes.Add("Uno").Nodes.Add("Dos").Nodes.Add("Tres");*/
        }

        private void listar(int opcion, string coEmp, string coSuc, string coUsu)
        {
            try
            {
                TreeNode tn;
                negPer.Opcion = opcion;
                negPer.CoEmp = coEmp;
                negPer.CoSuc = coSuc;
                negPer.CoUsu = coUsu;
                negPer.CoMod = "0000";
                negPer.CoMenu = "00000";
                negPer.CoSubMenu = "000000";
                negPer.CoSubSubMenu = "0000000";
                DataTable dtPermisos = DAT_SOP_PERMISOS.SP_ERP_SOP_LISTAR_PERMISOS(negPer);
                trvPermisos.CheckBoxes = true;
                trvPermisos.Nodes.Clear();
                //LISTAR PRIMER NODO DEL TREEVIEW
                for (int t = 0; t < dtPermisos.Rows.Count; t++)
                {
                    tn = new TreeNode();
                    tn.Tag = dtPermisos.Rows[t]["coMod"].ToString();
                    tn.Text = dtPermisos.Rows[t]["noMod"].ToString();
                    if (Convert.ToBoolean(dtPermisos.Rows[t]["stMod"]) == true)
                    {
                        tn.Checked = true;
                    }
                    else
                    {
                        tn.Checked = false;
                    }
                    trvPermisos.Nodes.Add(tn);

                    //MENUS
                    negPer.Opcion = 2;
                    negPer.CoEmp = coEmp;
                    negPer.CoSuc = coSuc;
                    negPer.CoUsu = coUsu;
                    negPer.CoMod = dtPermisos.Rows[t]["coMod"].ToString();
                    negPer.CoMenu = "00000";
                    negPer.CoSubMenu = "000000";
                    negPer.CoSubSubMenu = "0000000";
                    DataTable dtMenu = DAT_SOP_PERMISOS.SP_ERP_SOP_LISTAR_PERMISOS(negPer);
                    for (int h = 0; h < dtMenu.Rows.Count; h++)
                    {
                        tn = new TreeNode();
                        tn.Tag = dtMenu.Rows[h]["coMenu"].ToString();
                        tn.Text = dtMenu.Rows[h]["noMenu"].ToString();
                        if (Convert.ToBoolean(dtMenu.Rows[h]["stMenu"]) == true)
                        {
                            tn.Checked = true;
                        }
                        else
                        {
                            tn.Checked = false;
                        }
                        tn.ForeColor = Color.Blue;
                        trvPermisos.Nodes[t].Nodes.Add(tn);

                        //SUB MENUS
                        negPer.Opcion = 3;
                        negPer.CoUsu = coUsu;
                        negPer.CoEmp = coEmp;
                        negPer.CoSuc = coSuc;
                        negPer.CoMod = dtPermisos.Rows[t]["coMod"].ToString();
                        negPer.CoMenu = dtMenu.Rows[h]["coMenu"].ToString();
                        negPer.CoSubMenu = "000000";
                        negPer.CoSubSubMenu = "0000000";
                        DataTable dtSubMenu = DAT_SOP_PERMISOS.SP_ERP_SOP_LISTAR_PERMISOS(negPer);
                        for (int i = 0; i < dtSubMenu.Rows.Count; i++)
                        {
                            tn = new TreeNode();
                            tn.Tag = dtSubMenu.Rows[i]["coSubMenu"].ToString();
                            tn.Text = dtSubMenu.Rows[i]["noSubMenu"].ToString();
                            if (Convert.ToBoolean(dtSubMenu.Rows[i]["stSubMenu"]) == true)
                            {
                                tn.Checked = true;
                            }
                            else
                            {
                                tn.Checked = false;
                            }
                            tn.ForeColor = Color.DarkGreen;
                            trvPermisos.Nodes[t].Nodes[h].Nodes.Add(tn);

                            //SUB SUB MENUS
                            negPer.Opcion = 4;
                            negPer.CoEmp = coEmp;
                            negPer.CoSuc = coSuc;
                            negPer.CoUsu = coUsu;
                            negPer.CoMod = dtPermisos.Rows[t]["coMod"].ToString();
                            negPer.CoMenu = dtMenu.Rows[h]["coMenu"].ToString();
                            negPer.CoSubMenu = dtSubMenu.Rows[i]["coSubMenu"].ToString();
                            negPer.CoSubSubMenu = "0000000";
                            DataTable dtSubSubMenu = DAT_SOP_PERMISOS.SP_ERP_SOP_LISTAR_PERMISOS(negPer);
                            for (int j = 0; j < dtSubSubMenu.Rows.Count; j++)
                            {
                                tn = new TreeNode();
                                tn.Tag = dtSubSubMenu.Rows[j]["coSubSubMenu"].ToString();
                                tn.Text = dtSubSubMenu.Rows[j]["noSubSubMenu"].ToString();
                                if (Convert.ToBoolean(dtSubSubMenu.Rows[j]["stSubSubMenu"]) == true)
                                {
                                    tn.Checked = true;
                                }
                                else
                                {
                                    tn.Checked = false;
                                }
                                tn.ForeColor = Color.Purple;
                                trvPermisos.Nodes[t].Nodes[h].Nodes[i].Nodes.Add(tn);
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

        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            
        }
        private void grabar()
        {
            try
            {
                if (trvPermisos.Nodes.Count > 0)
                {
                    for (int t = 0; t < trvPermisos.Nodes.Count; t++)
                    {
                        negPer.Opc = 1;
                        negPer.CoUsu = txtUsu.Text;
                        negPer.CoEmp = cbocoEmp.SelectedValue.ToString();
                        negPer.CoSuc = cboSucursal.SelectedValue.ToString();
                        negPer.CoMod = trvPermisos.Nodes[t].Tag.ToString();
                        negPer.CoMenu = "00000";
                        negPer.CoSubMenu = "000000";
                        negPer.CoSubSubMenu = "0000000";
                        if (Convert.ToBoolean(trvPermisos.Nodes[t].Checked) == true)
                        {
                            negPer.Estado = true;
                        }
                        else
                        {
                            negPer.Estado = false;
                        }

                        DAT_SOP_PERMISOS.SP_ERP_SOP_GRABAR_PERMISOS(negPer);
                        /*MENU*/

                        for (int h = 0; h < trvPermisos.Nodes[t].Nodes.Count; h++)
                        {
                            negPer.Opc = 2;
                            negPer.CoUsu = txtUsu.Text;
                            negPer.CoEmp = cbocoEmp.SelectedValue.ToString();
                            negPer.CoSuc = cboSucursal.SelectedValue.ToString();
                            negPer.CoMod = trvPermisos.Nodes[t].Tag.ToString();
                            negPer.CoMenu = trvPermisos.Nodes[t].Nodes[h].Tag.ToString();
                            negPer.CoSubMenu = "000000";
                            negPer.CoSubSubMenu = "0000000";
                            if (Convert.ToBoolean(trvPermisos.Nodes[t].Nodes[h].Checked) == true)
                            {
                                negPer.Estado = true;
                            }
                            else
                            {
                                negPer.Estado = false;
                            }
                            DAT_SOP_PERMISOS.SP_ERP_SOP_GRABAR_PERMISOS(negPer);

                            for (int i = 0; i < trvPermisos.Nodes[t].Nodes[h].Nodes.Count; i++)
                            {
                                negPer.Opc = 3;
                                negPer.CoUsu = txtUsu.Text;
                                negPer.CoEmp = cbocoEmp.SelectedValue.ToString();
                                negPer.CoSuc = cboSucursal.SelectedValue.ToString();
                                negPer.CoMod = trvPermisos.Nodes[t].Tag.ToString();
                                negPer.CoMenu = trvPermisos.Nodes[t].Nodes[h].Tag.ToString();
                                negPer.CoSubMenu = trvPermisos.Nodes[t].Nodes[h].Nodes[i].Tag.ToString();
                                negPer.CoSubSubMenu = "0000000";
                                if (Convert.ToBoolean(trvPermisos.Nodes[t].Nodes[h].Nodes[i].Checked) == true)
                                {
                                    negPer.Estado = true;
                                }
                                else
                                {
                                    negPer.Estado = false;
                                }
                                DAT_SOP_PERMISOS.SP_ERP_SOP_GRABAR_PERMISOS(negPer);

                                for (int j = 0; j < trvPermisos.Nodes[t].Nodes[h].Nodes[i].Nodes.Count; j++)
                                {
                                    negPer.Opc = 4;
                                    negPer.CoUsu = txtUsu.Text;
                                    negPer.CoEmp = cbocoEmp.SelectedValue.ToString();
                                    negPer.CoSuc = cboSucursal.SelectedValue.ToString();
                                    negPer.CoMod = trvPermisos.Nodes[t].Tag.ToString();
                                    negPer.CoMenu = trvPermisos.Nodes[t].Nodes[h].Tag.ToString();
                                    negPer.CoSubMenu = trvPermisos.Nodes[t].Nodes[h].Nodes[i].Tag.ToString();
                                    negPer.CoSubSubMenu = trvPermisos.Nodes[t].Nodes[h].Nodes[i].Nodes[j].Tag.ToString();
                                    if (Convert.ToBoolean(trvPermisos.Nodes[t].Nodes[h].Nodes[i].Nodes[j].Checked) == true)
                                    {
                                        negPer.Estado = true;
                                    }
                                    else
                                    {
                                        negPer.Estado = false;
                                    }
                                    DAT_SOP_PERMISOS.SP_ERP_SOP_GRABAR_PERMISOS(negPer);
                                }
                            }
                        }
                    }
                    listar(0, cbocoEmp.SelectedValue.ToString(), cboSucursal.SelectedValue.ToString(), txtUsu.Text);
                    //listar(1, cboEmpresa.SelectedValue.ToString(), cboSucursal.SelectedValue.ToString(), txtUsu.Text);
                    cargarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trvPermisos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                int cantCod = e.Node.Tag.ToString().Length;
                string codNode = e.Node.Tag.ToString();
                int opcion = 0;

                switch (cantCod)
                {
                    case 4 :
                        opcion = 1; //MODULO
                        break;
                    case 5:
                        opcion = 2; //MENU
                        break;
                    case 6:
                        opcion = 3; //SUBMENU
                        break;
                    case 7:
                        opcion = 4; //SUB SUBMENU
                        break;
                }

                negPer.Opcion = opcion;
                negPer.Criterio = codNode;
                negPer.CoUsu = txtUsu.Text;
                negPer.CoSuc = cboSucursal.SelectedValue.ToString();
                negPer.CoEmp = cbocoEmp.SelectedValue.ToString();
                DataTable dt=DAT_SOP_PERMISOS.SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO(negPer);
                if (dt.Rows.Count > 0)
                {
                    CLASES.ERP_GLOBALES.Criterio = dt.Rows[0]["codForm"].ToString();
                    CLASES.ERP_GLOBALES.Opcion = opcion.ToString();
                    CLASES.ERP_GLOBALES.CodigoUsuario = txtUsu.Text;
                    CLASES.ERP_GLOBALES.CodigoSucursal = cboSucursal.SelectedValue.ToString();
                    CLASES.ERP_GLOBALES.CodigoEmpresa=cbocoEmp.SelectedValue.ToString();
                    ERP_SOP_PERMISOS_FORMULARIO frm = new ERP_SOP_PERMISOS_FORMULARIO();
                    frm.ShowDialog();
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

        private void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, false, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, formularioPermisos);
                fun.Habilitar_Controles(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarForm();
        }
    }
}
