using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Inner
{
    public class InnerEstadoCuenta
    {
        public string NombreCliente { get; set; }
        public int IdCliente { get; set; }
        public string IdContrato { get; set; }
        public int MontonLinea { get; set; }
        public int SaldoalCorte { get; set; }
        public int CreditoDisponible { get; set; }
        public int SaldoInicial { get; set; }
        public int SaldoFinal { get; set; }
    }
}
