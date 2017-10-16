using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Modelos;

namespace Modelos
{
    public class ConsultasSaldos : Iconsultassaldos
    {
        public void ConsultaSaldos()
        { }

        EsquemaBDDataContext esquema = new EsquemaBDDataContext();

        public decimal ObtenerSaldoAlVencimiento(EntidadCreditoBase entidad,DateTime FechaInicio, DateTime FechaFin)
        {
            decimal saldoprincipal = 0;

            List<int> tiposConceptos = new List<int> { 2, 3, 4, 6 };

            foreach (var concepto in tiposConceptos)
            {
                var saldoPorConcepto = from sp in esquema.CRE_CREDITO_CONCEPTO
                                       where sp.IdCredito == entidad.credito && sp.IdConcepto == concepto
                                       && sp.FechaFin >= FechaInicio && sp.FechaFin <= FechaFin
                                       select sp.Saldo;

                if (saldoPorConcepto.Any())
                {
                    saldoprincipal += saldoPorConcepto.Sum().Value;
                }


                if (concepto != 2)
                {
                    var saldoprincipalconcepto = from sp in esquema.CRE_CREDITO_CONCEPTO
                                                 where sp.IdCredito == entidad.credito && sp.IdConcepto == concepto
                                                 && sp.FechaFin >= FechaInicio && sp.FechaFin <= FechaFin
                                                 select sp.Impuesto;
                    if (saldoPorConcepto.Any())
                    {
                        saldoprincipal += saldoprincipalconcepto.Sum().Value;
                    }
                }

            }
            
            return saldoprincipal;
        }
    }
}
