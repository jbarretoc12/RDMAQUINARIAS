using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIOS.ADMINISTRACION
{
    public class NEG_ADM_EMPRESA
    {
        public int Opc { get; set; }
        public int Opcion { get; set; }
        public string Criterio { get; set; }

        public string CoEmp { get; set; }
        public string RucEmp { get; set; }
        public string NoEmp { get; set; }
        public string ComEmp { get; set; }
        public string DirEmp { get; set; }
        public string TelEmp{ get; set; }
        public string UrlEmp{ get; set; }
        public byte[] ImgEmp{ get; set; }
        public string Estado{ get; set; }
        public string Co_usua_crea { get; set; }

    }
}
