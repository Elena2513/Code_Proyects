using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteControlDetenido.Controllers
{   
    [Authorize]  //Restringir el acceso solo a usuarios autenticados
    public class HomeController : Controller
    {
        [AllowAnonymous] //Para permitir acceso público a la parte del sistema
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}