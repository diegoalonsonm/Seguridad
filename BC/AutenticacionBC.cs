using Abstracciones.BC;
using Abstracciones.DA;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BC
{
    public class AutenticacionBC : IAutenticacionBC
    {
        public IConfiguration _config;
        public IUsuarioDA _usuarioDA;

        public AutenticacionBC(IConfiguration config, IUsuarioDA usuarioDA)
        {
            _config = config;
            _usuarioDA = usuarioDA;
        }

        public async Task<Token> LoginAsync(Login login)
        {
            Token respuestaToken = new Token()
            {
                AccessToken = string.Empty,
                ValidacionExitosa = false
            };

            bool resultadoVerificacionCredenciales = await VerificarLoginAsync(login);

            if(!resultadoVerificacionCredenciales)
            {
                return respuestaToken;
            }

            TokenConfig tokenConfig = _config.GetSection("Token").Get<TokenConfig>();
            JwtSecurityToken token = await GenerarTokenJWT(login, tokenConfig);
            
            respuestaToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            respuestaToken.ValidacionExitosa = true;

            return respuestaToken;
        }

        private async Task<bool> VerificarLoginAsync(Login login)
        {
            Usuario usuario = await _usuarioDA.ObtenerUsuario(new Usuario
            {
                Nombre = login.Nombre,
                Correo = login.Correo
            });
            return (login != null && login.PasswordHash == usuario.PasswordHash);
        }

        private async Task<JwtSecurityToken> GenerarTokenJWT(Login login, TokenConfig tokenConfig)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.key));
            List<Claim> claims = await GeneralClaims(login);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                tokenConfig.Issuer, 
                tokenConfig.Audience,
                claims, 
                expires: DateTime.Now.AddMinutes(tokenConfig.ExpiresIn),
                signingCredentials: credentials
            );

            return token;
        }

        private async Task<List<Claim>> GeneralClaims(Login login)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("usuario", login.Nombre));
            claims.Add(new Claim("servicio", login.IdServicio.ToString()));

            IEnumerable<Perfil> perfiles = await ObtenerPerfiles(login);

            foreach (Perfil perfil in perfiles)
            {
                claims.Add(new Claim(ClaimTypes.Role, perfil.IdPerfil.ToString()));
            }

            return claims;
        }

        private async Task<IEnumerable<Perfil>> ObtenerPerfiles(Login login)
        {
            return await _usuarioDA.ObtenerPerfilesPorUsuario(new Usuario
            {
                IdUsuario = login.IdUsuario,
                Nombre = login.Nombre,
                PasswordHash = login.PasswordHash,
                Correo = login.Correo
            });
        }
    }
}