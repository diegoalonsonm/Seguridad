using Abstracciones.Modelos;

namespace Abstracciones.DA
{
    public interface IUsuarioDA
    {
        Task<Usuario> ObtenerUsuario(Usuario usuario);

        Task<IEnumerable<Perfil>> ObtenerPerfilesPorUsuario(Usuario usuario);

        Task<Guid> RegistrarUsuario(Usuario usuario);

        Task<bool> ResetearPassword(ResetPassword resetPassword);
    }
}