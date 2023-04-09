using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace CRUD_CORE.Models

{
    public class Usuario
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "El campo Confirmar contraseña es obligatorio")]
        public string? ConfirmarClave { get; set; }

        public int? idRol { get; set; }
       
    }
    
}
