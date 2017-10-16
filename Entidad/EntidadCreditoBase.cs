using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntidadCreditoBase
    {
        public int credito { get; set; }
        public DateTime fechadesembolso { get; set; }
        public DateTime fechavencimiento { get; set; }
        public int idpersona { get; set; }
        public string equivalencia { get; set; }
        public dynamic lsministraciones { get; set; }
        public int Idcliente { get; set; }
        public int NLinea { get; set; }
        public DataTable dtcreditos { get; set; }
        public string Nombre { get; set; }
        public string contrato { get; set; }
    }
}
