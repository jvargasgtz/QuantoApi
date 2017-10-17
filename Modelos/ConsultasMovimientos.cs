using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Modelos;
using Operacion;

namespace Modelos
{
    public class ConsultasMovimientos : IMovimientos
    {
        public ConsultasMovimientos()
        { }

        EsquemaBDDataContext esquema = new EsquemaBDDataContext();

        public List<int> ObtenerMovimientosAbonos(List<CRE_CREDITO> CREDITOS)
        {
            List<int> Ncreditos = new List<int>();
            foreach (var conceptos in CREDITOS)
            {
               var numerosc = from a in esquema.CRE_CREDITO_CONCEPTO
                           where a.IdCredito == conceptos.idCredito
                           select a.IdCredito.Value;

                Ncreditos.Add(numerosc.FirstOrDefault());
            }
            return Ncreditos;
        }

        public decimal ObtenerDatosCrecredito(int credito, int concepto)
        {
            var DatoCreCredito = from a in esquema.CRE_CREDITO_CONCEPTO
                                  where a.IdCredito == credito && a.IdConcepto == concepto
                                  select a.Saldo.Value;
            if (DatoCreCredito.Any())
            {
                return DatoCreCredito.FirstOrDefault();
            }
            else
            {
                return (int)constantes.RegresarCero;
            }
        }

        public DateTime ObtenerFechaPago(int idcredito)
        {
            var fecha = from f in esquema.CRE_HISTORICO_SALDO
                        where f.idCredito == idcredito && f.idConcepto == (int)constantes.ConceptoCapital && f.idTipoMonto == (int)constantes.MontoTotal
                        select f.Fecha.Value;

            return fecha.FirstOrDefault();
        }
    }
}
