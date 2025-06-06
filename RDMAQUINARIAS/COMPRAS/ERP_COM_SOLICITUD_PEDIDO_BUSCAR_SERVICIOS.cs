using CAPA_DATOS.INVENTARIO;
using CAPA_NEGOCIOS.INVENTARIO;
using CrystalDecisions.ReportAppServer.ClientDoc;
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
    public partial class ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS: Form
    {
        public ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS()
        {
            InitializeComponent();
        }
        NEG_ALM_PRODUCTOS negInv = new NEG_ALM_PRODUCTOS();
        private void ERP_COM_SOLICITUD_PEDIDO_BUSCAR_SERVICIOS_Load(object sender, EventArgs e)
        {
            listar(1, txtdeProd.Text);
        }
        private void listar(int opcion, string criterio)
        {
            try
            {
                negInv.Opcion = opcion;
                negInv.Criterio = criterio;
                negInv.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                negInv.CoSuc = "";
                DataTable dt = DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_SERVICIOS_LS(negInv);
                dgvServicios.DataSource = dt;

                for (int i = 0; i < dgvServicios.Columns.Count; i++)
                {
                    dgvServicios.Columns[i].Visible = false;
                }
                dgvServicios.Columns["btnSel"].Visible = true;
                dgvServicios.Columns["nro"].Visible = true;
                dgvServicios.Columns["coProd"].Visible = true;
                dgvServicios.Columns["deProd"].Visible = true;

                dgvServicios.Columns["nro"].Width = 40;
                dgvServicios.Columns["coProd"].Width = 100;
                dgvServicios.Columns["deProd"].Width = 300;

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
                if (MessageBox.Show("ESTA SEGURO DE REGISTRAR ESTE SERVICIO ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    negInv.Opc = 1;
                    negInv.CoProd = "";
                    negInv.DeProd = txtdeProd.Text;
                    negInv.CoUm = "UNI";
                    negInv.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    negInv.Estado = "A";
                    negInv.Co_usua_crea = CLASES.ERP_GLOBALES.CoUsu;
                    DAT_ALM_PRODUCTOS.SP_ERP_ALM_PRODUCTOS_SERVICIOS_GB(negInv);
                    listar(1, txtdeProd.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtdeProd_TextChanged(object sender, EventArgs e)
        {
            listar(1, txtdeProd.Text);
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvServicios.Columns[e.ColumnIndex].Name == "btnSel")
                {
                    CLASES.ERP_GLOBALES.CoProd = dgvServicios.CurrentRow.Cells["coProd"].Value.ToString();
                    CLASES.ERP_GLOBALES.DeProd = dgvServicios.CurrentRow.Cells["deProd"].Value.ToString();
                    CLASES.ERP_GLOBALES.ErpAccion = 1;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
