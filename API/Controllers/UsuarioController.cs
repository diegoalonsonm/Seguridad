using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller, IUsuarioController
    {
        private IUsuarioBW _usuarioBW;

        public UsuarioController(IUsuarioBW usuarioBW)
        {
            _usuarioBW = usuarioBW;
        }

        [Authorize(Roles = "2")]
        [HttpPost("ObtenerUsuario")]
        public async Task<IActionResult> ObtenerUsuario([FromBody] Usuario usuario)
        {
            return Ok(await _usuarioBW.ObtenerUsuario(usuario));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Usuario usuario)
        {
            return Ok(await _usuarioBW.RegistrarUsuario(usuario));
        }
    }
}