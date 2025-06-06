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
    public static class DAT_ALM_SALIDA_DIRECTO
    {
        public static DataTable SP_ERP_ALM_MOVIMIENTO_SALIDA_CAB_LS(NEG_ALM_SALIDA_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_MOVIMIENTO_SALIDA_CAB_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@tiMov", SqlDbType.VarChar).Value = neg.TiMov;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataTable SP_ERP_ALM_MOVIMIENTO_SALIDA_DET_LS(NEG_ALM_SALIDA_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_MOVIMIENTO_SALIDA_DET_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataTable SP_ERP_ALM_NUMERADOR_GENERAR_SALIDA(NEG_ALM_SALIDA_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_NUMERADOR_GENERAR_SALIDA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@seNum", SqlDbType.Char).Value = neg.SeNum;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
