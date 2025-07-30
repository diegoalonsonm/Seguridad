using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entidades
{
    public class Usuario
    {
        public Guid idUsuario { get; set; }
        public string nombre { get; set; }
        public string passwordHash { get; set; }
        public string correo { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public Guid? usuarioCrea { get; set; }
        public Guid? usuarioModifica { get; set; }
    }
}