using CAPA_DATOS.COMPRAS;
using CAPA_NEGOCIOS.COMPRAS;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RDMAQUINARIAS.COMPRAS
{
    public partial class ERP_COM_ENVIAR_CORREO: Form
    {
        public ERP_COM_ENVIAR_CORREO()
        {
            InitializeComponent();
        }
        NEG_COM_SOLICITUD_PEDIDO negCom = new NEG_COM_SOLICITUD_PEDIDO();
        private void ERP_COM_ENVIAR_CORREO_Load(object sender, EventArgs e)
        {
            txtAsunto.Text = CLASES.ERP_GLOBALES.TituloPed + " - " + CLASES.ERP_GLOBALES.NumDocu;
            btnArchivoAdjunto.Text = CLASES.ERP_GLOBALES.NumDocu;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(txtDe.Text);
                mensaje.To.Add(txtPara.Text);
                mensaje.Subject = txtAsunto.Text;
                mensaje.Body = richCuerpo.Text;
                mensaje.IsBodyHtml = true;


                string rutaDirectorio = Application.StartupPath;
                string nombreArchivo = CLASES.ERP_GLOBALES.NumDocu + ".pdf";
                string rutaPDF = Path.Combine(rutaDirectorio, nombreArchivo);
                if (File.Exists(rutaPDF))
                {
                    Attachment adjunto = new Attachment(rutaPDF);
                    mensaje.Attachments.Add(adjunto);
                }
                else
                {
                    MessageBox.Show("Problemas con el archivo adjunto. Comunicar al area de Desarrollo.");
                    return;
                }


                // Configurar SMTP
                SmtpClient smtp = new SmtpClient("mail.riveradiesel.com.pe", 25); // usa el servidor SMTP que necesites
                smtp.Credentials = new NetworkCredential("jbarreto@riveradiesel.com.pe", "jf6ck7");
                smtp.EnableSsl = true;

                // Enviar
                try
                {
                    smtp.Send(mensaje);
                    #region CAMBIAR ESTADO
                    negCom.NuPed = CLASES.ERP_GLOBALES.NumDocu;
                    negCom.Estado = "E";
                    negCom.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                    DAT_COM_SOLICITUD_PEDIDO.SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO(negCom);
                    #endregion

                    MessageBox.Show("Correo enviado con éxito.");
                    CLASES.ERP_GLOBALES.ErpAccion = 1;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar correo: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
