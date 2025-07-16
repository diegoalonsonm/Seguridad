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
            var consulta = await _conexion.QueryAsync<Abstracciones.Entidades.Perfil>(sqlQuery, new
            {
                correo = usuario.Correo,
                nombre = usuario.Nombre,
            });

            return Convertidor.ConvertirLista<Abstracciones.Entidades.Perfil, Abstracciones.Modelos.Perfil>(consulta);
        }

        public async Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            string sqlQuery = @"[ObtenerUsuario]";
            var consulta = await _conexion.QueryAsync<Abstracciones.Entidades.Usuario>(sqlQuery, new
            {
                correo = usuario.Correo,
                nombre = usuario.Nombre
            });

            return Convertidor.Convertir<Abstracciones.Entidades.Usuario, Abstracciones.Modelos.Usuario>(consulta.FirstOrDefault());
        }

        public async Task<Guid> RegistrarUsuario(Usuario usuario)
        {
            string sql = @"[agregarUsuario]";
            Guid consulta = await _conexion.ExecuteScalarAsync<Guid>(sql, new
            {
                nombre = usuario.Nombre,
                passwordHash = usuario.PasswordHash,
                correo = usuario.Correo
            });

            return consulta;
        }
    }
}