using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public interface IConsultasCredito
    {
        List<CRE_CREDITO> ObtenerCreditosPorCliente(EntidadCreditoBase EntidadCredito);
        List<CRE_CREDITO> ObtenerCreditosPorCliente(EntidadCreditoBase EntidadCredito, DateTime FechaInicio, DateTime FechaFin);
        decimal ConsultasCreCreditoConcepto(EntidadCreditoBase EntidadCredito);
        int ObtenerIdPersonaPorReferencia(EntidadCreditoBase EntidadCredito);
        decimal ConsultasMontoAPagar(EntidadCreditoBase EntidadCredito);
        string ObtenerDivisa(int Idcredito);
        string ObtenerEstado(int credito);
    }
}
