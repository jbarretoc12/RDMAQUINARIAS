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
    public partial class ERP_SOP_PERMISOS_FORMULARIO : Form
    {
        public ERP_SOP_PERMISOS_FORMULARIO()
        {
            InitializeComponent();
        }
        NEG_SOP_PERMISOS negPer = new NEG_SOP_PERMISOS();
        private void ERP_SOP_PERMISOS_FORMULARIO_Load(object sender, EventArgs e)
        {

            cargarForm();
        }
        private void cargarForm()
        {
            try
            {
                switch (Convert.ToInt32(CLASES.ERP_GLOBALES.Opcion))
                {
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }
                negPer.Opcion = Convert.ToInt32(CLASES.ERP_GLOBALES.Opcion);
                negPer.Criterio = CLASES.ERP_GLOBALES.Criterio;
                negPer.CoUsu = CLASES.ERP_GLOBALES.CodigoUsuario;
                negPer.CoSuc = CLASES.ERP_GLOBALES.CodigoSucursal;
                negPer.CoEmp = CLASES.ERP_GLOBALES.CodigoEmpresa;
                DataTable dt = DAT_SOP_PERMISOS.SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO(negPer);
                if (dt.Rows.Count > 0)
                { 
                    txtCod.Text = CLASES.ERP_GLOBALES.Criterio.Trim();
                    txtNom.Text = dt.Rows[0]["nomForm"].ToString();
                    chkGrabar.Checked = Convert.ToBoolean(dt.Rows[0]["stGrabar"]);
                    chkEditar.Checked = Convert.ToBoolean(dt.Rows[0]["stEditar"]);
                    chkEliminar.Checked = Convert.ToBoolean(dt.Rows[0]["stEliminar"]);
                    chkReporte.Checked = Convert.ToBoolean(dt.Rows[0]["stReporte"]);
                }
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                int nivel = 0;
                int cantCaracteresCod = txtCod.Text.Length;
                switch (cantCaracteresCod)
                {
                    case 4:
                        nivel = 1; //MODULO
                        break;
                    case 5:
                        nivel = 2; //MENU
                        break;
                    case 6:
                        nivel = 3; //SUBMENU
                        break;
                    case 7:
                        nivel = 4; //SUB SUBMENU
                        break;
                }
                negPer.Nivel = nivel;
                negPer.CoForm = txtCod.Text.Trim();
                negPer.StGrabar = Convert.ToBoolean(chkGrabar.Checked);
                negPer.StEditar = Convert.ToBoolean(chkEditar.Checked); 
                negPer.StEliminar = Convert.ToBoolean(chkEliminar.Checked);
                negPer.StReporte = Convert.ToBoolean(chkReporte.Checked);
                negPer.CoUsu = CLASES.ERP_GLOBALES.CodigoUsuario;
                negPer.CoSuc = CLASES.ERP_GLOBALES.CodigoSucursal;
                negPer.CoEmp = CLASES.ERP_GLOBALES.CodigoEmpresa;
                DAT_SOP_PERMISOS.SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO_GB(negPer);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
