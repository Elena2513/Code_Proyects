using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortadoresArmas.Acciones
{
    class ReporteC
    {
        private static string Connection = "data source=PNSQLXX;initial catalog=SERVICIOS;user id=Sectorizar;password=S3ct0riz@#123";
        public static DataTable  Sectorizado (int tipo , string codigo)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("codigo",codigo));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("Iluna.sp_consolidado_sectorizacion_pa", parametros, CommandType.StoredProcedure, strConnString);
            return dt;
        }

        public static DataTable NoSectorizacion (int tipo, string codigo)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("codigo", codigo));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("Iluna.sp_consolidado_noSectorizacion_pa", parametros, CommandType.StoredProcedure, strConnString);
            return dt;
        }

       
    }
}
