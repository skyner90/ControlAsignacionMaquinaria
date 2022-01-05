using System.ComponentModel.DataAnnotations;

namespace ControlAsignacionMaquinariaBLL.DB
{
    [MetadataType(typeof(Asi_MaquinariaMetaData))]
    public partial class Asi_Maquinaria
    {
        public bool maqAsignadaEstado { get; set; }
    }

    /// <summary>
    /// Clase Asi_MaquinariaMetaData para agregar atributos
    /// </summary>
    public class Asi_MaquinariaMetaData
    {
        
    }
}
