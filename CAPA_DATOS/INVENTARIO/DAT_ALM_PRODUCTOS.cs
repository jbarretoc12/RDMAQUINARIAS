using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_NEGOCIOS.INVENTARIO;

namespace CAPA_DATOS.INVENTARIO
{
    public static class DAT_ALM_PRODUCTOS
    {
        public static DataTable SP_ERP_ALM_UNIMED_LS(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_UNIMED_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataTable SP_ERP_ALM_PRODUCTOS_LS(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_PRODUCTOS_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_ALM_PRODUCTOS_SERVICIOS_LS(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_PRODUCTOS_SERVICIOS_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_ALM_MARCA_LS(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_MARCA_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Char).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int SP_ERP_ALM_PRODUCTOS_GB(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_PRODUCTOS_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coProd", SqlDbType.VarChar).Value = neg.CoProd;
            cmd.Parameters.Add("@deProd", SqlDbType.VarChar).Value = neg.DeProd;
            cmd.Parameters.Add("@coUm", SqlDbType.Char).Value = neg.CoUm;
            cmd.Parameters.Add("@coMar", SqlDbType.VarChar).Value = neg.CoMar;
            //cmd.Parameters.Add("@stockActual", SqlDbType.Decimal).Value = neg.StockActual;
            cmd.Parameters.Add("@cos_u", SqlDbType.Decimal).Value = neg.Cos_u;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = neg.Estado;
            cmd.Parameters.Add("@co_usua_crea", SqlDbType.VarChar).Value = neg.Co_usua_crea;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public static int SP_ERP_ALM_PRODUCTOS_SERVICIOS_GB(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_PRODUCTOS_SERVICIOS_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coProd", SqlDbType.VarChar).Value = neg.CoProd;
            cmd.Parameters.Add("@deProd", SqlDbType.VarChar).Value = neg.DeProd;
            cmd.Parameters.Add("@coUm", SqlDbType.Char).Value = neg.CoUm;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = neg.Estado;
            cmd.Parameters.Add("@co_usua_crea", SqlDbType.VarChar).Value = neg.Co_usua_crea;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        public static int SP_ERP_ALM_PRODUCTOS_ELIM(NEG_ALM_PRODUCTOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_ALM_PRODUCTOS_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@coProd", SqlDbType.VarChar).Value = neg.CoProd;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }
       
    }
}
