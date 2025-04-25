using PortadoresArmas.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PortadoresArmas.Data;

namespace PortadoresArmas.Acciones
{
    public static class CatalogoC
    {
       
        private static string Connection = "data source=PNSQLXX;initial catalog=CATALOGOS;user id=xx;password=lun@123";  // Uso este usuario por permisos para SP_Listar_Catalogos_localidad
        public static List<Catalogo> ToList(int tipo, string codigo)
        {
            List<Catalogo> listado = new List<Catalogo>();
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("codigo", codigo));
            DataTable dt = new DataTable();
            dt = Data.Data.Query("SP_Listar_Catalogos_localidad", parametros, CommandType.StoredProcedure, strConnString);
            foreach (DataRow dr in dt.Rows)
            {
                Catalogo c = new Catalogo();
                c.Codigo = dr["Codigo"].ToString();
                c.Descripcion = dr["Descripcion"].ToString();
                listado.Add(c);
            }
            return listado;
        }
       public static DataTable Delegaciones()
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataTable dt = new DataTable();
            dt = Data.Data.Query("Select * From Vw_DelegacionSigesproc", parametros, CommandType.Text, strConnString);
            return dt;
        }

    }
}
