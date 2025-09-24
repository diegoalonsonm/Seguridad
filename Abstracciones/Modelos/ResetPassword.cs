using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress]
        public string correo { get; set; }

        [Required]
        public string nuevoPasswordHash { get; set; }
    }
}