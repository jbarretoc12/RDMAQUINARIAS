using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CAPA_NEGOCIOS.SOPORTE;
using System.Data;

namespace CAPA_DATOS.SOPORTE
{
    public static class DAT_SOP_MODULOS
    {
        public static DataTable SP_ERP_SOP_MODULO(NEG_SOP_PERMISOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_MODULO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int SP_ERP_SOP_MODULO_GB(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_MODULO_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@noMod", SqlDbType.VarChar).Value = neg.NoMod;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cmd.Parameters.Add("@form", SqlDbType.Bit).Value = neg.Form;
            cmd.Parameters.Add("@nuOrd", SqlDbType.Int).Value = neg.NuOrd;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }


        public static DataTable SP_ERP_SOP_MENU(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_MENU", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable SP_ERP_SOP_SUBMENU(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_SUBMENU", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_ERP_SOP_SUBSUBMENU(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_SUBSUBMENU", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static int SP_ERP_SOP_MENU_GB(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_MENU_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@noMenu", SqlDbType.VarChar).Value = neg.NoMenu;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@form", SqlDbType.Bit).Value = neg.Form;
            cmd.Parameters.Add("@nuOrd", SqlDbType.Int).Value = neg.NuOrd;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public static int SP_ERP_SOP_SUBMENU_GB(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_SUBMENU_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;            
            cmd.Parameters.Add("@noSubMenu", SqlDbType.VarChar).Value = neg.NoSubMenu;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@nuOrd", SqlDbType.Int).Value = neg.NuOrd;
            cmd.Parameters.Add("@form", SqlDbType.Bit).Value = neg.Form;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public static int SP_ERP_SOP_SUBSUBMENU_GB(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_SUBSUBMENU_GB", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coSubSubMenu", SqlDbType.Char).Value = neg.CoSubSubMenu;
            cmd.Parameters.Add("@noSubSubMenu", SqlDbType.VarChar).Value = neg.NoSubSubMenu;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@nuOrd", SqlDbType.Int).Value = neg.NuOrd;
            cmd.Parameters.Add("@form", SqlDbType.Bit).Value = neg.Form;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }


        public static int SP_ERP_SOP_SUBSUBMENU_ELIM(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_SUBSUBMENU_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coSubSubMenu", SqlDbType.Char).Value = neg.CoSubSubMenu;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public static int SP_ERP_SOP_SUBMENU_ELIM(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_SUBMENU_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coSubMenu", SqlDbType.Char).Value = neg.CoSubMenu;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public static int SP_ERP_SOP_MENU_ELIM(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_MENU_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coMenu", SqlDbType.Char).Value = neg.CoMenu;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public static int SP_ERP_SOP_MODULO_ELIM(NEG_SOP_MODULOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_MODULO_ELIM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coMod", SqlDbType.Char).Value = neg.CoMod;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }


    }
}
