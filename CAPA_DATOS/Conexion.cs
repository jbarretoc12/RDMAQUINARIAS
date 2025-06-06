using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class Conexion
    {
        public static string cadena
        {
            get
            {
                //return @"server = 172.16.1.59\SQLGRD ; database =	BDFMBK ; user = ADM ;  password  =  ADM";  
                return @"server = RDDP01\SQLEXPRESS ; database =	BDPRUEBA ; user = SA ;  password  =  123456";
                //ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            }
        }
    }
}
