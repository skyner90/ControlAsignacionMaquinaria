//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlAsignacionMaquinariaBLL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asi_Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asi_Empleado()
        {
            this.Asi_Maquinaria = new HashSet<Asi_Maquinaria>();
        }
    
        public int empId { get; set; }
        public string empNombre { get; set; }
        public string empCargo { get; set; }
        public string empCedula { get; set; }
        public string empArea { get; set; }
        public Nullable<System.DateTime> empFechaCreacion { get; set; }
        public Nullable<bool> empEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asi_Maquinaria> Asi_Maquinaria { get; set; }
    }
}
