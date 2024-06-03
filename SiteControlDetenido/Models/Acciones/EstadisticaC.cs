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
    public class EstadisticaC
    {
        public static List<ConsolidadoPermanenciaE> Consolidado_Permanencia(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<ConsolidadoPermanenciaE> listado = new List<ConsolidadoPermanenciaE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
           
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("codigo", codigo));
            parametros.Add(new SqlParameter("inicio", inicio));
            parametros.Add(new SqlParameter("final", final));
            string sql = "Sicond_ConsolidadoPermanencia";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                ConsolidadoPermanenciaE p = new ConsolidadoPermanenciaE();
                p.Codigo = dr["Codigo"].ToString();
                p.Descripcion = dr["Descripcion"].ToString();
                p.Total_Celda = int.Parse(dr["Total_Celda"].ToString());
                p.Capacidad_Celda = int.Parse(dr["Capacidad_Celda"].ToString());
                p.Recibido_Turno = int.Parse(dr["Recibido_Turno"].ToString());
                p.Egresos_Detenidos = int.Parse(dr["Egresos_Detenidos"].ToString());
                p.Ingreso_Detenidos = int.Parse(dr["Ingreso_Detenidos"].ToString());
                p.Detenidos_HombresAdult = int.Parse(dr["Detenidos_HombresAdult"].ToString());
                p.Detenidos_MujerAdult = int.Parse(dr["Detenidos_MujerAdult"].ToString());
                p.Detenido_HombreAdolesc = int.Parse(dr["Detenido_HombreAdolesc"].ToString());
                p.Detenido_MujerAdolesc = int.Parse(dr["Detenido_MujerAdolesc"].ToString());
                p.Total_Genero = int.Parse(dr["Total_Genero"].ToString());
                p.Procs_Investigativo = int.Parse(dr["Procs_Investigativo"].ToString());
                p.Jlocal_Penal = int.Parse(dr["Jlocal_Penal"].ToString());
                p.JDistrito_Penal = int.Parse(dr["JDistrito_Penal"].ToString());
                p.Juzgado_Adolesc = int.Parse(dr["Juzgado_Adolesc"].ToString());
                p.Detenido_Condenado = int.Parse(dr["Detenido_Condenado"].ToString());
                p.Tota_Detenidos = int.Parse(dr["Tota_Detenidos"].ToString());
                listado.Add(p);
            }

            return listado;
        }
        public static List<ConsolidadoE> Consolidado(int Tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<ConsolidadoE> listado = new List<ConsolidadoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Tipo", Tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Consolidado";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                ConsolidadoE c = new ConsolidadoE();
                c.Descripcion = dr["Descripcion"].ToString();
                c.Codigo = dr["Codigo"].ToString();
                c.Saldo_Anterior = int.Parse(dr["Saldo_Anterior"].ToString());
                c.Ingresos = int.Parse(dr["Ingresos"].ToString());
                c.Egresos = int.Parse(dr["Egresos"].ToString());
                c.Total_Gnral = int.Parse(dr["Total_Gnral"].ToString());
                c.Delitos = int.Parse(dr["Delitos"].ToString());
                c.Faltas = int.Parse(dr["Faltas"].ToString());
                c.Hombres = int.Parse(dr["Hombres"].ToString());
                c.Mujeres = int.Parse(dr["Mujeres"].ToString());
                c.Total = int.Parse(dr["Delitos"].ToString()) + int.Parse(dr["Faltas"].ToString());
                listado.Add(c);
            }

            return listado;
        }



        //PRINCIPAL
        public static EstadisticaE TotalesDetenido(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            EstadisticaE e = new EstadisticaE();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Estadistica";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            if (dt.Rows.Count > 0)
            {
                e.Total_Saldo = int.Parse(dt.Rows[0]["Total_Saldo"].ToString());
                e.Total_Egresos = int.Parse(dt.Rows[0]["Total_Egresos"].ToString());
                e.Total_Gnral = int.Parse(dt.Rows[0]["Total_Gnral"].ToString());
                e.Total_Detenidos = int.Parse(dt.Rows[0]["Total_Detenidos"].ToString());
                e.Total_HombreAdult = int.Parse(dt.Rows[0]["Total_HombreAdult"].ToString());
                e.Total_HombreAdolesc = int.Parse(dt.Rows[0]["Total_HombreAdolesc"].ToString());
                e.Total_MujerAdult = int.Parse(dt.Rows[0]["Total_MujerAdult"].ToString());
                e.Total_MujerAdolesc = int.Parse(dt.Rows[0]["Total_MujerAdolesc"].ToString());
                e.Total_SinSexo = int.Parse(dt.Rows[0]["Total_SinSexo"].ToString());
                e.Total_Extranjero = int.Parse(dt.Rows[0]["Total_Extranjero"].ToString());
                e.Total_AdultoMayor = int.Parse(dt.Rows[0]["Total_AdultoMayor"].ToString());
                e.Total_DetenidoMes = int.Parse(dt.Rows[0]["Total_DetenidoMes"].ToString());
            }

            return e;
        }

        public static List<DelitoE> Totales_Ingreso_Egreso(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelitoE> listado = new List<DelitoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Ingresos_Egresos";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelitoE d = new DelitoE();                
                d.Saldo = int.Parse(dr["Saldo"].ToString());
                d.Ingreso = int.Parse(dr["Ingresos"].ToString());
                d.Egreso = int.Parse(dr["Egresos"].ToString());
                d.Celda = int.Parse(dr["Celda"].ToString());                
                listado.Add(d);
            }

            return listado;
        }
       
        public static List<DelegacionE> Totales_Delegaciones(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_TotalDelegaciones";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }

        public static List<RangoHoraDiaE> Totales_HoraDia(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<RangoHoraDiaE> listado = new List<RangoHoraDiaE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_TotalRangoHoraDia";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                RangoHoraDiaE r = new RangoHoraDiaE();
                r.Clasificacion = dr["Clasificacion"].ToString();
                r.Total = int.Parse(dr["Total"].ToString());
                listado.Add(r);
            }

            return listado;
        }

        public static List<ExtrajAdultoE> Totales_ExtranjeroAdulto(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<ExtrajAdultoE> listado = new List<ExtrajAdultoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_TotalExtranjAdulto";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                ExtrajAdultoE e = new ExtrajAdultoE();
                e.Extranjero = int.Parse(dr["Extranjero"].ToString());
                e.Adulto = int.Parse(dr["Adulto"].ToString());
                e.PrisionPreventiva = int.Parse(dr["PrisionPreventiva"].ToString());
                listado.Add(e);
            }

            return listado;
        }


        //MOVIMIENTO DETENIDO
        //canvas SALDO
        public static List<DelegacionE> Totales_SaldoDeleg(int tipo, string codigo, DateTime? inicio)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));

            string sql = "Sicond_Clasificar_SaldoDeleg";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_SaldoDetalle(int tipo, string codigo, DateTime? inicio)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            
            string sql = "Sicond_Clasif_Saldo_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }


        //canvas INGRESOS
        public static List<DelitoE> Totales_Delitos_Ingresos(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelitoE> listado = new List<DelitoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Clasificacion_Ingresos";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelitoE d = new DelitoE();
                d.Codigo = int.Parse(dr["Codigo"].ToString());
                d.Clasificacion = dr["Clasificacion"].ToString();
                d.TOTAL = int.Parse(dr["TOTAL"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DelegacionE> Totales_IngresosDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Clasificacion", clasificacion));
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Clasificar_IngresosDeleg";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_IngresoDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            parametros.Add(new SqlParameter("Clasificacion", clasificacion));
            string sql = "Sicond_Clasificar_Ingreso_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }


        //canvas EGRESOS
        public static List<EgresosE> Totales_Egresos(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<EgresosE> listado = new List<EgresosE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Clasificacion_Egresos";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                EgresosE e = new EgresosE();
                e.Libertad = int.Parse(dr["Libertad"].ToString());
                e.TrasladoSPN = int.Parse(dr["TrasladoSPN"].ToString());
                e.Otros = int.Parse(dr["Otros"].ToString());
                listado.Add(e);
            }

            return listado;

        }
        public static List<DelegacionE> Totales_EgresosDeleg(int perfil,int Clasificacion, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("perfil", perfil));
            parametros.Add(new SqlParameter("Clasificacion", Clasificacion));
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_EgresoMovimiento_Deleg";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_EgresoDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            parametros.Add(new SqlParameter("clasificacion", clasificacion));
            string sql = "Sicond_EgresoMovimiento_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }


        //canvas CELDA
        public static List<DelitoE> Totales_Delitos(int perfil, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelitoE> listado = new List<DelitoE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("perfil", perfil));
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_TotalFalta_Delito";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelitoE d = new DelitoE();
                d.Clasificacion = dr["Clasificacion"].ToString();
                d.TOTAL = int.Parse(dr["TOTAL"].ToString());
                d.Codigo = int.Parse(dr["Codigo"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DelegacionE> Totales_CeldaDeleg(int perfil, int Clasificacion, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("perfil", perfil));
            parametros.Add(new SqlParameter("Clasificacion", Clasificacion));
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_TipoTrangresion";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_CeldaDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            parametros.Add(new SqlParameter("clasificacion", clasificacion));
            string sql = "Sicond_TipoTransgresion_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }


        //DELEGACION
        public static List<DetalleE> Detalle_Delegacion(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Detalle_Delegaciones";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }


        //TIEMPO DE PERMANENCIA EN CELDA
        public static List<DelegacionE> Totales_RangoDiaDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final, string rango)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Rango", rango));
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_RangoHoraDia_Dpto";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_RangoDiaDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final, string rango)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            parametros.Add(new SqlParameter("rango", rango));
            string sql = "Sicond_RangoDias_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }

        
        //EXTRANJERO
        public static List<DelegacionE> Totales_ExtranjeroDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
           
            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_Extranjero_Deleg";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_ExtranjeroDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));           
            string sql = "Sicond_Extranjero_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                d.Nacionalidad = dr["Nacionalidad"].ToString();
                listado.Add(d);
            }

            return listado;

        }


        //ADULTOS MAYORES
        public static List<DelegacionE> Totales_AdultosMayorDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_AdultoMayor_Deleg";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }
        public static List<DetalleE> ToList_AdultoMayorDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_AdultoMayor_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }

        // PRISIÓN PREVENTIVA
        public static List<DelegacionE> Totales_PrisionPreventivaDeleg( int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DelegacionE> listado = new List<DelegacionE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_PrisionPreventiva_Deleg";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DelegacionE d = new DelegacionE();
                d.Codigo = dr["Codigo"].ToString();
                d.Descripcion = dr["Descripcion"].ToString();
                d.Total = int.Parse(dr["Total"].ToString());
                listado.Add(d);
            }

            return listado;
        }

        public static List<DetalleE> ToList_PrisionPreventivaDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            List<DetalleE> listado = new List<DetalleE>();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("tipo", tipo));
            parametros.Add(new SqlParameter("Codigo", codigo));
            parametros.Add(new SqlParameter("Inicio", inicio));
            parametros.Add(new SqlParameter("Final", final));
            string sql = "Sicond_PrisionPreventiva_Detalle";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            foreach (DataRow dr in dt.Rows)
            {
                DetalleE d = new DetalleE();
                d.Idno = int.Parse(dr["Idno"].ToString());
                d.Nombre = dr["Nombre"].ToString();
                d.Identificacion = dr["Identificacion"].ToString();
                d.Delito = dr["Delito"].ToString();
                d.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                listado.Add(d);
            }

            return listado;

        }

    }
}