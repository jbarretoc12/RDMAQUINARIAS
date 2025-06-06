using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_MODULOS_TMP : Form
    {
        public ERP_SOP_MODULOS_TMP()
        {
            InitializeComponent();
        }
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        NEG_SOP_PERMISOS neg = new NEG_SOP_PERMISOS();
        NEG_SOP_MODULOS negMod = new NEG_SOP_MODULOS();
        private void ERP_SOP_MODULOS_Load(object sender, EventArgs e)
        {
            cargarForm();
        }
        private void cargarForm()
        {
            try
            {
                /*fun.ERP_Habilitar_Botones(this, BTN_NUEVO, BTN_GRABAR, BTN_ELIMINAR, BTN_EDITAR, BTN_CANCELAR, BTN_LISTADO, BTN_AUDITORIA, true, Clases.ERP_GLOBALES.CoUsu, Clases.ERP_GLOBALES.CoSuc, Clases.ERP_GLOBALES.CoEmp, Clases.ERP_GLOBALES.formpermisos);
                fun.Limpiar_Controles(this);
                fun.Habilitar_Controles(this, false);
                gbxListado.Enabled = true;
                listar(1, "");
                /*DataTable dtEmp = fun.Retorna_Tabla("SELECT 1 AS'A', '00' AS 'coEmp','--SELECCIONAR--' AS 'noEmp' UNION " +
                " SELECT 2 AS'A', coEmp, noEmp FROM U_EMPRESA WHERE st_registro = 1 AND estado = 'A' ORDER BY 1, 3");
                fun.Llenar_Combo(dtEmp, cbonoEmp, "coEmp", "noEmp");*/
                /*tabControl1.SelectTab(1);*/

                superTabControl1.SelectedTabIndex = 1;
                listar(1, txtFiltro.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listar(int opcion, string criterio)
        {
            try
            {
                neg.Opcion = opcion;
                neg.Criterio = criterio;
                neg.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dt = DAT_SOP_MODULOS.SP_ERP_SOP_MODULO(neg);
                dgvModulos.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvModulos.Rows.Add();
                    dgvModulos.Rows[i].Cells["coMod"].Value = dt.Rows[i]["coMod"].ToString();
                    dgvModulos.Rows[i].Cells["noMod"].Value = dt.Rows[i]["noMod"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevoModulo_Click(object sender, EventArgs e)
        {
            CLASES.ERP_GLOBALES.AccionCrud = "NUEVO";
            CLASES.ERP_GLOBALES.Accion = 0;
            ERP_SOP_MODULOS_MODAL_MODULO frm = new ERP_SOP_MODULOS_MODAL_MODULO();
            frm.ShowDialog();
            if (CLASES.ERP_GLOBALES.Accion == 1)
            {
                listar(1, txtFiltro.Text);
            }

        }

        private void dgvModulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvModulos.Columns[e.ColumnIndex].Name == "btnEditarMod")
                {
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Accion = 0;
                    CLASES.ERP_GLOBALES.Criterio = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                    ERP_SOP_MODULOS_MODAL_MODULO frm = new ERP_SOP_MODULOS_MODAL_MODULO();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.Accion == 1)
                    {
                        listar(1, txtFiltro.Text);
                    }
                }
                if (dgvModulos.Columns[e.ColumnIndex].Name == "btnEliminarMod")
                {
                    if(MessageBox.Show("Sguro de Eliminar el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { 
                        negMod.Opc = 3;
                        negMod.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                        negMod.NoMod = "";
                        negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        negMod.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                        negMod.Form = false;
                        negMod.NuOrd = 0;
                        DAT_SOP_MODULOS.SP_ERP_SOP_MODULO_GB(negMod);
                        listar(1, txtFiltro.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cargarDatos()
        {
            try
            {
                txtcoMod.Text = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                txtnoMod.Text = dgvModulos.CurrentRow.Cells["noMod"].Value.ToString();

                listarMenu(1,"");
                superTabControl1.SelectedTabIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listarMenu(int opcion, string criterio)
        {
            try
            {
                negMod.Opcion = opcion;
                negMod.Criterio = criterio;
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoMod= dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                DataTable dtMenu = DAT_SOP_MODULOS.SP_ERP_SOP_MENU(negMod);
                dgvMenus.Rows.Clear();
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    dgvMenus.Rows.Add();
                    dgvMenus.Rows[i].Cells["coMenu"].Value = dtMenu.Rows[i]["coMenu"].ToString();
                    dgvMenus.Rows[i].Cells["noMenu"].Value = dtMenu.Rows[i]["noMenu"].ToString();
                }
                dgvSubMenu.Rows.Clear();
                dgvSubSubMenu.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvModulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatos();
        }
        private void dgvMenus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMenus.Columns[e.ColumnIndex].Name == "btnEditarMenu")
            {
                CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                CLASES.ERP_GLOBALES.Accion = 0;
                CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                CLASES.ERP_GLOBALES.Criterio = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                ERP_SOP_MODULOS_MODAL_MENU frm = new ERP_SOP_MODULOS_MODAL_MENU();
                frm.ShowDialog();
                if (CLASES.ERP_GLOBALES.Accion == 1)
                {
                    listarMenu(1, "");
                }
            }
            if (dgvMenus.Columns[e.ColumnIndex].Name == "btnEliminarMenu")
            {
                if(MessageBox.Show("Está seguro de ELIMINAR el registro seleccionado ?","Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    negMod.Opc = 3;
                    negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    negMod.NoMenu = "";
                    negMod.CoMod = "";
                    negMod.Form = false;
                    negMod.NuOrd = 0;
                    negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    negMod.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                    DAT_SOP_MODULOS.SP_ERP_SOP_MENU_GB(negMod);
                    listarMenu(1, "");
                }
            }
            else
            {
                cargarDatosSubMenu();
            }

        }
        private void cargarDatosSubMenu()
        {
            try
            {

                negMod.Opcion = 1;
                negMod.Criterio = "";
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                DataTable dtSubMenu = DAT_SOP_MODULOS.SP_ERP_SOP_SUBMENU(negMod);
                dgvSubMenu.Rows.Clear();
                for (int i = 0; i < dtSubMenu.Rows.Count; i++)
                {
                    dgvSubMenu.Rows.Add();
                    dgvSubMenu.Rows[i].Cells["coSubMenu"].Value = dtSubMenu.Rows[i]["coSubMenu"].ToString();
                    dgvSubMenu.Rows[i].Cells["noSubMenu"].Value = dtSubMenu.Rows[i]["noSubMenu"].ToString();
                }
                dgvSubSubMenu.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSubMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvMenus.Columns[e.ColumnIndex].Name == "btnEditarMenu")
                {
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Accion = 0;
                    CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                    CLASES.ERP_GLOBALES.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    CLASES.ERP_GLOBALES.Criterio = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
                    ERP_SOP_MODULOS_MODAL_SUBMENU frm = new ERP_SOP_MODULOS_MODAL_SUBMENU();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.Accion == 1)
                    {
                        cargarDatosSubMenu();
                    }
                }
                if (dgvMenus.Columns[e.ColumnIndex].Name == "btnEliminarMenu")
                {
                    if(MessageBox.Show("Desea ELIMINAR el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        negMod.Opc = 3;
                        negMod.CoSubMenu = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
                        negMod.NoSubMenu = "";
                        negMod.CoMod = "";
                        negMod.CoMenu = "";
                        negMod.NuOrd = 0;
                        negMod.Form = false;
                        negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        negMod.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                        DAT_SOP_MODULOS.SP_ERP_SOP_SUBMENU_GB(negMod);
                        cargarDatosSubMenu();
                    }
                }
                else
                {
                    listarSubSubMenu();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listarSubSubMenu()
        {
                    negMod.Opcion = 1;
                    negMod.Criterio = "";
                    negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    negMod.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                    negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    negMod.CoSubMenu=dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
                    DataTable dtSubSubMenu = DAT_SOP_MODULOS.SP_ERP_SOP_SUBSUBMENU(negMod);
                    dgvSubSubMenu.Rows.Clear();
                    for (int i = 0; i < dtSubSubMenu.Rows.Count; i++)
                    {
                        dgvSubSubMenu.Rows.Add();
                        dgvSubSubMenu.Rows[i].Cells["coSubSubMenu"].Value = dtSubSubMenu.Rows[i]["coSubSubMenu"].ToString();
                        dgvSubSubMenu.Rows[i].Cells["noSubSubMenu"].Value = dtSubSubMenu.Rows[i]["noSubSubMenu"].ToString();
                    }
        }

        private void btnNuevoMenu_Click(object sender, EventArgs e)
        {
            CLASES.ERP_GLOBALES.AccionCrud = "NUEVO";
            CLASES.ERP_GLOBALES.Accion = 0;
            CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
            ERP_SOP_MODULOS_MODAL_MENU frm = new ERP_SOP_MODULOS_MODAL_MENU();
            frm.ShowDialog();
            if (CLASES.ERP_GLOBALES.Accion == 1)
            {
                listarMenu(1, "");
            }
        }

        private void btnNuevoSubMenu_Click(object sender, EventArgs e)
        {
            CLASES.ERP_GLOBALES.AccionCrud = "NUEVO";
            CLASES.ERP_GLOBALES.Accion = 0;
            CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
            CLASES.ERP_GLOBALES.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
            ERP_SOP_MODULOS_MODAL_SUBMENU frm = new ERP_SOP_MODULOS_MODAL_SUBMENU();
            frm.ShowDialog();
            if (CLASES.ERP_GLOBALES.Accion == 1)
            {
                //listarMenu(1, "");
                cargarDatosSubMenu();
            }
        }

        private void btnNuevoSubSubMenu_Click(object sender, EventArgs e)
        {
            CLASES.ERP_GLOBALES.AccionCrud = "NUEVO";
            CLASES.ERP_GLOBALES.Accion = 0;
            CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
            CLASES.ERP_GLOBALES.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
            CLASES.ERP_GLOBALES.CoSubMenu = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
            ERP_SOP_MODULOS_MODAL_SUB_SUBMENU frm = new ERP_SOP_MODULOS_MODAL_SUB_SUBMENU();
            frm.ShowDialog();
            if (CLASES.ERP_GLOBALES.Accion == 1)
            {
                //listarMenu(1, "");
                listarSubSubMenu();
            }
        }

        private void dgvSubSubMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvSubSubMenu.Columns[e.ColumnIndex].Name == "btnEditarSubSubMenu")
                {
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Accion = 0;
                    CLASES.ERP_GLOBALES.CoMod = dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                    CLASES.ERP_GLOBALES.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    CLASES.ERP_GLOBALES.CoSubMenu=dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
                    CLASES.ERP_GLOBALES.Criterio = dgvSubSubMenu.CurrentRow.Cells["coSubSubMenu"].Value.ToString();
                    ERP_SOP_MODULOS_MODAL_SUB_SUBMENU frm = new ERP_SOP_MODULOS_MODAL_SUB_SUBMENU();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.Accion == 1)
                    {
                        listarSubSubMenu();
                    }
                }
                if (dgvSubSubMenu.Columns[e.ColumnIndex].Name == "btnEliminarSubSubMenu")
                {
                    if (MessageBox.Show("Desea ELIMINAR el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        negMod.Opc = 3;
                        negMod.CoSubSubMenu = dgvSubSubMenu.CurrentRow.Cells["coSubSubMenu"].Value.ToString();
                        negMod.NoSubSubMenu = "";
                        neg.CoMod = "";
                        //neg.CoMenu = cbocoMenu.SelectedValue.ToString();
                        negMod.CoSubMenu = "";
                        negMod.NuOrd = 0;
                        negMod.Form = false;
                        negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        negMod.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                        DAT_SOP_MODULOS.SP_ERP_SOP_SUBSUBMENU_GB(negMod);
                        listarSubSubMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
