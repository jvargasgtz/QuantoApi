using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Operacion;

namespace Modelos
{
    public class ConsultasCreditos : IConsultasCredito
    {
        EsquemaBDDataContext esquema = new EsquemaBDDataContext();

        public List<CRE_CREDITO> CreditosPorReferencia(EntidadCreditoBase EntidadCredito)
        {
            var idPersona = ObtenerIdPersonaPorReferencia(EntidadCredito);

            var creditos = from d in esquema.CRE_CREDITO
                           where d.idPersonaSolicitante == idPersona
                           && (d.idTipoRegistro == 4) && (d.idEstadoCredito == 7)
                           select d;

            return creditos.ToList();
        }

        public decimal ConsultasCreCreditoConcepto(EntidadCreditoBase EntidadCredito)
        {
            var MontoDispuesto = (from c in esquema.CRE_CREDITO_CONCEPTO
                                  where c.IdCredito == EntidadCredito.credito
                                  select c.Saldo).Sum();

            if (MontoDispuesto.Equals(null))
            {
                return 0;
            }
            else { return MontoDispuesto.Value; }
        }

        public int ObtenerIdPersonaPorReferencia(EntidadCreditoBase EntidadCredito)
        {
            var resultado = from c in esquema.PLD_PERSONA
                            where c.Equivalencia == EntidadCredito.equivalencia
                            select c.idPersona;
            return resultado.FirstOrDefault();
        }

        public decimal MontoDispuesto(int Idcredito)
        {
            var Dispuesto = from m in esquema.CRE_CREDITO_CONCEPTO
                            where m.IdConcepto == 2 && m.IdCredito == Idcredito
                            select m.Saldo;

            if (Dispuesto.FirstOrDefault().Equals(null))
            {
                return 0;
            }
            else { return Dispuesto.FirstOrDefault().Value; }
        }
    }
}
