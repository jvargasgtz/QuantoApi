using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Modelos
{
    public interface Icliente
    {
        List<string> ObtenerInformacionCliente(EntidadCreditoBase entidad);
        string ObtenerContratoCliente(EntidadCreditoBase entidad);
        DateTime ObtenerFechaVencimiento(EntidadCreditoBase entidad);
    }
}
