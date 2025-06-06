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
    public partial class ERP_SOP_AUDITORIA : Form
    {
        public ERP_SOP_AUDITORIA()
        {
            InitializeComponent();
        }

        private void ERP_SOP_AUDITORIA_Load(object sender, EventArgs e)
        {
            cargarForm();
        }
        private void cargarForm()
        {
            try
            {
                txtco_usua_crea.Text = CLASES.ERP_GLOBALES.Co_usua_crea;
                txtfe_usua_crea.Text = CLASES.ERP_GLOBALES.Fe_usua_crea;
                txtco_usua_modi.Text = CLASES.ERP_GLOBALES.Co_usua_modi;
                txtfe_usua_modi.Text = CLASES.ERP_GLOBALES.Fe_usua_modi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
