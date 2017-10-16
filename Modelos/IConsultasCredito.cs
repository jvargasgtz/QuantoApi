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
        List<CRE_CREDITO> CreditosPorReferencia(EntidadCreditoBase EntidadCredito);
        decimal ConsultasCreCreditoConcepto(EntidadCreditoBase EntidadCredito);
        int ObtenerIdPersonaPorReferencia(EntidadCreditoBase EntidadCredito);
    }
}
