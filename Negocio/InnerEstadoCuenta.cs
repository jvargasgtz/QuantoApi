using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InnerEstadoCuenta
    {
        public decimal MontonLinea { get; set; }
        public decimal SaldoalCorte { get; set; }
        public decimal CreditoDisponible { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoFinal { get; set; }
    }
}
