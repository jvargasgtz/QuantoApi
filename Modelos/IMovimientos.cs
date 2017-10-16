using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Modelos
{
    public interface IMovimientos
    {
        List<int> ObtenerMovimientosAbonos(List<CRE_CREDITO> CREDITOS);
        decimal ObtenerDatosCrecredito(int credito, int concepto);
        DateTime ObtenerFechaPago(int credito);
    }
}
