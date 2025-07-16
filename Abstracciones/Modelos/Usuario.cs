using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string PasswordHash { get; set; }
        public string Correo { get; set; }
    }
}