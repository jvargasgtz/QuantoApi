using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Inner;

namespace TestApi.Response
{
    public class ResponseSaldosPorCliente
    {
        public int IdCliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public List<InnerSaldosPorCliente> Saldos { get; set; }
    }
}
