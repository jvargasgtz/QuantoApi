using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Inner;

namespace TestApi.Response
{
    public class ResponseEstadoCuenta
    {
        public int Cliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public List<InnerEstadoCuenta> EstadosCuentas { get; set; }
    }
}
