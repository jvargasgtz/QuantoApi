using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Inner
{
    public class InnerActivo
    {
        public int idcliente { get; set; }
        public int Nocredito { get; set; }
        public string FechaDesembolso { get; set; }
        public string FechaVencimiento { get; set; }
        public int MontoDispuesto { get; set; }
        public int MontoAPagar { get; set; }
        public int SaldoAlDia { get; set; }
        public string Divisa { get; set; }
    }
}
