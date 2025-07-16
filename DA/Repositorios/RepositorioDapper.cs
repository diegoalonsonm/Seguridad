using Abstracciones.DA;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _conexion;

        public RepositorioDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _conexion = new SqlConnection(_configuration.GetConnectionString("Seguridad"));
        }

        SqlConnection IRepositorioDapper.ObtenerRepositorioDapper()
        {
            return _conexion;
        }
    }
}
