using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS.ADMINISTRACION;
using CAPA_DATOS.INVENTARIO;
using CAPA_NEGOCIOS.INVENTARIO;

namespace RDMAQUINARIAS.INVENTARIO
{
    public partial class ERP_ALM_MENUPRINCIPAL_PENDIENTES: Form
    {
        public ERP_ALM_MENUPRINCIPAL_PENDIENTES()
        {
            InitializeComponent();
        }
        NEG_ALM_ALMACENES negAlm = new NEG_ALM_ALMACENES();
        private void ERP_ALM_MENUPRINCIPAL_PENDIENTES_Load(object sender, EventArgs e)
        {
            listarCajas(1, "");
        }
        private void listar(int opcion, string criterio)
        {
            try
            {
                Panel pnl;
                Panel pnl_header;
                Panel pnl_body;
                //Panel pnl_footer;
                Label lblTitulo;
                LinkLabel linkPendientes;
                //Button btnVer;
                panelPendientes.Padding = new Padding(5);
                for (int i = 0; i < 10; i++)
                {
                    pnl = new Panel();

                    #region HEADER CAJA
                    pnl_header = new Panel();
                    pnl_header.Dock = DockStyle.Top;
                    pnl_header.BackColor = Color.White;
                    
                    lblTitulo = new Label();
                    lblTitulo.Text = "Recepciones Pendientes";
                    lblTitulo.AutoSize = false;
                    lblTitulo.Dock = DockStyle.Top;
                    lblTitulo.Padding = new Padding(5);
                    pnl.Controls.Add(pnl_header);
                    pnl_header.Controls.Add(lblTitulo);
                    #endregion

                    #region BODY CAJA
                    pnl_body = new Panel();
                    pnl_body.Dock = DockStyle.Top;
                    pnl_body.Height = 30;
                    pnl_body.BackColor = Color.White;

                    linkPendientes = new LinkLabel();
                    linkPendientes.Text = "Pendiente (0)";
                    linkPendientes.LinkColor = Color.DodgerBlue;
                    linkPendientes.VisitedLinkColor = Color.MediumPurple;
                    linkPendientes.ActiveLinkColor = Color.OrangeRed;
                    linkPendientes.Dock = DockStyle.Top;
                    linkPendientes.Padding = new Padding(5);
                    linkPendientes.Height = 30;
                    linkPendientes.ForeColor = Color.Gray;
                    linkPendientes.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    pnl.Controls.Add(pnl_body);
                    pnl_body.Controls.Add(linkPendientes);
                    #endregion


                    panelPendientes.Controls.Add(pnl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listarCajas(int opcion, string criterio)
        {
            try
            {
                negAlm.Opcion = 1;
                negAlm.Criterio = "";
                negAlm.CoSuc = CLASES.ERP_GLOBALES.CoSuc;
                negAlm.CoEmp = CLASES.ERP_GLOBALES.CoEmp;
                DataTable dtAlm = DAT_ALM_ALMACENES.SP_ERP_ALM_ALMACENES_LS(negAlm);
                if (dtAlm.Rows.Count > 0)
                {
                    FlowLayoutPanel pnlAlmacenes;
                    Panel pnlTitulo;
                    Label lblTituloTexto;
                   
                    for (int i = 0; i < dtAlm.Rows.Count; i++)
                    {
                        pnlAlmacenes = new FlowLayoutPanel();
                        //pnlAlmacenes.Dock = DockStyle.Left;
                        pnlAlmacenes.Width = 250;
                        //pnlAlmacenes.BorderStyle = BorderStyle.FixedSingle;
                        pnlAlmacenes.Height = 500;
                        pnlAlmacenes.BackColor = Color.WhiteSmoke;

                        #region TITULO

                        pnlTitulo = new Panel();
                        //pnlTitulo.Padding = new Padding(5);
                        pnlTitulo.Height = 25;
                        pnlTitulo.BackColor = Color.White;

                        lblTituloTexto = new Label();
                        lblTituloTexto.Text = dtAlm.Rows[i]["coAlm"].ToString() +" - "+ dtAlm.Rows[i]["deAlm"].ToString();
                        lblTituloTexto.Width = 250;
                        lblTituloTexto.Height = 25;
                        lblTituloTexto.TextAlign = ContentAlignment.MiddleLeft;
                        lblTituloTexto.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        pnlTitulo.Controls.Add(lblTituloTexto);
                        #endregion

                        FlowLayoutPanel pnlDetalle;
                        Label tituloDetalle;
                        Label nombreEmpresa;
                        Button botonDetalle;
                        #region PANEL DEALLE
                        for (int t = 0; t < 3; t++)
                        {
                            string txt="";
                            switch (t)
                            {
                                case 0:
                                    txt = "Recepción"; 
                                    break;
                                case 1:
                                    txt = "Transferencias Internas";
                                    break;
                                case 2:
                                    txt = "Despacho";
                                    break;
                            }
                            pnlDetalle = new FlowLayoutPanel();
                            pnlDetalle.FlowDirection = FlowDirection.TopDown;
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
                            botonDetalle.FlatAppearance.BorderColor= Color.FromArgb(41, 127, 184);
                            pnlDetalle.Controls.Add(botonDetalle);

                            pnlAlmacenes.Controls.Add(pnlDetalle);
                        }
                        #endregion



                        pnlAlmacenes.Controls.Add(pnlTitulo);
                        pnlAlmacenes.Controls.SetChildIndex(pnlTitulo, 0);

                        panelPendientes.Padding = new Padding(5);
                        panelPendientes.Controls.Add(pnlAlmacenes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
