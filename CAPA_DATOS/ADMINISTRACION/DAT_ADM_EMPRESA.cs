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
    public static class DAT_ADM_EMPRESA
    {
        public static DataTable SP_ERP_ADM_EMPRESA_LS(NEG_ADM_EMPRESA neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ADM_EMPRESA_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string SP_ERP_ADM_EMPRESA_GB(NEG_ADM_EMPRESA neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ADM_EMPRESA_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@rucEmp", SqlDbType.VarChar).Value = neg.RucEmp;
            cmd.Parameters.Add("@noEmp", SqlDbType.VarChar).Value = neg.NoEmp;
            cmd.Parameters.Add("@comEmp", SqlDbType.VarChar).Value = neg.ComEmp;
            cmd.Parameters.Add("@dirEmp", SqlDbType.VarChar).Value = neg.DirEmp;
            cmd.Parameters.Add("@telEmp", SqlDbType.VarChar).Value = neg.TelEmp;
            cmd.Parameters.Add("@urlEmp", SqlDbType.VarChar).Value = neg.UrlEmp;
            cmd.Parameters.Add("@imgEmp", SqlDbType.Image).Value = neg.ImgEmp;
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = neg.Estado;
            cmd.Parameters.Add("@co_usua_crea", SqlDbType.VarChar).Value = neg.Co_usua_crea;
            cmd.Parameters.Add("@varCoSuc", SqlDbType.Char,2).Direction = ParameterDirection.Output;

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            string coEmpresa = cmd.Parameters["@varCoSuc"].Value.ToString();
            cn.Close();
            return coEmpresa;
        }
        public static int SP_ERP_ADM_EMPRESA_ELIM(NEG_ADM_EMPRESA neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ADM_EMPRESA_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }



    }
}
