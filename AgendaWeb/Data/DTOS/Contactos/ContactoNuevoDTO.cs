using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Data.DTOS.Contactos
{
    public class ContactoNuevoDTO
    {
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido")]
        public string Email { get; set; }
    }
}
