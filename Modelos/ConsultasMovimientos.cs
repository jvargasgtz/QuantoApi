using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Modelos;

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

            //var abonos = new List<CRE_CREDITO_CONCEPTO>();
            //foreach (var conceptos in CREDITOS)
            //{
            //    abonos = (from a in esquema.CRE_CREDITO_CONCEPTO
            //                 where a.IdCredito == conceptos.idCredito
            //                 select a).ToList();
            //}

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
                return 0;
            }
        }

        public DateTime ObtenerFechaPago(int idcredito)
        {
            var fecha = from f in esquema.CRE_HISTORICO_SALDO
                        where f.idCredito == idcredito && f.idConcepto == 2 && f.idTipoMonto == 4
                        select f.Fecha.Value;

            return fecha.FirstOrDefault();
        }
    }
}
