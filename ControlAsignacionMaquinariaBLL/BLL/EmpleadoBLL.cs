using ControlAsignacionMaquinariaBLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlAsignacionMaquinariaBLL.BLL
{
    public class EmpleadoBLL
    {
        public static List<Asi_Empleado> listaEmpleados()
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaEmpleados = db.Asi_Empleado.OrderBy(x => x.empNombre).ToList();
            return consultaEmpleados;
        }

        public static List<Asi_Empleado> listaEmpleadosActivos()
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaEmpleados = db.Asi_Empleado.Where(n => n.empEstado == true).OrderBy(x => x.empNombre).ToList();
            return consultaEmpleados;
        }

        public static Asi_Empleado consultarEmpleado(Asi_Empleado empleado)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaEmpleado = db.Asi_Empleado.Where(n => n.empId == empleado.empId).FirstOrDefault();
            return consultaEmpleado;
        }

        public static bool crearEmpleado(Asi_Empleado empleado)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaEmpleado = db.Asi_Empleado.Where(n => n.empNombre == empleado.empNombre).FirstOrDefault();
            if (consultaEmpleado == null)
            {
                Asi_Empleado objeto = new Asi_Empleado();
                objeto.empNombre = empleado.empNombre;
                objeto.empCargo = empleado.empCargo;
                objeto.empCedula = empleado.empCedula;
                objeto.empArea = empleado.empArea;
                objeto.empEstado = true;
                objeto.empFechaCreacion = DateTime.Now;
                db.Asi_Empleado.Add(objeto);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool editarEmpleado(Asi_Empleado empleado)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaEmpleado = db.Asi_Empleado.Where(n => n.empId   == empleado.empId).FirstOrDefault();
            if (consultaEmpleado != null)
            {
                consultaEmpleado.empNombre = empleado.empNombre;
                consultaEmpleado.empCargo = empleado.empCargo;
                consultaEmpleado.empCedula = empleado.empCedula;
                consultaEmpleado.empArea = empleado.empArea;
                consultaEmpleado.empEstado = empleado.empEstado;
                consultaEmpleado.empFechaCreacion = consultaEmpleado.empFechaCreacion;
             
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool eliminarEmpleado(Asi_Empleado empleado)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaEmpleado = db.Asi_Empleado.Where(n => n.empId == empleado.empId).FirstOrDefault();
            if (consultaEmpleado != null)
            {
                consultaEmpleado.empEstado = false;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
