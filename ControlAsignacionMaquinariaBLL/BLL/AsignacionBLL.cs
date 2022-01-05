using ControlAsignacionMaquinariaBLL.DB;
using ControlAsignacionMaquinariaBLL.ModelosParciales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlAsignacionMaquinariaBLL.BLL
{
    public class AsignacionBLL
    {
                
        public static bool editarAsignacion(AsignacionEmpleado asignacion)
        {

            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaAsignacion = db.Asi_Maquinaria.Where(x => x.empId == asignacion.empId).ToList();
            //Eliminar Registros y Agregar datos a la tabla Phases Details
            if (consultaAsignacion.Count > 0)
            {
                foreach (var asig in consultaAsignacion)
                {
                    asig.empId = null;
                    asig.maqDisponible = true;
                    db.SaveChanges();
                }



            }
            if (asignacion.ListaMaquinaria.Count > 0)
            {

                foreach (var maquinaria in asignacion.ListaMaquinaria)
                {
                    var consultarMaquinaria = db.Asi_Maquinaria.Where(x => x.maqId == maquinaria.maqId).FirstOrDefault();
                    if (consultarMaquinaria != null)
                    {
                        consultarMaquinaria.empId = asignacion.empId;
                        consultarMaquinaria.maqDisponible = false;

                        db.SaveChanges();
                    }
                }
            }
            return true;
        }

    }
}

