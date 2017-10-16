using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ResponseSaldosPorCliente
    {
        public string Equivalencia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<InnerSaldosPorCliente> Saldos { get; set; }
    }
}
