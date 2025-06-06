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
    public static class DAT_ALM_INGRESO_DIRECTO
    {
        public static DataTable SP_ERP_ALM_MOVIMIENTO_CAB_LS(NEG_ALM_INGRESO_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_MOVIMIENTO_CAB_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@tiMov", SqlDbType.Char).Value = neg.TiMov;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataTable SP_ERP_ALM_MOVIMIENTO_DET_LS(NEG_ALM_INGRESO_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_MOVIMIENTO_DET_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataTable SP_ERP_ALM_NUMERADOR_GENERAR(NEG_ALM_INGRESO_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_NUMERADOR_GENERAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@seNum", SqlDbType.Char).Value = neg.SeNum;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_ALM_LISTAR_ANIOS_MOV(NEG_ALM_INGRESO_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_LISTAR_ANIOS_MOV", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO_LS(NEG_ALM_INGRESO_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO(NEG_ALM_INGRESO_DIRECTO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@anio", SqlDbType.Int).Value = neg.Anio;
            cmd.Parameters.Add("@mes", SqlDbType.Int).Value = neg.Mes;
            cmd.Parameters.Add("@co_usua_cierre", SqlDbType.VarChar).Value = neg.Co_usua_cierre;
            cmd.Parameters.Add("@deObs", SqlDbType.VarChar).Value = neg.DeObs;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
    }
}
