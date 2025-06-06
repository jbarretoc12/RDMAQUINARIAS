using CAPA_DATOS.INVENTARIO;
using CAPA_NEGOCIOS.INVENTARIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDMAQUINARIAS.INVENTARIO
{
    public partial class ERP_ALM_CIERRE_PERIODO: Form
    {
        public ERP_ALM_CIERRE_PERIODO()
        {
            InitializeComponent();
        }
        NEG_ALM_INGRESO_DIRECTO negIng = new NEG_ALM_INGRESO_DIRECTO();
        CLASES.ERP_FUNCIONES fun = new CLASES.ERP_FUNCIONES();
        private void ERP_ALM_CIERRE_PERIODO_Load(object sender, EventArgs e)
        {
            #region LLENAR COMBO
            negIng.Opcion = 1;
            negIng.Criterio = "";
            negIng.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
            DataTable dtAnio = DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_LISTAR_ANIOS_MOV(negIng);
            fun.llenar_Combo(dtAnio, cboAnio, "anio", "anio");
            cboAnio.SelectedValue = DateTime.Now.Year.ToString();
            #endregion

            listar(1, DateTime.Now.Year.ToString());
        }
        private void listar(int opcion, string criterio)
        {
            try
            {
                Button btn;
                negIng.Opcion = opcion;
                negIng.Criterio = criterio;
                negIng.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtAnio = DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO_LS(negIng);

                flowBotonMeses.Controls.Clear();
                for (int i = 0; i < dtAnio.Rows.Count; i++)
                {
                    btn = new Button();
                    btn.Name = dtAnio.Rows[i]["nuMes"].ToString();
                    btn.Text = dtAnio.Rows[i]["noMes"].ToString();
                    btn.Enabled = ! Convert.ToBoolean(dtAnio.Rows[i]["Cerrado"]);
                    btn.Width = 85;
                    btn.Height = 51;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.ForeColor = Color.Blue;
                    btn.Click += btnCerrarPeriodo_Click;
                    flowBotonMeses.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCerrarPeriodo_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if(MessageBox.Show("CONFIRMAR CIERRE.", "Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    negIng.Anio = Convert.ToInt16(cboAnio.SelectedValue);
                    negIng.Mes = Convert.ToInt16(btn.Name);
                    negIng.Co_usua_cierre = CLASES.ERP_GLOBALES.CoUsu;
                    negIng.DeObs = "";
                    negIng.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    DAT_ALM_INGRESO_DIRECTO.SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO(negIng);
                    listar(1, cboAnio.SelectedValue.ToString());
                }


            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listar(1, cboAnio.SelectedValue.ToString());
        }
    }

}
