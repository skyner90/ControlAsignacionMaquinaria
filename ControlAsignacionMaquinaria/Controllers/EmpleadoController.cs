using ControlAsignacionMaquinariaBLL.BLL;
using ControlAsignacionMaquinariaBLL.DB;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControlAsignacionMaquinaria.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        /// <summary>
        /// Vista Empleado
        /// </summary>
        /// <returns>lista Empleados</returns>
        public ActionResult Index()
        {
            List<Asi_Empleado> listaEmpleado = EmpleadoBLL.listaEmpleados();
            return View(listaEmpleado);
        }

        #region JSON Get-Post
        /// <summary>
        /// Consulta datos del empleado
        /// </summary>
        /// <param name="empleado">objeto Empleado</param>
        /// <returns>lista con los datos del empleado JSON</returns>
        public JsonResult consultarEmpleado(Asi_Empleado empleado)
        {
            Asi_Empleado objRetorno = EmpleadoBLL.consultarEmpleado(empleado);
            Asi_Empleado objeto = new Asi_Empleado();
            objeto.empId = objRetorno.empId;
            objeto.empNombre = objRetorno.empNombre;
            objeto.empCargo = objRetorno.empCargo;
            objeto.empCedula = objRetorno.empCedula;
            objeto.empArea = objRetorno.empArea;
            objeto.empFechaCreacion = objRetorno.empFechaCreacion;
            objeto.empEstado = objRetorno.empEstado;
 
            return Json(objeto, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Registro de un nuevo Empleado
        /// </summary>
        /// <param name="empleado">Objeto empleado</param>
        /// <returns>JSON bool</returns>
        public JsonResult nuevoEmpleado(Asi_Empleado empleado)
        {
            bool objRetorno;
            objRetorno = EmpleadoBLL.crearEmpleado(empleado);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Editar Empleado
        /// </summary>
        /// <param name="empleado">Objeto Empleado</param>
        /// <returns>JSON bool</returns>
        public JsonResult editarEmpleado(Asi_Empleado empleado)
        {
            bool objRetorno;
            objRetorno = EmpleadoBLL.editarEmpleado(empleado);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Eliminar Empleado
        /// </summary>
        /// <param name="empleado">Objeto Empleado</param>
        /// <returns>JSON bool</returns>
        public JsonResult eliminarEmpleado(Asi_Empleado empleado)
        {
            bool objRetorno;
            objRetorno = EmpleadoBLL.eliminarEmpleado(empleado);
            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Consulta de todos los Empleado
        /// </summary>
        /// <returns>Lista JSON con los empleados</returns>
        public JsonResult consultarEmpleadoJSON()
        {
            List<Asi_Empleado> lista = EmpleadoBLL.listaEmpleadosActivos();
            List<Asi_Empleado> objRetorno = new List<Asi_Empleado>();
            foreach (var item in lista)
            {
                Asi_Empleado objeto = new Asi_Empleado();
                objeto.empId = item.empId;
                objeto.empNombre = item.empNombre;
                objeto.empCedula = item.empCedula;
                objRetorno.Add(objeto);
            }

            return Json(objRetorno, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}