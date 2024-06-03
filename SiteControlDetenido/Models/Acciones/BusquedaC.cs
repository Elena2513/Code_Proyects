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
    public class BusquedaC
    {
        public static List<DatosDetenidoE> ToList_DatosDetenido(int tipo, string descripcion)
        {
            List<DatosDetenidoE> listado = new List<DatosDetenidoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("descripcion", descripcion));
            string sql = "Sicond_Busqueda_Detenido";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach(DataRow dr in dt.Rows)
            {
                DatosDetenidoE d = new DatosDetenidoE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Cedula = dr["Cedula"].ToString();
                d.NombreCompleto = dr["NombreCompleto"].ToString();
                d.Nombre1 = dr["Nombre1"].ToString();
                d.Nombre2 = dr["Nombre2"].ToString();
                d.Apellido1 = dr["Apellido1"].ToString();
                d.Apellido2 = dr["Apellido2"].ToString();
                d.Alias = dr["Alias"].ToString();                
                try
                {
                    d.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                    d.Foto = DatosDetenidoC.Fotopersona(d.Idno);
                }
                catch 
                {
                    d.FechaRegistro = DateTime.Now;
                    d.Foto = "";
                } 
               
                listado.Add(d);
            }

            return listado;
        }

    }
}