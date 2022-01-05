using ControlAsignacionMaquinariaBLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlAsignacionMaquinariaBLL.BLL
{
    public class MaquinariaBLL
    {
        public static List<Asi_Maquinaria> listaMaquinarias()
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.OrderBy(x => x.maqSerie).ToList();
            return consultaMaquinaria;
        }

        public static List<Asi_Maquinaria> listaMaquinariasActivos()
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqEstado == true).OrderBy(x => x.maqSerie).ToList();
            return consultaMaquinaria;
        }

        public static List<Asi_Maquinaria> listaMaquinariasEmpleadosActivos()
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqEstado == true).OrderBy(x => x.maqSerie).ToList();
            return consultaMaquinaria;
        }

        public static List<Asi_Maquinaria> listaMaquinariasEmpleadosActivosId(Asi_Maquinaria maquinaria)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqEstado == true && n.empId == maquinaria.empId && n.maqDisponible==false).OrderBy(x => x.maqSerie).ToList();
            return consultaMaquinaria;
        }

        public static Asi_Maquinaria consultarMaquinaria(Asi_Maquinaria maquinaria)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqId == maquinaria.maqId).FirstOrDefault();
            return consultaMaquinaria;
        }

        public static bool crearMaquinaria(Asi_Maquinaria maquinaria)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqSerie == maquinaria.maqSerie).FirstOrDefault();
            if (consultaMaquinaria == null)
            {
                Asi_Maquinaria objeto = new Asi_Maquinaria();
                objeto.maqSerie = maquinaria.maqSerie;
                objeto.maqDescripcion = maquinaria.maqDescripcion;
                objeto.maqEstado = true;
                objeto.maqFechaCreacion = DateTime.Now;
                objeto.empId = 0;
                objeto.maqDisponible = true;
                db.Asi_Maquinaria.Add(objeto);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool editarMaquinaria(Asi_Maquinaria maquinaria)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqId == maquinaria.maqId).FirstOrDefault();
            if (consultaMaquinaria != null)
            {
                consultaMaquinaria.maqSerie = maquinaria.maqSerie;
                consultaMaquinaria.maqDescripcion = maquinaria.maqDescripcion;
                consultaMaquinaria.maqEstado = maquinaria.maqEstado;
                consultaMaquinaria.maqFechaCreacion = consultaMaquinaria.maqFechaCreacion;
                consultaMaquinaria.empId = 0;
                consultaMaquinaria.maqDisponible = consultaMaquinaria.maqDisponible;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool eliminarMaquinaria(Asi_Maquinaria maquinaria)
        {
            AsignacionMaquinariaDBEntities db = new AsignacionMaquinariaDBEntities();
            var consultaMaquinaria = db.Asi_Maquinaria.Where(n => n.maqId == maquinaria.maqId).FirstOrDefault();
            if (consultaMaquinaria != null)
            {
                consultaMaquinaria.maqEstado = false;
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
