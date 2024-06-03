using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using SiteControlDetenido.Models.Entidades;
namespace SiteControlDetenido.Models.Acciones
{
    public class MovimientoC
    {
        //MOVIMIENTOS
        public static List<MovimientoE> ToList_BajaPresunto(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 0));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.MotivoObserva = dr["MotivoObserva"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_OrdenLibertad(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 1));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.OrdenLibertad = dr["OrdenLibertad"].ToString();
                m.NoExpediente = dr["NoExpediente"].ToString();
                m.JefeAutoriza = dr["JefeAutoriza"].ToString();
                m.MotivoLibertad = dr["MotivoLibertad"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_AsistenciaJuzgado(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 2));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.NoAsunto = dr["NoAsunto"].ToString();
                m.Juzgado = dr["Juzgado"].ToString();
                m.Ubicacion = dr["Ubicacion"].ToString();
                m.Procesos = dr["Procesos"].ToString();
                m.MotivoJuzgado = dr["MotivoJuzgado"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_TrasladoSPN(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 3));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.OficialEntrega = dr["OficialEntrega"].ToString();
                m.OficialRecibe = dr["OficialRecibe"].ToString();
                m.MotivoTraslado = dr["MotivoTraslado"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_TrasladoDelegacion(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 4));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.OrdenTraslado = dr["OrdenTraslado"].ToString();
                m.NoExpedienteT = dr["NoExpedienteT"].ToString();
                m.JefeAutorizaT = dr["JefeAutorizaT"].ToString();
                m.OficialET = dr["OficialET"].ToString();
                m.OficialRT = dr["OficialRT"].ToString();
                m.MotivoTD = dr["MotivoTD"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_TrasladoCelda(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 5));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.MotivoObservaTC = dr["MotivoObservaTC"].ToString();
                m.CeldaActual = dr["CeldaActual"].ToString();
                m.CeldaDestino = dr["CeldaDestino"].ToString();
                m.MotivoCelda = dr["MotivoCelda"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_AsistenciaMedica(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 6));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.NombreDoctor = dr["NombreDoctor"].ToString();
                m.ValoracionMedica = dr["ValoracionMedica"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_ValoracionMedica(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 7));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.ForenceA = dr["ForenceA"].ToString();
                m.Valoracion = dr["Valoracion"].ToString();
                m.IML = dr["IML"].ToString();
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_ReunionColectiva(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 8));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.MotivoObservaRC = dr["MotivoObservaRC"].ToString();                
                listado.Add(m);
            }

            return listado;
        }

        public static List<MovimientoE> ToList_PrisionPreventiva(int Idno)
        {
            List<MovimientoE> listado = new List<MovimientoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Idno", Idno));
            parametros.Add(new SqlParameter("tipo", 9));
            string sql = "Sicond_Datos_MovimientoD";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                MovimientoE m = new MovimientoE();
                m.Idno = int.Parse(dr["Idno"].ToString());
                m.IDD = int.Parse(dr["IDD"].ToString());
                m.Motivo = dr["Motivo"].ToString();
                m.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                m.NoAsunto = dr["NoAsunto"].ToString();
                m.Juzgado = dr["Juzgado"].ToString();
                m.Ubicacion = dr["Ubicacion"].ToString();
                m.Procesos = dr["Procesos"].ToString();
                m.MotivoJuzgado = dr["MotivoJuzgado"].ToString();
                listado.Add(m);
            }

            return listado;
        }



        //DELITOS
        public static List<DetalleDelitoE> ToList_Delito(int Idno, int tipo)
        {
            List<DetalleDelitoE> listado = new List<DetalleDelitoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Idno", Idno));
            string sql = "Sicond_Datos_Delito";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleDelitoE d = new DetalleDelitoE();
                d.IDD = int.Parse(dr["IDD"].ToString());
                d.idno = int.Parse(dr["idno"].ToString());
                d.Delito = dr["Delito"].ToString();
                try
                {
                    d.FechaDetencion = DateTime.Parse(dr["FechaDetencion"].ToString());
                }
                catch 
                {
                    d.FechaDetencion = DateTime.Parse("2023-01-01");
                }
                
                d.HoraDetencion = dr["HoraDetencion"].ToString();
                d.Investigador = dr["Investigador"].ToString();
                d.LugarDetencion = dr["LugarDetencion"].ToString();
                d.Celda = dr["Celda"].ToString();
                d.TipoDetencion = dr["TipoDetencion"].ToString();
                d.MotivoDetencion = dr["MotivoDetencion"].ToString();
                d.Codigo = dr["Codigo"].ToString();                
                listado.Add(d);
            }

            return listado;
        }
    }
}