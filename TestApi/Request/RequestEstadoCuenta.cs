using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Request
{
    public class RequestEstadoCuenta
    {
        public string username { get; set; }
        public string password { get; set; }
        public int idCliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
