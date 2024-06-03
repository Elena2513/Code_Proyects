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
    public class ConciliacionC
    {
        public static List<ConciliacionE> ToList_Ingresos(int tipo, string carnet, DateTime? inicio, DateTime? final)
        {
            List<ConciliacionE> listado = new List<ConciliacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("carnet", carnet));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_ListadoConciliacion";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                ConciliacionE c = new ConciliacionE();
                c.Id = int.Parse(dr["Id"].ToString());
                c.FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString());
                c.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                c.CodDelegacion = dr["CodDelegacion"].ToString();
                c.DelegacionPolicial = CatDelegacionC.Get_Delegacion(c.CodDelegacion).DelegacionPolicial;
                c.TotalDetenidos = int.Parse(dr["TotalDetenidos"].ToString());
                c.RecibidoDia = int.Parse(dr["RecibidoDia"].ToString());
                c.IngresoDelito = int.Parse(dr["IngresoDelito"].ToString());
                c.IngresoFalta = int.Parse(dr["IngresoFalta"].ToString());
                c.IngresoTransito = int.Parse(dr["IngresoTransito"].ToString());
                c.EgresoOrdenLibertad = int.Parse(dr["EgresoOrdenLibertad"].ToString());
                c.EgresoTrasladoSPN = int.Parse(dr["EgresoTrasladoSPN"].ToString());
                c.EgresoTrasladoDelegacion = int.Parse(dr["EgresoTrasladoDelegacion"].ToString());
                c.HombreAdulto = int.Parse(dr["HombreAdulto"].ToString());
                c.MujerAdulta = int.Parse(dr["MujerAdulta"].ToString());
                c.HombreAdolescente = int.Parse(dr["HombreAdolescente"].ToString());
                c.MujerAdolescente = int.Parse(dr["MujerAdolescente"].ToString());
                c.Carnet = dr["Carnet"].ToString();
                //c.Nombre = UsuarioC.get(c.Carnet).Nombre;
                listado.Add(c);
            }
            return listado;
        }

        public static int Guardar(ConciliacionE C)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
           
            parametros.Add(new SqlParameter("FechaIngreso", C.FechaIngreso));
            parametros.Add(new SqlParameter("CodDelegacion", C.CodDelegacion));
            parametros.Add(new SqlParameter("TotalDetenidos", C.TotalDetenidos));
            parametros.Add(new SqlParameter("RecibidoDia", C.RecibidoDia));
            parametros.Add(new SqlParameter("IngresoDelito", C.IngresoDelito));
            parametros.Add(new SqlParameter("IngresoFalta", C.IngresoFalta));
            parametros.Add(new SqlParameter("IngresoTransito", C.IngresoTransito));
            parametros.Add(new SqlParameter("EgresoOrdenLibertad", C.EgresoOrdenLibertad));
            parametros.Add(new SqlParameter("EgresoTrasladoSPN", C.EgresoTrasladoSPN));
            parametros.Add(new SqlParameter("EgresoTrasladoDelegacion", C.EgresoTrasladoDelegacion));
            parametros.Add(new SqlParameter("HombreAdulto", C.HombreAdulto));
            parametros.Add(new SqlParameter("MujerAdulta", C.MujerAdulta));
            parametros.Add(new SqlParameter("HombreAdolescente", C.HombreAdolescente));
            parametros.Add(new SqlParameter("MujerAdolescente", C.MujerAdolescente));
            parametros.Add(new SqlParameter("Carnet", C.Carnet));
            string query = "Sicond_GuardarConciliacion";
            DataTable dt = Data.Query(query, parametros, System.Data.CommandType.StoredProcedure, strConnString);         
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static List<ConciliacionDiferenciaE> ToList_Diferencia(DateTime? inicio, DateTime? final)
        {
            List<ConciliacionDiferenciaE> listado = new List<ConciliacionDiferenciaE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", 1));
            parametros.Add(new SqlParameter("carnet", ""));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_CTEConciliacion";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                ConciliacionDiferenciaE d = new ConciliacionDiferenciaE();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Codigo = dr["Codigo"].ToString();
                d.Fisico_TotalDetenidos = int.Parse(dr["Fisico_TotalDetenidos"].ToString());
                d.Sicond_TotalDetenidos = int.Parse(dr["Sicond_TotalDetenidos"].ToString());
                d.Diferencia_TotalDetenidos = int.Parse(dr["Diferencia_TotalDetenidos"].ToString());
                d.fisico_RecibidoDia = int.Parse(dr["fisico_RecibidoDia"].ToString());
                d.sicond_RecibidoDia = int.Parse(dr["sicond_RecibidoDia"].ToString());
                d.Diferencia_RecibidoDia = int.Parse(dr["Diferencia_RecibidoDia"].ToString());
                d.Fisico_IngresoDelito = int.Parse(dr["Fisico_IngresoDelito"].ToString());
                d.Sicond_IngresoDelito = int.Parse(dr["Sicond_IngresoDelito"].ToString());
                d.Diferencia_IngresoDelito = int.Parse(dr["Diferencia_IngresoDelito"].ToString());
                d.Sicond_IngresoFalta = int.Parse(dr["Sicond_IngresoFalta"].ToString());
                d.Fisico_IngresoFalta = int.Parse(dr["Fisico_IngresoFalta"].ToString());
                d.Diferencia_IngresoFalta = int.Parse(dr["Diferencia_IngresoFalta"].ToString());
                d.Sicond_IngresoTransito = int.Parse(dr["Sicond_IngresoTransito"].ToString());
                d.Fisico_IngresoTransito = int.Parse(dr["Fisico_IngresoTransito"].ToString());
                d.Diferencia_IngresoTransito = int.Parse(dr["Diferencia_IngresoTransito"].ToString());
                d.Sicond_EgresoLibertad = int.Parse(dr["Sicond_EgresoLibertad"].ToString());
                d.Fisico_EgresoLibertad = int.Parse(dr["Fisico_EgresoLibertad"].ToString());
                d.Diferencia_EgresoLibertad = int.Parse(dr["Diferencia_EgresoLibertad"].ToString());
                d.Sicond_EgresoTrasladoSPN = int.Parse(dr["Sicond_EgresoTrasladoSPN"].ToString());
                d.Fisico_EgresoTrasladoSPN = int.Parse(dr["Fisico_EgresoTrasladoSPN"].ToString());
                d.Diferencia_EgresoTrasladoSPN = int.Parse(dr["Diferencia_EgresoTrasladoSPN"].ToString());
                d.Sicond_EgresoTrasladoDeleg = int.Parse(dr["Sicond_EgresoTrasladoDeleg"].ToString());                
                d.Fisico_EgresoTrasladoDeleg = int.Parse(dr["Fisico_EgresoTrasladoDeleg"].ToString());
                d.Diferencia_EgresoTrasladoDeleg = int.Parse(dr["Diferencia_EgresoTrasladoDeleg"].ToString());

                listado.Add(d);
            }

            return listado;

        }

        public static List<ConciliacionDiferenciaE> ToList_NoReportaDiferencia(DateTime? inicio, DateTime? final)
        {
            List<ConciliacionDiferenciaE> listado = new List<ConciliacionDiferenciaE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", 0));
            parametros.Add(new SqlParameter("carnet", ""));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_CTEConciliacion";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                ConciliacionDiferenciaE d = new ConciliacionDiferenciaE();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Codigo = dr["Codigo"].ToString(); 
                d.Sicond_TotalDetenidos = int.Parse(dr["Sicond_TotalDetenidos"].ToString());
                d.sicond_RecibidoDia = int.Parse(dr["sicond_RecibidoDia"].ToString());                
                d.Sicond_IngresoDelito = int.Parse(dr["Sicond_IngresoDelito"].ToString());                
                d.Sicond_IngresoFalta = int.Parse(dr["Sicond_IngresoFalta"].ToString());                
                d.Sicond_IngresoTransito = int.Parse(dr["Sicond_IngresoTransito"].ToString());                
                d.Sicond_EgresoLibertad = int.Parse(dr["Sicond_EgresoLibertad"].ToString());                
                d.Sicond_EgresoTrasladoSPN = int.Parse(dr["Sicond_EgresoTrasladoSPN"].ToString());                
                d.Sicond_EgresoTrasladoDeleg = int.Parse(dr["Sicond_EgresoTrasladoDeleg"].ToString());                
                listado.Add(d);
            }

            return listado;

        }


    }
}