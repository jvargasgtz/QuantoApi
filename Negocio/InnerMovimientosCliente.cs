using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InnerMovimientosCliente
    {
        public int idCredito { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Mora { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Cargos { get; set; }
        public decimal Total { get; set; }
        public string Divisa { get; set; }
        public DateTime FechaDePago { get; set; }
    }
}
