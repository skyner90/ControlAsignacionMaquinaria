using ControlAsignacionMaquinariaBLL.BLL;
using ControlAsignacionMaquinariaBLL.ModelosParciales;
using System.Web.Mvc;

namespace ControlAsignacionMaquinaria.Controllers
{
    public class AsignacionController : Controller
    {
        // GET: Asignacion
        /// <summary>
        /// Vista Asignacion
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #region JSON Get-Post
        /// <summary>
        /// Registro de las asignaciones de maquinaria
        /// </summary>
        /// <param name="asignacion">Objeto AsignacionEmpleado</param>
        /// <returns>JSON bool</returns>
        public JsonResult nuevaAsignacion(AsignacionEmpleado asignacion)
        {
            bool objRetorno;
            objRetorno = AsignacionBLL.editarAsignacion(asignacion);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}