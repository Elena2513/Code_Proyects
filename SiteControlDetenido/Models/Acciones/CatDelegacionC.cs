using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SiteControlDetenido.Models.Entidades;

namespace SiteControlDetenido.Models.Acciones
{
    public class CatDelegacionC
    {
        public static CatDelegacionE Get_Delegacion(string delegacion)
        {

            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("delegacion", delegacion));
            string sql = "SELECT  * FROM dbo.Delegaciones Where  (CodDelegacionPolicial=@delegacion OR @delegacion='')";
            DataTable dt = new DataTable();
            dt = Data.Query(sql, parametros, System.Data.CommandType.Text, strConnString);
            CatDelegacionE m = new CatDelegacionE();
            m.CodDelegacionPolicial = dt.Rows[0]["CodDelegacionPolicial"].ToString();          
            m.DelegacionPolicial = dt.Rows[0]["DelegacionPolicial"].ToString();

            return m;
        }

        public static List<CatDelegacionE> DelegacionPadre()
        {
            List<CatDelegacionE> listado = new List<CatDelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            string sql = "SELECT * FROM Delegaciones ORDER BY DelegacionPolicial";
            DataTable dt = new DataTable();
            dt = Data.Query(sql, parametros, System.Data.CommandType.Text, strConnString);
            foreach (DataRow dr in dt.Rows)
            {
                CatDelegacionE m = new CatDelegacionE();
                m.CodDelegacionPolicial = dr["CodDelegacionPolicial"].ToString();
                m.DelegacionPolicial = dr["DelegacionPolicial"].ToString();               
                listado.Add(m);
            }
            return listado;
        }

    }
}