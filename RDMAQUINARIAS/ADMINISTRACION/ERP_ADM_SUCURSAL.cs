using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDMAQUINARIAS.ADMINISTRACION
{
    public partial class ERP_ADM_SUCURSAL: Form
    {
        public ERP_ADM_SUCURSAL()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnoSuc.Text.Trim() == "")
                {
                    MessageBox.Show("INGRESAR NOMBRE.", "Sistema");
                    txtnoSuc.Select();
                    return;
                }
                if (txtdirSuc.Text.Trim() == "")
                {
                    MessageBox.Show("INGRESAR DIRECCIÓN.", "Sistema");
                    txtdirSuc.Select();
                    return;
                }
                if (txttelSuc.Text.Trim() == "")
                {
                    MessageBox.Show("INGRESAR TELÉFONO.", "Sistema");
                    txttelSuc.Select();
                    return;
                }


                CLASES.ERP_GLOBALES.CoSucursal = txtcoSuc.Text;
                CLASES.ERP_GLOBALES.NoSuc = txtnoSuc.Text;
                CLASES.ERP_GLOBALES.DirSuc = txtdirSuc.Text;
                CLASES.ERP_GLOBALES.TelSuc = txttelSuc.Text;
                CLASES.ERP_GLOBALES.Estado = chkestado.Checked;
                CLASES.ERP_GLOBALES.ErpAccion = 1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ERP_ADM_SUCURSAL_Load(object sender, EventArgs e)
        {

        }

        private void ERP_ADM_SUCURSAL_Shown(object sender, EventArgs e)
        {
            if (CLASES.ERP_GLOBALES.AccionCrud == "EDITAR") {
                txtcoSuc.Text = CLASES.ERP_GLOBALES.CoSucursal;
                txtnoSuc.Text = CLASES.ERP_GLOBALES.NoSuc;
                txtdirSuc.Text = CLASES.ERP_GLOBALES.DirSuc;
                txttelSuc.Text = CLASES.ERP_GLOBALES.TelSuc;
                chkestado.Checked = CLASES.ERP_GLOBALES.Estado;
            }
            txtnoSuc.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CLASES.ERP_GLOBALES.ErpAccion = 0;
            this.Close();
        }

        private void chkestado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkestado.Checked == true)
            {
                chkestado.Text = "Activo";
            }
            else
            {
                chkestado.Text = "Inactivo";
            }
        }
    }
}
