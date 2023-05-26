using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace CRUD_CORE.Models
{
    public class VentaModel
    {

        public int idVenta { get; set; }
        
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        

        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public int? Precio { get; set; }

        [Required(ErrorMessage = "El campo Dia de la venta es obligatorio")]
        public DateTime? DiaVenta { get; set; }

    }
}
 