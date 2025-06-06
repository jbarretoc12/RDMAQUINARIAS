using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIOS.SOPORTE
{
    public class NEG_SOP_PERMISOS
    {
        public int Opc { get; set; }
        public int Opcion { get; set; }
        public string Criterio { get; set; }
        public string CoUsu { get; set; }
        public string CoEmp { get; set; }
        public string CoSuc { get; set; }
        public string CoMod { get; set; }
        public string CoMenu { get; set; }
        public string CoSubMenu { get; set; }
        public string CoSubSubMenu { get; set; }
        public bool Estado { get; set; }


        public int Nivel { get; set; }
        public string CoForm { get; set; }
        public bool StGrabar { get; set; }
        public bool StEditar { get; set; }
        public bool StEliminar { get; set; }
        public bool StReporte { get; set; }


    }
}
