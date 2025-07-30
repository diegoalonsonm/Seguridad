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
    public class AutenticacionController : Controller, IAutenticacionController
    {
        private IAutenticacionBW _autenticacionBW;

        public AutenticacionController(IAutenticacionBW autenticacionBW)
        {
            _autenticacionBW = autenticacionBW;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> PostAsync([FromBody] Login login)
        {
            return Ok(await _autenticacionBW.LoginAsync(login));
        }
    }
}