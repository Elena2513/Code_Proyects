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
    public class BusquedaController : Controller
    {
        // GET: Busqueda       
        public ActionResult Index()
        {
            return View();
        }

        // GET: Busqueda/Details/5      
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public JsonResult Listado_DatosDetenido(int tipo, string descripcion)
        {            
            var json = Json(BusquedaC.ToList_DatosDetenido(tipo, descripcion), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }



        // POST: Busqueda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Busqueda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Busqueda/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
