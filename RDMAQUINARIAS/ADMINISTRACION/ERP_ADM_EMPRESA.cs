using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CAPA_DATOS.ADMINISTRACION;
using CAPA_NEGOCIOS.ADMINISTRACION;

namespace RDMAQUINARIAS.ADMINISTRACION
{
    public partial class ERP_ADM_EMPRESA : Form
    {
        public ERP_ADM_EMPRESA()
        {
            InitializeComponent();
        }
        NEG_ADM_EMPRESA neg=new NEG_ADM_EMPRESA();
        NEG_ADM_SUCURSAL negSuc = new NEG_ADM_SUCURSAL();
        CLASES.ERP_FUNCIONES fun=new CLASES.ERP_FUNCIONES();
        public byte[] IMG;
        int opc;
        private void ERP_ADM_EMPRESA_Load(object sender, EventArgs e)
        {
            
        }
        private void cargarForm()
        {
            try
            {
                CLASES.ERP_GLOBALES.formpermisos = "Gestionar Empresas";
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, true, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.formpermisos);
                fun.Limpiar_Controles(this);
                fun.Habilitar_Controles(this, false);
                gbxListado.Enabled = true;
                tabControl1.SelectTab(1);
                listar(1,txtFiltro.Text);
                pbximgEmp.Image = null;
                dgvSucursal.Rows.Clear();
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
                neg.Criterio=criterio;
                dgvDatos.DataSource = DAT_ADM_EMPRESA.SP_ERP_ADM_EMPRESA_LS(neg);
                dgvDatos.Columns["coEmp"].HeaderText = "Codigo";
                dgvDatos.Columns["noEmp"].HeaderText = "Razón Social";
                dgvDatos.Columns["coEmp"].ReadOnly = true;
                dgvDatos.Columns["noEmp"].ReadOnly = true;
                dgvDatos.Columns["coEmp"].Width = 50;
                dgvDatos.Columns["noEmp"].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Columns[e.ColumnIndex].Name == "btnSel")
            {
                cargarDatos();
                tabControl1.SelectTab(0);
            }
        }
        private void cargarDatos() {
            try
            {
                neg.Opcion = 3;
                neg.Criterio = dgvDatos.CurrentRow.Cells["coEmp"].Value.ToString();
                DataTable dt= DAT_ADM_EMPRESA.SP_ERP_ADM_EMPRESA_LS(neg);
                if (dt.Rows.Count > 0)
                {
                    txtcoEmp.Text = dt.Rows[0]["coEmp"].ToString();
                    txtrucEmp.Text = dt.Rows[0]["rucEmp"].ToString();
                    txtnoEmp.Text = dt.Rows[0]["noEmp"].ToString();
                    txtcomEmp.Text = dt.Rows[0]["comEmp"].ToString();
                    txtdirEmp.Text = dt.Rows[0]["dirEmp"].ToString();
                    txttelEmp.Text = dt.Rows[0]["telEmp"].ToString();
                    txturlEmp.Text = dt.Rows[0]["urlEmp"].ToString();
                    #region MOSTRAR_LOGO
                    if (dt.Rows[0]["imgEmp"] != DBNull.Value || dt.Rows[0]["imgEmp"].ToString() != "")
                    {
                        byte[] barrImg = (byte[])dt.Rows[0]["imgEmp"];
                        IMG = barrImg;
                        pbximgEmp.Image = ByteArrayToImage(barrImg);
                    }
                    else
                    {
                        pbximgEmp.Image = null;
                    }
                    #endregion
                    if (dt.Rows[0]["estado"].ToString() == "A")
                    {
                        chkestado.Checked = true;
                    }
                    if (dt.Rows[0]["estado"].ToString() == "I")
                    {
                        chkestado.Checked = false;
                    }


                    #region LISTAR SUCURSALES
                    negSuc.Opcion = 1;
                    negSuc.Criterio = dgvDatos.CurrentRow.Cells["coEmp"].Value.ToString();
                    negSuc.CoEmp = txtcoEmp.Text;
                    DataTable dtSuc = DAT_ADM_SUCURSAL.SP_ERP_ADM_SUCURSAL_LS(negSuc);
                    dgvSucursal.Rows.Clear();
                    for (int i = 0; i < dtSuc.Rows.Count; i++)
                    {
                        dgvSucursal.Rows.Add();
                        dgvSucursal.Rows[i].Cells["id"].Value = Convert.ToInt32(dtSuc.Rows[i]["id"]);
                        dgvSucursal.Rows[i].Cells["coSuc"].Value = dtSuc.Rows[i]["coSuc"].ToString();
                        dgvSucursal.Rows[i].Cells["noSuc"].Value = dtSuc.Rows[i]["noSuc"].ToString();
                        dgvSucursal.Rows[i].Cells["dirSuc"].Value = dtSuc.Rows[i]["dirSuc"].ToString();
                        dgvSucursal.Rows[i].Cells["telSuc"].Value = dtSuc.Rows[i]["telSuc"].ToString();
                        if (dtSuc.Rows[i]["estado"].ToString() == "A")
                        {
                            dgvSucursal.Rows[i].Cells["estado"].Value = Convert.ToBoolean(1);
                        }
                        else
                        {
                            dgvSucursal.Rows[i].Cells["estado"].Value = Convert.ToBoolean(0);
                        }
                        
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                opc = 1;
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, false, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.formpermisos);
                fun.Limpiar_Controles(this);
                fun.Habilitar_Controles(this, true);
                gbxListado.Enabled = false;

                tabControl1.SelectTab(0);
                txtcoEmp.Enabled = false;
                gbxCab.Enabled = true;
                dgvSucursal.Rows.Clear();
                pbximgEmp.Image = null;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            #region VALIDAR
            if (txtrucEmp.Text.Trim() == "")
            {
                MessageBox.Show("* Ingresar el RUC del Cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtrucEmp.Select();
                return;
            }
            if (txtnoEmp.Text.Trim() == "")
            {
                MessageBox.Show("* Ingresar el RAZÓN SOCIAL del Cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnoEmp.Select();
                return;
            }
            if (txtcomEmp.Text.Trim() == "")
            {
                MessageBox.Show("* Ingresar el NOMBRE COMERCIAL del Cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcomEmp.Select();
                return;
            }
            if (txtdirEmp.Text.Trim() == "")
            {
                MessageBox.Show("* Ingresar el DIRECCIÓN del Cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdirEmp.Select();
                return;
            }
            if (dgvSucursal.Rows.Count== 0)
            {
                MessageBox.Show("* Asignar la SUCURSAL.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Select();
                return;
            }
            #endregion

            grabar();
        }
        private void grabar()
        {
            try
            {

                #region GRABAR/EDITAR EMPRESA
                neg.Opc = opc;
                neg.CoEmp=txtcoEmp.Text;
                neg.RucEmp=txtrucEmp.Text;  
                neg.NoEmp=txtnoEmp.Text;
                neg.ComEmp=txtcomEmp.Text;
                neg.DirEmp=txtdirEmp.Text;
                neg.TelEmp=txttelEmp.Text;
                neg.UrlEmp=txturlEmp.Text;

                if (pbximgEmp.Image != null)
                {
                    neg.ImgEmp = IMG;
                }
                else
                {
                    ImageConverter converter = new ImageConverter();
                    byte[] barrImg = (byte[])converter.ConvertTo(Properties.Resources.no_fotos, typeof(byte[]));
                    neg.ImgEmp = barrImg;
                }
                
                if (chkestado.Checked == true)
                {
                    neg.Estado = "A";
                }
                else
                {
                    neg.Estado = "I";
                }
                neg.Co_usua_crea = CLASES.ERP_GLOBALES.CoUsu;

                txtcoEmp.Text = DAT_ADM_EMPRESA.SP_ERP_ADM_EMPRESA_GB(neg);

                #endregion


                #region GRABAR/EDITAR SUCURSAL
                dgvSucursal.EndEdit();
                for (int i = 0; i < dgvSucursal.Rows.Count; i++)
                {
                    negSuc.Opc = opc;
                    negSuc.Id = Convert.ToInt32(dgvSucursal.Rows[i].Cells["id"].Value);
                    negSuc.CoSuc= dgvSucursal.Rows[i].Cells["coSuc"].Value.ToString();
                    negSuc.NoSuc= dgvSucursal.Rows[i].Cells["noSuc"].Value.ToString();
                    negSuc.CoEmp = txtcoEmp.Text; //dgvSucursal.Rows[i].Cells["coEmp"].Value.ToString();
                    negSuc.DirSuc= dgvSucursal.Rows[i].Cells["dirSuc"].Value.ToString();
                    negSuc.TelSuc= dgvSucursal.Rows[i].Cells["telSuc"].Value.ToString();
                    if (Convert.ToBoolean(dgvSucursal.Rows[i].Cells["estado"].Value) == true)
                    {
                        negSuc.Estado= "A";
                    }
                    else
                    {
                        negSuc.Estado = "I";
                    }

                    negSuc.Co_usua_crea = CLASES.ERP_GLOBALES.CoUsu;
                    DAT_ADM_SUCURSAL.SP_ERP_ADM_SUCURSAL_GB(negSuc);
                }

                #endregion


                cargarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExaminarLogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //openFileDialog1.Filter = "Archivo *.bmp,*.jpeg,*.gif|*.jpg";
                    string imagen = openFileDialog1.FileName;
                    pbximgEmp.Image = Image.FromFile(imagen);
                    FileInfo info = new FileInfo(openFileDialog1.FileName);
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    txtRuta.Text = openFileDialog1.FileName.ToString();
                    txtnombreArchivo.Text = info.Name.ToString();
                    IMG = new byte[Convert.ToInt32(info.Length)];
                    fs.Read(IMG, 0, Convert.ToInt32(info.Length));
                    fs.Flush();
                    fs.Close();
                }
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
                opc = 2;
                fun.ERP_Habilitar_Botones(this, btnNuevo, btnGrabar, btnEliminar, btnEditar, btnCancelar, btnImprimir, btnAuditoria, false, CLASES.ERP_GLOBALES.CoUsu, CLASES.ERP_GLOBALES.CoSuc, CLASES.ERP_GLOBALES.CoEmp, CLASES.ERP_GLOBALES.formpermisos);
                fun.Habilitar_Controles(this, true);
                cargarDatos();
                tabControl1.SelectTab(0);
                gbxListado.Enabled = false;
                txtcoEmp.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDatos();
                if(MessageBox.Show("Está seguro de ELIMINAR la empresa seleccionda ?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    neg.Opc = 3;
                    neg.CoEmp = txtcoEmp.Text;
                    DAT_ADM_EMPRESA.SP_ERP_ADM_EMPRESA_ELIM(neg);
                    cargarForm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                /*dgvSucursal.Rows.Add();
                dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["id"].Value = "0";  
                dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["coSuc"].Value = "*";  */
                CLASES.ERP_GLOBALES.AccionCrud = "NUEVO";
                CLASES.ERP_GLOBALES.ErpAccion = 0;
                ERP_ADM_SUCURSAL frm = new ERP_ADM_SUCURSAL();
                frm.ShowDialog();
                if (CLASES.ERP_GLOBALES.ErpAccion == 1) {
                    dgvSucursal.Rows.Add();
                    dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["id"].Value = "0";
                    dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["coSuc"].Value = "**";
                    dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["noSuc"].Value = CLASES.ERP_GLOBALES.NoSuc;
                    dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["dirSuc"].Value = CLASES.ERP_GLOBALES.DirSuc;
                    dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["telSuc"].Value = CLASES.ERP_GLOBALES.TelSuc;
                    dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["estado"].Value = CLASES.ERP_GLOBALES.Estado;
                }
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

        private void dgvSucursal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSucursal.Columns[e.ColumnIndex].Name == "btnEditarFila")
                {
                    CLASES.ERP_GLOBALES.AccionCrud = "EDITAR";
                    CLASES.ERP_GLOBALES.Id = Convert.ToInt32(dgvSucursal.Rows[dgvSucursal.Rows.Count - 1].Cells["id"].Value);
                    CLASES.ERP_GLOBALES.CoSucursal = dgvSucursal.CurrentRow.Cells["coSuc"].Value.ToString();
                    CLASES.ERP_GLOBALES.NoSuc = dgvSucursal.CurrentRow.Cells["noSuc"].Value.ToString();
                    CLASES.ERP_GLOBALES.DirSuc = dgvSucursal.CurrentRow.Cells["dirSuc"].Value.ToString();
                    CLASES.ERP_GLOBALES.TelSuc = dgvSucursal.CurrentRow.Cells["telSuc"].Value.ToString();
                    CLASES.ERP_GLOBALES.Estado = Convert.ToBoolean(dgvSucursal.CurrentRow.Cells["estado"].Value);
                    CLASES.ERP_GLOBALES.ErpAccion = 0;
                    ERP_ADM_SUCURSAL frm = new ERP_ADM_SUCURSAL();
                    frm.ShowDialog();
                    if (CLASES.ERP_GLOBALES.ErpAccion == 1)
                    {
                        
                        dgvSucursal.CurrentRow.Cells["noSuc"].Value = CLASES.ERP_GLOBALES.NoSuc;
                        dgvSucursal.CurrentRow.Cells["dirSuc"].Value = CLASES.ERP_GLOBALES.DirSuc;
                        dgvSucursal.CurrentRow.Cells["telSuc"].Value = CLASES.ERP_GLOBALES.TelSuc;
                        dgvSucursal.CurrentRow.Cells["estado"].Value = CLASES.ERP_GLOBALES.Estado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ERP_ADM_EMPRESA_Shown(object sender, EventArgs e)
        {
            cargarForm();
        }
    }
}
