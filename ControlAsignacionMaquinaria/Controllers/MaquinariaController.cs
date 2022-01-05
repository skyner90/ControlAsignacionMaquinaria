using ControlAsignacionMaquinariaBLL.BLL;
using ControlAsignacionMaquinariaBLL.DB;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControlAsignacionMaquinaria.Controllers
{
    public class MaquinariaController : Controller
    {
        // GET: Maquinaria
        /// <summary>
        /// Vista maquinaria
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Asi_Maquinaria> listaMaquinaria = MaquinariaBLL.listaMaquinarias();
            return View(listaMaquinaria);
        }

        #region JSON Get-Post
        /// <summary>
        /// Consulta de todas las maquinarias
        /// </summary>
        /// <param name="maquinaria">Objeto maquinaria</param>
        /// <returns>Lista de todas las maquinarias JSON</returns>
        public JsonResult consultarMaquinaria(Asi_Maquinaria maquinaria)
        {
            Asi_Maquinaria objRetorno = MaquinariaBLL.consultarMaquinaria(maquinaria);
            Asi_Maquinaria objeto = new Asi_Maquinaria();
            objeto.maqId = objRetorno.maqId;
            objeto.maqSerie = objRetorno.maqSerie;
            objeto.maqDescripcion = objRetorno.maqDescripcion;
            objeto.maqEstado = objRetorno.maqEstado;
            objeto.maqFechaCreacion = objRetorno.maqFechaCreacion;
            objeto.empId = objRetorno.empId;
            objeto.maqDisponible = objRetorno.maqDisponible;
            return Json(objeto, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// registro de una nueva maquinaria
        /// </summary>
        /// <param name="maquinaria">Objeto Maquinaria</param>
        /// <returns>JSON bool</returns>
        public JsonResult nuevoMaquinaria(Asi_Maquinaria maquinaria)
        {
            bool objRetorno;
            objRetorno = MaquinariaBLL.crearMaquinaria(maquinaria);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Editar maquinaria
        /// </summary>
        /// <param name="maquinaria">Objeto maquinaria</param>
        /// <returns>JSON bool</returns>
        public JsonResult editarMaquinaria(Asi_Maquinaria maquinaria)
        {
            bool objRetorno;
            objRetorno = MaquinariaBLL.editarMaquinaria(maquinaria);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Eliminar maquinaria, cambio de estado
        /// </summary>
        /// <param name="maquinaria">Objeto maquinaria</param>
        /// <returns>JSON bool</returns>
        public JsonResult eliminarMaquinaria(Asi_Maquinaria maquinaria)
        {
            bool objRetorno;
            objRetorno = MaquinariaBLL.eliminarMaquinaria(maquinaria);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta de todas las maquinaria activas
        /// </summary>
        /// <returns>Lista JSON</returns>
        public JsonResult consultarMaquinariaJSON()
        {
            List<Asi_Maquinaria> lista = MaquinariaBLL.listaMaquinariasActivos();
            List<Asi_Maquinaria> objRetorno = new List<Asi_Maquinaria>();
            foreach (var item in lista)
            {
                Asi_Maquinaria objeto = new Asi_Maquinaria();
                objeto.maqId = item.maqId;
                objeto.maqSerie = item.maqSerie;
                objeto.maqDescripcion = item.maqDescripcion;
                objeto.empId = item.empId;
                objRetorno.Add(objeto);
            }

            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta de las Maquinarias Activas por Empleados Asignados
        /// </summary>
        /// <param name="maquinaria">Objeto Maquinaria</param>
        /// <returns>Lista JSON</returns>
        public JsonResult consultarMaquinariaEmpleado(Asi_Maquinaria maquinaria)
        {
            List<Asi_Maquinaria> lista = MaquinariaBLL.listaMaquinariasEmpleadosActivos();
            List<Asi_Maquinaria> objRetorno = new List<Asi_Maquinaria>();
            foreach (var item in lista)
            {
                if (item.empId == maquinaria.empId)
                {
                    Asi_Maquinaria objeto = new Asi_Maquinaria();
                    objeto.maqId = item.maqId;
                    objeto.maqSerie = item.maqSerie;
                    objeto.maqDescripcion = item.maqDescripcion;
                    objeto.empId = item.empId;
                    objeto.maqDisponible = item.maqDisponible;
                    objeto.maqAsignadaEstado = true;
                    objRetorno.Add(objeto);
                }
                else
                {
                    Asi_Maquinaria objeto = new Asi_Maquinaria();
                    objeto.maqId = item.maqId;
                    objeto.maqSerie = item.maqSerie;
                    objeto.maqDescripcion = item.maqDescripcion;
                    objeto.empId = item.empId;
                    objeto.maqDisponible = item.maqDisponible;
                    objeto.maqAsignadaEstado = false;
                    objRetorno.Add(objeto);
                }

            }

            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta de las Maquinarias Activas por Empleados Asignados por su Id
        /// </summary>
        /// <param name="maquinaria">Objeto Maquinaria</param>
        /// <returns>Lista JSON</returns>
        public JsonResult consultarMaquinariaEmpleadoId(Asi_Maquinaria maquinaria)
        {
            List<Asi_Maquinaria> lista = MaquinariaBLL.listaMaquinariasEmpleadosActivosId(maquinaria);
            List<Asi_Maquinaria> objRetorno = new List<Asi_Maquinaria>();
            foreach (var item in lista)
            {
                Asi_Maquinaria objeto = new Asi_Maquinaria();
                objeto.maqId = item.maqId;
                objeto.maqSerie = item.maqSerie;
                objeto.maqDescripcion = item.maqDescripcion;
                objeto.empId = item.empId;
                objeto.maqDisponible = item.maqDisponible;
                objeto.maqAsignadaEstado = item.maqAsignadaEstado;
                objRetorno.Add(objeto);
            }
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}