using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_NEGOCIOS.COMPRAS;

namespace CAPA_DATOS.COMPRAS
{
    public static class DAT_COM_SOLICITUD_PEDIDO
    {
        public static DataTable SP_ERP_COM_TIPO_DOCUMENTO_LS(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_COM_TIPO_DOCUMENTO_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable SP_EPR_COM_PROVCLI_LS(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_EPR_COM_PROVCLI_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable SP_ERP_COM_CONDICION_PAGO_LS(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_COM_CONDICION_PAGO_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static int SP_ERP_COM_TIPO_DOCUMENTO_GENERAR(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_COM_TIPO_DOCUMENTO_GENERAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opc", SqlDbType.Int).Value = neg.Opc;
            cmd.Parameters.Add("@coDoc", SqlDbType.VarChar).Value = neg.CoDoc;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = (int)cmd.ExecuteScalar();
            cn.Close();
            return i;
        }
        public static DataTable SP_EPR_COM_ORDEN_PEDIDO_CAB_LS(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_CAB_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cmd.Parameters.Add("@coSuc", SqlDbType.Char).Value = neg.CoSuc;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable SP_EPR_COM_ORDEN_PEDIDO_DET_LS(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_DET_LS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = neg.Opcion;
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = neg.Criterio;
            cmd.Parameters.Add("@tipoBien", SqlDbType.Char).Value = neg.TipoBien;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nuPed", SqlDbType.VarChar).Value = neg.NuPed;
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = neg.Estado;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
        public static int SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO_ORDEN_COMPRA(NEG_COM_SOLICITUD_PEDIDO neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO_ORDEN_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nuPed", SqlDbType.VarChar).Value = neg.NuPed;
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = neg.Estado;
            cmd.Parameters.Add("@coEmp", SqlDbType.Char).Value = neg.CoEmp;
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

    }
}
