using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IRepositorioDapper
    {
        SqlConnection ObtenerRepositorioDapper();
    }
}