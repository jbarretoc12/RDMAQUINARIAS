using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CAPA_NEGOCIOS.ADMINISTRACION;

namespace CAPA_DATOS.ADMINISTRACION
{
    public static class DAT_ADM_SUCURSAL
    {
        public static DataTable SP_ERP_ADM_SUCURSAL_LS(NEG_ADM_SUCURSAL neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ADM_SUCURSAL_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int SP_ERP_ADM_SUCURSAL_GB(NEG_ADM_SUCURSAL neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ADM_SUCURSAL_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = neg.Id;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@noSuc", SqlDbType.VarChar).Value = neg.NoSuc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@dirSuc", SqlDbType.VarChar).Value = neg.DirSuc;
            cmd.Parameters.Add("@telSuc", SqlDbType.VarChar).Value = neg.TelSuc;
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = neg.Estado;
            cmd.Parameters.Add("@co_usua_crea", SqlDbType.VarChar).Value = neg.Co_usua_crea;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public static int SP_ERP_ADM_SUCURSAL_ELIM(NEG_ADM_SUCURSAL neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ADM_SUCURSAL_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coSuc", SqlDbType.Int).Value = neg.CoSuc;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
    }
}
