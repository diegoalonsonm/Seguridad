using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BC
{
    public interface IAutenticacionBC
    {
        Task<Token> LoginAsync(Login login);
        Task<bool> ResetearPasswordAsync(ResetPassword resetPassword);
    }
}