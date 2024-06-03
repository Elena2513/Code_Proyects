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
    public class UsuarioC
    {
     
        public static UsuarioE Get_Usuario(string Usuario, string Contrasena)
        {
            UsuarioE u = new UsuarioE();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Usuario", Usuario));
            parametros.Add(new SqlParameter("Contrasena", Contrasena));
            string sql = "Sicond_BuscarUsuario";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            if (dt.Rows.Count > 0)
            {
                u.CodUsuario = dt.Rows[0]["CodUsuario"].ToString();
                u.Usuario = dt.Rows[0]["Usuario"].ToString();
                u.Contrasena = dt.Rows[0]["Contrasena"].ToString();
                u.CodEstructura = dt.Rows[0]["CodEstructura"].ToString();
                u.Estructura = dt.Rows[0]["Estructura"].ToString();
                u.NombreCompleto = dt.Rows[0]["NombreCompleto"].ToString();
                u.Perfil = dt.Rows[0]["Perfil"].ToString();
                u.CodDepto = dt.Rows[0]["CodDepto"].ToString();
                u.Depto = dt.Rows[0]["Depto"].ToString();
             
            }

            return u;

        }

    }
}