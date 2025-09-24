using Abstracciones.API;
using Abstracciones.BC;
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
        private IAutenticacionBC _autenticacionBC;

        public AutenticacionController(IAutenticacionBW autenticacionBW, IAutenticacionBC autenticacionBC)
        {
            _autenticacionBW = autenticacionBW;
            _autenticacionBC = autenticacionBC;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> PostAsync([FromBody] Login login)
        {
            return Ok(await _autenticacionBW.LoginAsync(login));
        }

        [AllowAnonymous]
        [HttpPost("ResetearPassword")]
        public async Task<IActionResult> ResetearPasswordAsync([FromBody] ResetPassword resetPassword)
        {
            return Ok(await _autenticacionBC.ResetearPasswordAsync(resetPassword));
        }
    }
}