using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Inner
{
    public class InnerSaldosPorCliente
    {
        public int IdCredito { get; set; }
        public string FechaDesembolso { get; set; }
        public string FechaVencimiento { get; set; }
        public int MontoDispuesto { get; set; }
        public int MontoaPagar { get; set; }
        public int SaldoalDia { get; set; }
        public string Divisa { get; set; }
        public string Estado { get; set; }
    }
}
