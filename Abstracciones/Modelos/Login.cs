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
        public Guid idUsuario { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string passwordHash { get; set; }

        [Required]
        [EmailAddress]
        public string correo { get; set; }
        public Guid IdServicio { get; set; } 
    }
}