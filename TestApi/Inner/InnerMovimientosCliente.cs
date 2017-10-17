using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Inner
{
    public class InnerMovimientosCliente
    {
        public int idCredito { get; set; }
        public string Divisa { get; set; }
        public string Fecha { get; set; }
        public int Capital { get; set; }
        public int Interes { get; set; }
        public int Mora { get; set; }
        public int Cargos { get; set; }
        public int Impuestos { get; set; }
        public int Total { get; set; }
    }
}
