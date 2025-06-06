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
    public static class DAT_SOP_PERMISOS
    {
        public static DataTable SP_ERP_SOP_LISTAR_PERMISOS(NEG_SOP_PERMISOS neg)
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
        public static DataTable SP_ERP_SOP_GRABAR_PERMISOS(NEG_SOP_PERMISOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_GRABAR_PERMISOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@coSubSubMenu", SqlDbType.Char).Value = neg.CoSubSubMenu;
            cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = neg.Estado;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO(NEG_SOP_PERMISOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO_GB(NEG_SOP_PERMISOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nivel", SqlDbType.Int).Value = neg.Nivel;
            cmd.Parameters.Add("@coForm", SqlDbType.VarChar).Value = neg.CoForm;
            cmd.Parameters.Add("@stGrabar", SqlDbType.Bit).Value = neg.StGrabar;
            cmd.Parameters.Add("@stEditar", SqlDbType.Bit).Value = neg.StEditar;
            cmd.Parameters.Add("@stEliminar", SqlDbType.Bit).Value = neg.StEliminar;
            cmd.Parameters.Add("@stReporte", SqlDbType.Bit).Value = neg.StReporte;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
        public static DataTable SP_ERP_SOP_PERMISOS_BOTONES(NEG_SOP_PERMISOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_PERMISOS_BOTONES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@coUsu", SqlDbType.VarChar).Value = neg.CoUsu;
            cmd.Parameters.Add("@coMod", SqlDbType.VarChar).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@coSubSubMenu", SqlDbType.Char).Value = neg.CoSubSubMenu;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
