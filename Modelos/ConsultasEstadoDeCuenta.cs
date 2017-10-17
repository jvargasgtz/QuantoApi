using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Operacion;

namespace Modelos
{
    public class ConsultasEstadoDeCuenta : IEstadodeCuenta
    {
        public ConsultasEstadoDeCuenta()
        { }

        EsquemaBDDataContext esquema = new EsquemaBDDataContext();

        public List<CRE_CREDITO> ObtenerEstadoDeCuenta(EntidadCreditoBase EntidadCredito)
        {
            ConsultasCreditos consultascredito = new ConsultasCreditos();
            var idPersona = consultascredito.ObtenerIdPersonaPorReferencia(EntidadCredito);

            EntidadCredito.idpersona = idPersona;

            //obtiene linea
            var Linea = ObtenerLineas(EntidadCredito);

            EntidadCredito.NLinea = Linea;

            //obtiene ministraciones
            var Ministraciones = MinistracionesPorLinea(EntidadCredito);

            List<decimal> saldosalcorte = new List<decimal>();

            foreach (var item in Ministraciones)
            {
                saldosalcorte.Add(saldoalcorte(item.idCredito));
            }

            return Ministraciones;
        }

        public string ObtenerNombreCliente(EntidadCreditoBase EntidadCredito)
        {
            ConsultasCreditos consultascredito = new ConsultasCreditos();
            var idPersona = consultascredito.ObtenerIdPersonaPorReferencia(EntidadCredito);

            var nombrecliente = from c in esquema.PLD_PERSONA
                                where c.idPersona == idPersona
                                select c.Nombre_Completo;

            return nombrecliente.FirstOrDefault();
        }

        public decimal ObtenerMontoLinea(EntidadCreditoBase EntidadCredito)
        {
            var lineas = from l in esquema.CRE_CREDITO
                         where l.idPersonaSolicitante == EntidadCredito.idpersona && l.idEstadoCredito == 4
                         && l.idTipoRegistro == (int)constantes.TipoRegistroLinea && l.idEstado == 1
                         select l;
            decimal Monto = 0;

            foreach (var item in lineas)
            {
                Monto = item.Monto.Value;
            }

            return Monto;
        }

        public int ObtenerLineas(EntidadCreditoBase EntidadCredito)
        {
            var NumeroLinea = from NL in esquema.CRE_CREDITO
                              where NL.idPersonaSolicitante == EntidadCredito.idpersona
                              && NL.idEstadoCredito == (int)constantes.CreditoAutorizado 
                              && NL.idTipoRegistro == (int)constantes.TipoRegistroLinea
                              && NL.idEstado == (int)constantes.EstadoActivo
                              select NL;
            int idlinea = 0;

            foreach (var item in NumeroLinea)
            {
                idlinea = item.idLinea.Value;
            }

            return idlinea;
        }

        public List<CRE_CREDITO> MinistracionesPorLinea(EntidadCreditoBase EntidadCredito)
        {
            var ListaMinistracion = from LM in esquema.CRE_CREDITO
                                    where LM.idLinea == EntidadCredito.NLinea && LM.idPersonaSolicitante == EntidadCredito.idpersona
                                    && LM.idEstadoCredito == (int)constantes.EstadocreditoActivo && LM.idEstado == (int)constantes.EstadoActivo
                                    select LM;

            return ListaMinistracion.ToList();
        }

        public decimal saldoalcorte(int idcredito)
        {
            int[] conceptos = { 2, 3 };
            var saldo = (from s in esquema.CRE_HISTORICO_SALDO
                         where s.idCredito == idcredito && s.idEstado == (int)constantes.EstadoActivo
                         && (conceptos.Contains(s.idConcepto.Value)) && s.idTipoMonto == (int)constantes.MontoTotal
                         select s.Saldo).Sum();

            if (saldo == null) { return (int)constantes.RegresarCero; }
            else
            { return saldo.Value; }
        }

        public string ObtenerContrato(EntidadCreditoBase EntidadCredito)
        {
            var contrato = from NL in esquema.CRE_CREDITO
                           where NL.idPersonaSolicitante == EntidadCredito.idpersona
                           && NL.idEstadoCredito == (int)constantes.EstadocreditoActivo
                           && NL.idEstado == (int)constantes.EstadoActivo
                           select NL.Contrato;
            return contrato.FirstOrDefault();
        }
        
        public decimal CreditoDisponible(int solicitante)
        {
            var disponible = from d in esquema.CRE_CREDITO
                             where d.idPersonaSolicitante == solicitante
                             && d.idEstadoCredito == (int)constantes.EstadocreditoActivo && d.idEstado == (int)constantes.EstadoActivo
                             select d.Monto.Value;

            return disponible.FirstOrDefault();
        }

        public decimal SaldoInicialConFecha(int idcredito, DateTime fechainicio,DateTime fechafin)
        {
            decimal saldoinicial = 0;
            List<int> tiposConceptos = new List<int> { 2, 3, 4 };

            foreach (var concepto in tiposConceptos)
            {
                var saldo = from si in esquema.CRE_CREDITO_CONCEPTO
                            where si.IdCredito == idcredito && si.FechaInicio >= fechainicio
                            && si.FechaInicio <= fechafin && si.IdConcepto == concepto
                            select si.Saldo;

                if (saldo.Any())
                {
                    saldoinicial += saldo.Sum().Value;
                }
            }

            return saldoinicial;
        }

        public decimal SaldoFinalConFecha(int idcredito, DateTime fechainicio, DateTime fechafin)
        {
            decimal saldofinal = 0;
            List<int> tiposConceptos = new List<int> { 2, 3, 4 };

            foreach (var concepto in tiposConceptos)
            {
                var saldos =  from si in esquema.CRE_CREDITO_CONCEPTO
                                  where si.IdCredito == idcredito && si.FechaFin >= fechainicio
                                  && si.FechaFin <= fechafin && si.IdConcepto == concepto 
                                  select si.Saldo;
                if (saldos.Any())
                {
                    saldofinal += saldos.Sum().Value;
                }
            }
            return saldofinal;
        }

    }
}
