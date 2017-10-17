using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ResponseEstadoCuenta
    {
        public ResponseEstadoCuenta()
        {
            this.EstadosCuentas = new List<InnerEstadoCuenta>();
        }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Contrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<InnerEstadoCuenta> EstadosCuentas { get; set; }
    }
}
