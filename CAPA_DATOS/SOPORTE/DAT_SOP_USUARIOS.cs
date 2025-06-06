using System.Data.SqlClient;
using System.Data;
using CAPA_NEGOCIOS.SOPORTE;

namespace CAPA_DATOS.SOPORTE
{
    public static class DAT_SOP_USUARIOS
    {
        public static DataTable SP_ERP_SOP_USUARIO_BUSCAR(NEG_SOP_USUARIOS neg)
        {
            SqlConnection cn = new SqlConnection(Conexion.cadena);
            SqlCommand cmd = new SqlCommand("SP_ERP_SOP_USUARIO_BUSCAR", cn);
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
    }
}
