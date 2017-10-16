using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InnerSaldosPorCliente
    {
        public int IdCredito { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal MontoDispuesto { get; set; }
        public decimal MontoaPagar { get; set; }
        public decimal SaldoalDia { get; set; }
        public string Divisa { get; set; }
        public string Estado { get; set; }
    }
}
