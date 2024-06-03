using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteControlDetenido.Models.Acciones;
using SiteControlDetenido.Models.Entidades;

namespace SiteControlDetenido.Controllers
{
    //[Authorize]  //Restringir el acceso solo a usuarios autenticados    
    [AllowAnonymous] //Para permitir acceso público a la parte del sistema 
    public class EstadisticaController : Controller
    {
        // GET: Estadistica         
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult ConsolidadoPermanencia()
        {
            return View();
        }
        
        public ActionResult Consolidado()
        {
            return View();
        }

       
        public ActionResult Detenidos()
        {
            return View();
        }

       
        [HttpGet]
        public JsonResult Consolidado_Permanencia(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {

            inicio = (inicio == null) ? DateTime.Now : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.Consolidado_Permanencia(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        [HttpGet]
        public JsonResult ToList_consolidado(int Tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Now : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.Consolidado(Tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }



        //TOTALES DE INDICADORES DE CONTROL DE DETENIDO
        [HttpGet]       
        public JsonResult ToList_Detenido(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;            
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.TotalesDetenido(0, "", inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.TotalesDetenido(1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.TotalesDetenido(2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else 
            {
                var json = Json(EstadisticaC.TotalesDetenido(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]       
        public JsonResult ToList_IngresoEgreso(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {

            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;            
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_Ingreso_Egreso(0, "", inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_Ingreso_Egreso(1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_Ingreso_Egreso(2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_Ingreso_Egreso(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]     
        public JsonResult ToList_Delegaciones(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {

            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;           
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_Delegaciones(0, "", inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_Delegaciones(1, CodDepto, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_Delegaciones(2, CodDeleg, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_Delegaciones(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]       
        public JsonResult ToList_RangoHoraDia(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {

            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;            
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_HoraDia(0, "", inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_HoraDia(1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_HoraDia(2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_HoraDia(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]       
        public JsonResult ToList_ExtranjAdulto(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroAdulto(0, "", inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroAdulto(1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroAdulto(2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroAdulto(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }




        //MOVIMIENTO DETENIDO
        //canvas SALDO
        [HttpGet]     
        public JsonResult ToList_SaldoDeleg(int tipo, string codigo, DateTime? inicio)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_SaldoDeleg(0, "", inicio).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_SaldoDeleg(1, CodDepto, inicio).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_SaldoDeleg(2, CodDeleg, inicio).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_SaldoDeleg(tipo, codigo, inicio).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]        
        public JsonResult ToList_SaldoTodasDeleg(int tipo, string codigo, DateTime? inicio)
        {
          
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            var json = Json(EstadisticaC.Totales_SaldoDeleg(tipo, codigo, inicio).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
           
        }
        [HttpGet]
        public JsonResult ToList_DetalleSaldo(int tipo, string codigo, DateTime? inicio)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
          
            var json = Json(EstadisticaC.ToList_SaldoDetalle(tipo, codigo, inicio), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }


        //canvas INGRESOS
        [HttpGet]
        public JsonResult ToList_DelitosIngresos(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_Delitos_Ingresos(0, "", inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_Delitos_Ingresos(1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_Delitos_Ingresos(2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_Delitos_Ingresos(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            
        }       
        [HttpGet]
        public JsonResult ToList_IngresosDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_IngresosDeleg(0, "", inicio, final, clasificacion).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_IngresosDeleg(1, CodDepto, inicio, final, clasificacion).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_IngresosDeleg(2, CodDeleg, inicio, final, clasificacion).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_IngresosDeleg(tipo, codigo, inicio, final, clasificacion).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]
        public JsonResult ToList_IngresosTodasDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;
            
            var json = Json(EstadisticaC.Totales_IngresosDeleg(tipo, codigo, inicio, final, clasificacion).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
         

        }
        [HttpGet]
        public JsonResult ToList_DetalleIngreso(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_IngresoDetalle(tipo, codigo, inicio, final, clasificacion), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }



        //canvas EGRESOS
        [HttpGet]
        public JsonResult ToList_EgresosMovimientos(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if(perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_Egresos(0, "", inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_Egresos(1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_Egresos(2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_Egresos(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            
        }
        [HttpGet]
        public JsonResult ToList_EgresosDeleg(int perfil, int clasificacion, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil1 = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil1 == "Administrador" || perfil1 == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_EgresosDeleg(0, clasificacion, 0, "", inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil1 == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_EgresosDeleg(1, clasificacion, 1, CodDepto, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil1 == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_EgresosDeleg(2, clasificacion, 2, CodDeleg, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_EgresosDeleg(perfil, clasificacion, tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]
        public JsonResult ToList_EgresosTodasDeleg(int perfil, int clasificacion, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;
            
            var json = Json(EstadisticaC.Totales_EgresosDeleg(perfil, clasificacion, tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        
        }
        [HttpGet]
        public JsonResult ToList_DetalleEgreso(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_EgresoDetalle(tipo, codigo, inicio, final, clasificacion), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }



        //canvas CELDA
        [HttpGet]
        public JsonResult ToList_Delito(int perfil, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil1 = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;           
            final = (final == null) ? DateTime.Now : final;

            if(perfil1 == "Administrador" || perfil1 == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_Delitos(0, 0, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil1 == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_Delitos(1, 1, CodDepto, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if(perfil1 == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_Delitos(2, 2, CodDeleg, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_Delitos(perfil, tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
           

        }
        [HttpGet]
        public JsonResult ToList_CeldaDeleg(int perfil, int Clasificacion, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil1 = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;            
            final = (final == null) ? DateTime.Now : final;

            if (perfil1 == "Administrador" || perfil1 == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_CeldaDeleg(0, Clasificacion, 0, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil1 == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_CeldaDeleg(1, Clasificacion, 1, CodDepto, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil1 == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_CeldaDeleg(2, Clasificacion, 2, CodDeleg, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_CeldaDeleg(perfil, Clasificacion, tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]
        public JsonResult ToList_CeldaTodasDeleg(int perfil, int Clasificacion, int tipo, string codigo, DateTime? inicio, DateTime? final)
        {           
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;
            
            var json = Json(EstadisticaC.Totales_CeldaDeleg(perfil, Clasificacion, tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
           
        }
        [HttpGet]
        public JsonResult ToList_DetalleCelda(int tipo, string codigo, DateTime? inicio, DateTime? final, int clasificacion)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_CeldaDetalle(tipo, codigo, inicio, final, clasificacion), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }



        //DELEGACION
        [HttpGet]
        public JsonResult ToList_TodasDelegaciones(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;   
            
            var json = Json(EstadisticaC.Totales_Delegaciones(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
           

        }
        [HttpGet]
        public JsonResult ToList_DetalleDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            //final = (final == null) ? DateTime.Parse("2023-08-31") : final;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.Detalle_Delegacion(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }



        //TIEMPO DE PERMANENCIA EN CELDA
        [HttpGet]
        public JsonResult ToList_RangoDiaDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final, string rango)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_RangoDiaDeleg(0, codigo, inicio, final, rango).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_RangoDiaDeleg(1, CodDepto, inicio, final, rango).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_RangoDiaDeleg(2, CodDeleg, inicio, final, rango).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_RangoDiaDeleg(tipo, codigo, inicio, final, rango).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }


        }
        [HttpGet]
        public JsonResult ToList_RangoDiaTodasDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final, string rango)
        {            
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;
            
            var json = Json(EstadisticaC.Totales_RangoDiaDeleg(tipo, codigo, inicio, final, rango).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
          
        }
        [HttpGet]
        public JsonResult ToList_DetalleRangoDia(int tipo, string codigo, DateTime? inicio, DateTime? final, string rango)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_RangoDiaDetalle(tipo, codigo, inicio, final, rango), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }


        //EXTRANJERO
        [HttpGet]
        public JsonResult ToList_ExtranjeroDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroDeleg(0, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroDeleg(1, CodDepto, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroDeleg(2, CodDeleg, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_ExtranjeroDeleg(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }


        }
        [HttpGet]
        public JsonResult ToList_ExtranjeroTodasDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {           
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;
            
            var json = Json(EstadisticaC.Totales_ExtranjeroDeleg(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
           
        }
        [HttpGet]
        public JsonResult ToList_ExtranjeroDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_ExtranjeroDetalle(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }





        //ADULTOS MAYORES
        [HttpGet]
        public JsonResult ToList_AdultosMayorDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_AdultosMayorDeleg(0, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_AdultosMayorDeleg(1, CodDepto, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_AdultosMayorDeleg(2, CodDeleg, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_AdultosMayorDeleg(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }
        [HttpGet]
        public JsonResult ToList_AdultosMayorTodasDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.Totales_AdultosMayorDeleg(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;

        }
        [HttpGet]
        public JsonResult ToList_AdultoMayorDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_AdultoMayorDetalle(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        

        // PRISIÓN PREVENTIVA
        [HttpGet]
        public JsonResult ToList_PrisionPreventivaDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            string perfil = (string)Session["Perfil"];
            string CodDepto = (string)Session["CodDepto"];
            string CodDeleg = (string)Session["CodEstructura"];

            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            if (perfil == "Administrador" || perfil == "MIEMBRO DEL CONSEJO")
            {
                var json = Json(EstadisticaC.Totales_PrisionPreventivaDeleg(0, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE MANAGUA")
            {
                var json = Json(EstadisticaC.Totales_PrisionPreventivaDeleg(1, CodDepto, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else if (perfil == "JEFE DE DELEGACION ")
            {
                var json = Json(EstadisticaC.Totales_PrisionPreventivaDeleg(2, CodDeleg, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                var json = Json(EstadisticaC.Totales_PrisionPreventivaDeleg(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }

        }

        [HttpGet]
        public JsonResult ToList_PrisionPreventivaTodasDeleg(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.Totales_PrisionPreventivaDeleg(tipo, codigo, inicio, final).OrderByDescending<DelegacionE, int>((Func<DelegacionE, int>)(s => s.Total)), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;

        }
                
        [HttpGet]
        public JsonResult ToList_PrisionPreventivaDetalle(int tipo, string codigo, DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Parse("2023-01-01") : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(EstadisticaC.ToList_PrisionPreventivaDetalle(tipo, codigo, inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        //REPORTE DE DETENIDO
        [HttpGet]
        public JsonResult ToList_DetalleDetenido(int Idno)
        {
            var json = Json(DatosDetenidoC.Get_DatosDetenido(Idno), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        


    }
}
