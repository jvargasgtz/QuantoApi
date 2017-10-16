using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InnerActivo
    {
        public int Nocredito { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal MontoDispuesto { get; set; }
        public decimal MontoAPagar { get; set; }
        public decimal SaldoAlDia { get; set; }
        public string Divisa { get; set; }
    }
}
