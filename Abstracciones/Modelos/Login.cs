using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Login
    {
        [Required]
        public Guid IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        public Guid IdServicio { get; set; } 
    }
}