using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAsignacionMaquinaria.Controllers
{
    public class ResumenController : Controller
    {
        // GET: Resumen
        /// <summary>
        /// Vista Resumen
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}