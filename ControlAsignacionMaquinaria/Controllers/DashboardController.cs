using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAsignacionMaquinaria.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashborad
        /// <summary>
        /// Vista Principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}