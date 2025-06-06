using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace RDMAQUINARIAS.COMPRAS
{
    public partial class TarjetaControl: UserControl
    {

        public int IdPed { get; set; }
        public string NuPed
        {
            get => txtnuPed.Text;
            set => txtnuPed.Text = value;
        }
        public string DeProvCli
        {
            get => txtdeProvCli.Text;
            set => txtdeProvCli.Text = value;
        }

        public string FePed
        {
            get => txtfePed.Text;
            set => txtfePed.Text = value;
        }
        public string FeRec
        {
            get => txtfeRec.Text;
            set => txtfeRec.Text = value;
        }


        public event Action<int> OnActualizar;
        public event Action<int> OnEliminar;
        public event Action<int> OnVer;
        public TarjetaControl()
        {
            InitializeComponent();
            linkActualizar.Click += (s, e) => OnActualizar?.Invoke(IdPed);
            linkEliminar.Click += (s, e) => OnEliminar?.Invoke(IdPed);
            linkVer.Click += (s, e) => OnVer?.Invoke(IdPed);
        }




        private void TarjetaControl_Load(object sender, EventArgs e)
        {
           
        }
    }
}
