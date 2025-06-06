using CAPA_DATOS.ADMINISTRACION;
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
    public partial class ERP_COM_MENUPRINCIPAL_PENDIENTES: Form
    {
        public ERP_COM_MENUPRINCIPAL_PENDIENTES()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ERP_COM_MENUPRINCIPAL_PENDIENTES_Load(object sender, EventArgs e)
        {
            listarCajas(1, "");
        }
        private void listarCajas(int opcion, string criterio)
        {
            try
            {

                FlowLayoutPanel pnlDetalle;
                Label tituloDetalle;
                Label nombreEmpresa;
                Button botonDetalle;
                #region PANEL DEALLE
                for (int t = 0; t < 3; t++)
                {
                    string txt = "";
                    switch (t)
                    {
                        case 0:
                            txt = "Recibidos";
                            break;
                        case 1:
                            txt = "Ordenes de Entrega";
                            break;
                        case 2:
                            txt = "Devoluciones";
                            break;
                    }
                    pnlDetalle = new FlowLayoutPanel();
                    //pnlDetalle.FlowDirection = FlowDirection.TopDown;
                    pnlDetalle.Width = 250;
                    pnlDetalle.Padding = new Padding(5);
                    pnlDetalle.BackColor = Color.White;

                    tituloDetalle = new Label();
                    tituloDetalle.Width = 250;
                    tituloDetalle.Text = txt;
                    tituloDetalle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    tituloDetalle.ForeColor = Color.FromArgb(41, 127, 184);
                    pnlDetalle.Controls.Add(tituloDetalle);

                    nombreEmpresa = new Label();
                    nombreEmpresa.Width = 250;
                    nombreEmpresa.Text = "Rivera Diesel S.A.";
                    nombreEmpresa.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    nombreEmpresa.ForeColor = Color.FromArgb(0, 0, 0);
                    pnlDetalle.Controls.Add(nombreEmpresa);

                    botonDetalle = new Button();
                    botonDetalle.Text = "0 A Procesar";
                    botonDetalle.Width = 230;
                    botonDetalle.TextAlign = ContentAlignment.MiddleLeft;
                    botonDetalle.Cursor = Cursors.Hand;
                    botonDetalle.BackColor = Color.FromArgb(41, 127, 184);
                    botonDetalle.ForeColor = Color.White;
                    //botonDetalle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    botonDetalle.FlatStyle = FlatStyle.Flat;
                    botonDetalle.FlatAppearance.BorderColor = Color.FromArgb(41, 127, 184);
                    pnlDetalle.Controls.Add(botonDetalle);

                    panelPendientes.Controls.Add(pnlDetalle);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }
    }
}
