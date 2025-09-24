using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface IUsuarioBW
    {
        Task<Guid> RegistrarUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuario(Usuario usuario);
        Task<bool> ResetearPassword(ResetPassword resetPassword);
    }
}