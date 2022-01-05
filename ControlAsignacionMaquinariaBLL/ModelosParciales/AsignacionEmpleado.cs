using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsignacionMaquinariaBLL.ModelosParciales
{
    public class AsignacionEmpleado
    {
        public List<ListaMaquinaria> ListaMaquinaria { get; set; } = new List<ListaMaquinaria>();
        public int empId { get; set; }
    }
    public class ListaMaquinaria
    {
        public int maqId { get; set; }
        public string Serie { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
    }

}
