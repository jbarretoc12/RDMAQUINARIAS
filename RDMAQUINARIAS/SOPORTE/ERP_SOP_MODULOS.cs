using CAPA_DATOS.SOPORTE;
using CAPA_NEGOCIOS.SOPORTE;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace RDMAQUINARIAS.SOPORTE
{
    public partial class ERP_SOP_MODULOS : Form
    {
        public ERP_SOP_MODULOS()
        {
            InitializeComponent();
        }
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        NEG_SOP_PERMISOS neg = new NEG_SOP_PERMISOS();
        NEG_SOP_MODULOS negMod = new NEG_SOP_MODULOS();
        int opc;
        private void ERP_SOP_MODULOS2_Load(object sender, EventArgs e)
        {
            cargarForm();
        }
        private void cargarForm()
        {
            try
            {
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, true, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, "Gestionar Módulos");
                fun.Limpiar_Controles(this);
                fun.Habilitar_Controles(this, false);
                gbxListado.Enabled = true;
                tabControl1.SelectTab(1);
                limpiarGrid();
                listar(1, txtFiltro.Text);  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void limpiarGrid()
        {
             dgvMenus.Rows.Clear();
             dgvSubMenu.Rows.Clear();
             dgvSubSubMenu.Rows.Clear();
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
            limpiarGrid();
            txtcoMod.Clear();
            txtnoMod.Clear();
            ERP_SOP_MODULOS_MODAL_MODULO frm = new ERP_SOP_MODULOS_MODAL_MODULO();
            frm.ShowDialog();
            if (CLASES.ERP_GLOBALES.Accion == 1)
            {
                //listar(1, txtFiltro.Text);
                txtcoMod.Text = CLASES.ERP_GLOBALES.CoMod;
                txtnoMod.Text = CLASES.ERP_GLOBALES.NoMod;
            }
        }

        private void dgvModulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvModulos.Columns[e.ColumnIndex].Name == "btnSelect") {
                    cargarDatos();
                }
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
                    if (MessageBox.Show("Sguro de Eliminar el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
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

                listarMenu(1, "",txtcoMod.Text);
                tabControl1.SelectTab(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listarMenu(int opcion, string criterio,String coMod)
        {
            try
            {
                negMod.Opcion = opcion;
                negMod.Criterio = criterio;
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoMod = coMod;//dgvModulos.CurrentRow.Cells["coMod"].Value.ToString();
                DataTable dtMenu = DAT_SOP_MODULOS.SP_ERP_SOP_MENU(negMod);
                dgvMenus.Rows.Clear();
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    dgvMenus.Rows.Add();
                    dgvMenus.Rows[i].Cells["chkSelMenu"].Value = Convert.ToBoolean(0);
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



        private void dgvMenus_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void cargarDatosSubMenu()
        {
            try
            {

                negMod.Opcion = 1;
                negMod.Criterio = "";
                negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negMod.CoMod = txtcoMod.Text;
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

                if (dgvSubMenu.Columns[e.ColumnIndex].Name == "btnEditarSubMenu")
                {
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Accion = 0;
                    CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
                    CLASES.ERP_GLOBALES.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    CLASES.ERP_GLOBALES.Criterio = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
                    ERP_SOP_MODULOS_MODAL_SUBMENU frm = new ERP_SOP_MODULOS_MODAL_SUBMENU();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.Accion == 1)
                    {
                        cargarDatosSubMenu();
                    }
                }
                if (dgvSubMenu.Columns[e.ColumnIndex].Name == "btnEliminarSubMenu")
                {
                    if (MessageBox.Show("Desea ELIMINAR el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        negMod.Opc = 3;
                        negMod.CoSubMenu = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
                        negMod.CoMod = txtcoMod.Text;
                        negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                        negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        DAT_SOP_MODULOS.SP_ERP_SOP_SUBMENU_ELIM(negMod);
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
            negMod.CoMod = txtcoMod.Text;
            negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
            negMod.CoSubMenu = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
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
            if (txtcoMod.Text.Trim() != "") { 
                CLASES.ERP_GLOBALES.AccionCrud = "NUEVO";
                CLASES.ERP_GLOBALES.Accion = 0;
                CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
                ERP_SOP_MODULOS_MODAL_MENU frm = new ERP_SOP_MODULOS_MODAL_MENU();
                frm.ShowDialog();
                if (CLASES.ERP_GLOBALES.Accion == 1)
                {
                    listarMenu(1, "",txtcoMod.Text);
                }
            }
            else
            {
                MessageBox.Show("Seleccionar el Módulo.", "Sistema");
                return;
            }

        }

        private void btnNuevoSubMenu_Click(object sender, EventArgs e)
        {

            if (dgvMenus.Rows.Count == 0)
            {
                MessageBox.Show("Seleccionar el Menu.", "Sistema");
                return;
            }
            else if (txtcoMod.Text.Trim() == "")
            {
                MessageBox.Show("Seleccionar el Módulo.", "Sistema");
                return;
            }
            else
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
        }

        private void btnNuevoSubSubMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenus.Rows.Count == 0)
            {
                MessageBox.Show("Seleccionar el Menu.", "Sistema");
                return;
            }
            if (dgvSubMenu.Rows.Count == 0)
            {
                MessageBox.Show("Seleccionar el SubMenu.", "Sistema");
                return;
            }
            else if (txtcoMod.Text.Trim() == "")
            {
                MessageBox.Show("Seleccionar el Módulo.", "Sistema");
                return;
            }
            else
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
        }

        private void dgvSubSubMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvSubSubMenu.Columns[e.ColumnIndex].Name == "btnEditarSubSubMenu")
                {
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Accion = 0;
                    CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
                    CLASES.ERP_GLOBALES.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    CLASES.ERP_GLOBALES.CoSubMenu = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString();
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
                        negMod.CoMod = txtcoMod.Text.Trim();
                        negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString().Trim();
                        negMod.CoSubMenu = dgvSubMenu.CurrentRow.Cells["coSubMenu"].Value.ToString().Trim();
                        negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        DAT_SOP_MODULOS.SP_ERP_SOP_SUBSUBMENU_ELIM(negMod);
                        listarSubSubMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                opc = 1;
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, false, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, "Gestionar Módulos");
                fun.Limpiar_Controles(this);
                fun.Habilitar_Controles(this, true);
                limpiarGrid();
                gbxListado.Enabled = false;
                gbxCab.Enabled = true;
                tabControl1.SelectTab(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDatos();
                opc = 2;
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, false, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, "Gestionar Módulos");
                fun.Habilitar_Controles(this, true);
                gbxListado.Enabled = false;
                gbxCab.Enabled = false;
                cargarDatos();
                tabControl1.SelectTab(0);
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

        private void btnEditarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                CLASES.ERP_GLOBALES.Accion = 0;
                CLASES.ERP_GLOBALES.Criterio =txtcoMod.Text;
                ERP_SOP_MODULOS_MODAL_MODULO frm = new ERP_SOP_MODULOS_MODAL_MODULO();
                frm.ShowDialog();
                if (CLASES.ERP_GLOBALES.Accion == 1)
                {
                    txtcoMod.Text = CLASES.ERP_GLOBALES.CoMod;
                    txtnoMod.Text = CLASES.ERP_GLOBALES.NoMod;
                    //listar(1, txtFiltro.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Sguro de Eliminar el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    negMod.Opc = 3;
                    negMod.CoMod = txtcoMod.Text;
                    negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    DAT_SOP_MODULOS.SP_ERP_SOP_MODULO_ELIM(negMod);
                    cargarForm();
                    //listar(1, txtFiltro.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            cargarForm();
        }

        private void dgvMenus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMenus.Columns[e.ColumnIndex].Name == "chkSelMenu")
                {
                    checkearYlistarMenu();
                }
                if (dgvMenus.Columns[e.ColumnIndex].Name == "btnEditarMenu")
                {
                    
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Accion = 0;
                    CLASES.ERP_GLOBALES.CoMod = txtcoMod.Text;
                    CLASES.ERP_GLOBALES.Criterio = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                    ERP_SOP_MODULOS_MODAL_MENU frm = new ERP_SOP_MODULOS_MODAL_MENU();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.Accion == 1)
                    {
                        listarMenu(1, "", txtcoMod.Text);
                    }
                }
                if (dgvMenus.Columns[e.ColumnIndex].Name == "btnEliminarMenu")
                {
                    if (MessageBox.Show("Está seguro de ELIMINAR el registro seleccionado ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        negMod.Opc = 3;
                        negMod.CoMenu = dgvMenus.CurrentRow.Cells["coMenu"].Value.ToString();
                        negMod.CoMod = txtcoMod.Text.Trim();
                        negMod.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                        DAT_SOP_MODULOS.SP_ERP_SOP_MENU_ELIM(negMod);
                        listarMenu(1, "", txtcoMod.Text);
                    }
                }
                /*else
                {
                    cargarDatosSubMenu();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkearYlistarMenu()
        {
            for (int i = 0; i < dgvMenus.Rows.Count; i++)
            {
                dgvMenus.Rows[i].Cells["chkSelMenu"].Value = Convert.ToBoolean(0);
            }

            dgvMenus.EndEdit();
            if (Convert.ToBoolean(dgvMenus.CurrentRow.Cells["chkSelMenu"].Value) == true)
            {
                dgvMenus.CurrentRow.Selected = true;
                cargarDatosSubMenu();
            }
            else
            {
                dgvSubMenu.Rows.Clear();
                dgvSubSubMenu.Rows.Clear();
            }
        }

        private void dgvSubMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSubMenu.Columns[e.ColumnIndex].Name== "chkSelSubMenu")
                {
                    for (int i = 0; i < dgvSubMenu.Rows.Count; i++)
                    {
                        dgvSubMenu.Rows[i].Cells["chkSelSubMenu"].Value = Convert.ToBoolean(0);
                    }
                    dgvSubMenu.EndEdit();

                    if (Convert.ToBoolean(dgvSubMenu.CurrentRow.Cells["chkSelSubMenu"].Value) == true)
                    {
                        dgvSubMenu.CurrentRow.Selected = true;
                        listarSubSubMenu();
                    }
                    else
                    {
                        dgvSubSubMenu.Rows.Clear();
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
