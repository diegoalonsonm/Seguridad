using Abstracciones.BC;
using Abstracciones.BW;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class AutenticacionBW : IAutenticacionBW
    {
        private IAutenticacionBC _autenticacionBC;

        public AutenticacionBW(IAutenticacionBC autenticacionBC)
        {
            _autenticacionBC = autenticacionBC;
        }

        public async Task<Token> LoginAsync(Login login)
        {
            return await _autenticacionBC.LoginAsync(login);
        }
    }
}