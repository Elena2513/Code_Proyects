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
    [AllowAnonymous]  //Para permitir acceso público a la parte del sistema
    public class ConciliacionController : Controller
    {
        // GET: Conciliacion       
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Diferencia()
        {
            return View();
        }
        

        [HttpGet]       
        public JsonResult Listar_Consolidado(int tipo, string carnet, DateTime? inicio, DateTime? final)
        {

            inicio = (inicio == null) ? DateTime.Now : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(ConciliacionC.ToList_Ingresos(tipo, "", inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

       
        [HttpPost]    
        public JsonResult Save(List<ConciliacionE> data_Conciliar)
        {
            try
            {
                var user = Session["NombreCompleto"].ToString();
                foreach (var item in data_Conciliar)
                {
                    if (item.Id == 0)
                    {
                        item.Carnet = user;//user.Carnet;
                        ConciliacionC.Guardar(item);
                    }
                }

                return Json(new { mensaje = "Guardado con exito" });

            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Error! No se pudo guardar " + ex.Message });
            }
        }

       
        [HttpGet]      
        public JsonResult Listar_Diferencia(DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Now : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(ConciliacionC.ToList_Diferencia(inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        [HttpGet]       
        public JsonResult Listar_NoReportaDiferencia(DateTime? inicio, DateTime? final)
        {
            inicio = (inicio == null) ? DateTime.Now : inicio;
            final = (final == null) ? DateTime.Now : final;

            var json = Json(ConciliacionC.ToList_NoReportaDiferencia(inicio, final), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

    }
}
