using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Modelos
{
    public interface IEstadodeCuenta
    {
        decimal ObtenerMontoLinea(EntidadCreditoBase EntidadCredito);
        List<CRE_CREDITO> MinistracionesPorLinea(EntidadCreditoBase EntidadCredito);
        string ObtenerNombreCliente(EntidadCreditoBase EntidadCredito);
        List<CRE_CREDITO> ObtenerEstadoDeCuenta(EntidadCreditoBase EntidadCredito);
        string ObtenerContrato(EntidadCreditoBase entidadCredito);
        int ObtenerLineas(EntidadCreditoBase EntidadCredito);
        string ObtenerEstado(int credito);
        decimal CreditoDisponible(int solicitante);
        decimal SaldoInicialConFecha(int idcredito, DateTime fechainicio, DateTime fechafin);
        decimal SaldoFinalConFecha(int idcredito, DateTime fechainicio, DateTime fechafin);
        decimal saldoalcorte(int idcredito);
    }
}
