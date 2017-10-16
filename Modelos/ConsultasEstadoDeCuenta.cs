using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

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
                         && l.idTipoRegistro == 3 && l.idEstado == 1
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
                              && NL.idEstadoCredito == 4 && NL.idTipoRegistro == 3
                              && NL.idEstado == 1
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
                                    && LM.idEstadoCredito == 7 && LM.idEstado == 1
                                    select LM;

            return ListaMinistracion.ToList();
        }

        public decimal saldoalcorte(int idcredito)
        {
            int[] conceptos = { 2, 3 };
            var saldo = (from s in esquema.CRE_HISTORICO_SALDO
                         where s.idCredito == idcredito && s.idEstado == 1
                         && (conceptos.Contains(s.idConcepto.Value)) && s.idTipoMonto == 4
                         select s.Saldo).Sum();
            if (saldo == null) { return 0; }
            else
            { return saldo.Value; }
        }

        public string ObtenerContrato(EntidadCreditoBase EntidadCredito)
        {
            var contrato = from NL in esquema.CRE_CREDITO
                           where NL.idPersonaSolicitante == EntidadCredito.idpersona
                           && NL.idEstadoCredito == 4 && NL.idTipoRegistro == 3
                           && NL.idEstado == 1
                           select NL.Contrato;
            return contrato.FirstOrDefault();
        }

        public string ObtenerEstado(int credito)
        {
            var listaestados = from e in esquema.CRE_CREDITO
                               join es in esquema.CRE_COD_ESTADO_CREDITO
                               on e.idEstadoCredito equals es.idEstado
                               where e.idCredito == credito
                               select es.Descripcion;

            return listaestados.FirstOrDefault();
        }

        public decimal CreditoDisponible(int solicitante)
        {
            var disponible = from d in esquema.CRE_CREDITO
                             where d.idPersonaSolicitante == solicitante
                             && d.idEstadoCredito == 7 && d.idEstado == 1
                             select d.Monto.Value;

            return disponible.FirstOrDefault();
        }

        public decimal SaldoInicialConFecha(int idcredito, DateTime fechainicio,DateTime fechafin)
        {
            var saldoinicial = (from si in esquema.CRE_CREDITO_CONCEPTO
                               where si.IdCredito == idcredito && si.FechaInicio >= fechainicio
                               && si.FechaInicio <= fechafin && si.IdConcepto == 2 &&
                               si.IdConcepto == 3 && si.IdConcepto == 4
                               select si.Saldo).Sum();

            if (saldoinicial.Equals(null))
            {
                return 0;
            }
            else { return saldoinicial.Value; }
            
        }

        public decimal SaldoFinalConFecha(int idcredito, DateTime fechainicio, DateTime fechafin)
        {
            var saldofinal = (from si in esquema.CRE_CREDITO_CONCEPTO
                                where si.IdCredito == idcredito && si.FechaFin >= fechainicio
                                && si.FechaFin <= fechafin && si.IdConcepto == 2 &&
                                si.IdConcepto == 3 && si.IdConcepto == 4
                                select si.Saldo).Sum();

            if (saldofinal.Equals(null))
            {
                return 0;
            }
            else { return saldofinal.Value; }
        }
    }
}
