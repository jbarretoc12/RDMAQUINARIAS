using CAPA_NEGOCIOS.INVENTARIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS.INVENTARIO
{
    public static class DAT_ALM_ALMACENES
    {
        public static DataTable SP_ERP_ALM_ALMACENES_LS(NEG_ALM_ALMACENES neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_ALMACENES_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
