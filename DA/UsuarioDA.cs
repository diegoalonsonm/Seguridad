using Abstracciones.DA;
using Abstracciones.Modelos;
using Dapper;
using Helpers;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class UsuarioDA : IUsuarioDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _conexion;

        public UsuarioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _conexion = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<Perfil>> ObtenerPerfilesPorUsuario(Usuario usuario)
        {
            string sqlQuery = @"[ObtenerPerfilesPorUsuario]";
            var consulta = await _conexion.QueryAsync<Perfil>(sqlQuery, new
            {
                correo = usuario.correo,
                nombre = usuario.nombre,
            });

            return consulta;
        }

        public async Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            string sqlQuery = @"[ObtenerUsuario]";
            var consulta = await _conexion.QueryAsync<Usuario>(sqlQuery, new
            {
                correo = usuario.correo,
                nombre = usuario.nombre
            });

            return consulta.FirstOrDefault();
        }

        public async Task<Guid> RegistrarUsuario(Usuario usuario)
        {
            string sql = @"[agregarUsuario]";
            Guid consulta = await _conexion.ExecuteScalarAsync<Guid>(sql, new
            {
                nombre = usuario.nombre,
                passwordHash = usuario.passwordHash,
                correo = usuario.correo
            });

            return consulta;
        }
    }
}