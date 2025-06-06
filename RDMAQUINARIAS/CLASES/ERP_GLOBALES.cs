using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDMAQUINARIAS.CLASES
{
    public static class ERP_GLOBALES
    {
        public static int Id { get; set; }
        public static string Criterio { get; set; }
        public static string Opcion { get; set; }
        public static int Opc { get; set; }
        public static string CoMod { get; set; }
        public static string NoMod { get; set; }
        public static string CoMenu { get; set; }
        public static string CoSubMenu { get; set; }
        public static string CoSubSubMenu { get; set; }
        public static DateTime FechaPeriodo { get; set; }
        public static string CoUsu { get; set; }
        public static string NoUsu { get; set; }
        public static string CoEmp { get; set; }
        public static string NoEmp { get; set; }
        public static string CoSuc { get; set; }
        public static string NoSuc { get; set; }
        public static string CoAre { get; set; }
        public static string NoAre { get; set; }
        public static string CoCar { get; set; }
        public static string NoCar { get; set; }
        public static int Accion { get; set; }

        public static int nivelPermiso { get; set; }
        public static string formpermisos { get; set; }
        public static string AccionCrud { get; set; }
        public static string Formulario { get; set; }
        public static string CodigoUsuario { get; set; }
        public static string CodigoEmpresa { get; set; }
        public static string CodigoSucursal { get; set; }
        public static string Co_usua_crea { get; set; }
        public static string Fe_usua_crea { get; set; }
        public static string Co_usua_modi { get; set; }
        public static string Fe_usua_modi { get; set; }
        public static string VariableBusqueda001 { get; set; }
        public static string VariableBusqueda002 { get; set; }
        public static string VariableBusqueda003 { get; set; }
        public static string VariableBusqueda004 { get; set; }
        public static string VariableBusqueda005 { get; set; }
        public static string DirPartida { get; set; }
        public static string UbigeoPartida { get; set; }
        public static string DirLlegada { get; set; }
        public static string UbigeoLlegada { get; set; }
        public static string CoProvCliDes { get; set; }
        public static string DeprovCliDes { get; set; }
        public static bool StPublico { get; set; }
        public static bool StPrivado { get; set; }
        public static string CoProvCliTra { get; set; }
        public static string DeprovCliTra { get; set; }
        public static string DirTra { get; set; }
        public static string NomChofer { get; set; }
        public static string CoTipDocu { get; set; }
        public static string NumDocu { get; set; }
        public static string MarcaVehiculo { get; set; }
        public static string PlacaVehiculo { get; set; }
        public static string DeBrevete { get; set; }
        public static string NroCirculacion { get; set; }
        public static bool StCompra { get; set; }
        public static bool StVenta { get; set; }
        public static bool StTransformacion { get; set; }
        public static bool StConsignacion { get; set; }
        public static bool StDevolucion { get; set; }
        public static bool StTraslado { get; set; }
        public static bool StTrasladoEmisor { get; set; }
        public static bool StImportacion { get; set; }
        public static bool StExportacion { get; set; }
        public static bool StTerceros { get; set; }
        public static bool StOtros { get; set; }
        public static string DeOtros { get; set; }
        public static string CoArt { get; set; }
        public static string CoArtRef { get; set; }
        public static string DeArt { get; set; }
        public static string CoMar { get; set; }
        public static string DeMar { get; set; }

        public static string CoUniMed { get; set; }
        public static string DeUniMed { get; set; }

        /*CALCULO*/
        public static decimal Imp_u { get; set; }
        public static decimal Cant { get; set; }
        public static decimal Imp_b { get; set; }
        public static decimal Dcto { get; set; }
        public static decimal Imp_d { get; set; }
        public static decimal PorDcto { get; set; }
        public static decimal Imp_n { get; set; }
        public static decimal Imp_i { get; set; }
        public static string CoImp { get; set; }
        public static decimal PorImp { get; set; }
        public static decimal Imp_t { get; set; }
        public static string DeObsDet { get; set; }
        public static string DirSuc { get; set; }
        public static string TelSuc { get; set; }
        public static bool Estado { get; set; }
        public static int ErpAccion { get; set; }
        public static string CoSucursal { get; set; }

        public static string TituloPed { get; set; }

        /*PRODUCTOS*/
        public static string CoProd { get; set; }
        public static string DeProd { get; set; }


        public static string[,] ArrayNuOrd = new string[0, 0];

    }
}
