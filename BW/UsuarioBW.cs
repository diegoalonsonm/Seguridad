using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class UsuarioBW : IUsuarioBW
    {
        private IUsuarioDA _usuarioDA;

        public UsuarioBW(IUsuarioDA usuarioDA)
        {
            _usuarioDA = usuarioDA;
        }

        public async Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            return await _usuarioDA.ObtenerUsuario(usuario);
        }

        public async Task<Guid> RegistrarUsuario(Usuario usuario)
        {
            return await _usuarioDA.RegistrarUsuario(usuario);
        }
    }
}