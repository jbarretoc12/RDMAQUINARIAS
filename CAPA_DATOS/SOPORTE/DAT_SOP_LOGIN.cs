using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CAPA_NEGOCIOS.SOPORTE;



namespace CAPA_DATOS.SOPORTE
{
    public static class DAT_SOP_LOGIN
    {
        public static DataTable SP_ERP_SOP_LOGEO(NEG_SOP_LOGIN neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_LOGEO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@noClave", SqlDbType.VarChar).Value = neg.NoClave;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_SOP_LISTAR_PERMISOS(NEG_SOP_LOGIN neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_LISTAR_PERMISOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@coSubSubMenu", SqlDbType.Char).Value = neg.CoSubSubMenu;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable SP_ERP_SOP_LISTAR_PERMISOS_LISTAR_MODULOS(NEG_SOP_LOGIN neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_LISTAR_PERMISOS_LISTAR_MODULOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@coSubSubMenu", SqlDbType.Char).Value = neg.CoSubSubMenu;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



    }
}
