using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Operacion;
using System.Globalization;

namespace Modelos
{
    public class ConsultasCreditos : IConsultasCredito
    {
        EsquemaBDDataContext esquema = new EsquemaBDDataContext();

        public List<CRE_CREDITO> ObtenerCreditosPorCliente(EntidadCreditoBase EntidadCredito)
        {
            var idPersona = ObtenerIdPersonaPorReferencia(EntidadCredito);

            var creditos = from d in esquema.CRE_CREDITO
                           where d.idPersonaSolicitante == idPersona
                           && d.idEstadoCredito == (int)constantes.EstadocreditoActivo && d.idEstado == (int)constantes.EstadoActivo
                           select d;

            return creditos.ToList();
        }

        public List<CRE_CREDITO> ObtenerCreditosPorCliente(EntidadCreditoBase EntidadCredito, DateTime FechaInicio, DateTime FechaFin)
        {
            var idPersona = ObtenerIdPersonaPorReferencia(EntidadCredito);

            var creditos = from d in esquema.CRE_CREDITO
                           where d.idPersonaSolicitante == idPersona
                           && d.idEstadoCredito == (int)constantes.EstadocreditoActivo
                           && d.idEstado == (int)constantes.EstadoActivo
                           && FechaInicio > FechaFin
                           select d;

            return creditos.ToList();
        }

        public decimal ConsultasCreCreditoConcepto(EntidadCreditoBase EntidadCredito)
        {
            var MontoDispuesto = (from c in esquema.CRE_CREDITO_CONCEPTO
                                  where c.IdCredito == EntidadCredito.credito
                                  && c.IdEstado == (int)constantes.EstadoActivo && c.FechaFin <= DateTime.Today.AddHours(-5)
                                  && c.IdConcepto != (int)constantes.ConceptoIva
                                  select c.Saldo + c.Impuesto).Sum();

            if (MontoDispuesto.Equals(null))
            {
                return (int)constantes.RegresarCero;
            }
            else { return MontoDispuesto.Value; }
        }

        public decimal ConsultasMontoAPagar(EntidadCreditoBase EntidadCredito)
        {
            var MontoDispuesto = (from c in esquema.CRE_CREDITO_CONCEPTO
                                  where c.IdCredito == EntidadCredito.credito
                                  && c.IdEstado == (int)constantes.EstadoActivo
                                  && c.IdConcepto != (int)constantes.ConceptoIva
                                  select c.Saldo + c.Impuesto).Sum();

            if (MontoDispuesto.Equals(null))
            {
                return (int)constantes.RegresarCero;
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
                            where m.IdConcepto == (int)constantes.conceptoprincipal && m.IdCredito == Idcredito
                            && m.IdEstado == (int)constantes.EstadoActivo
                            select m.Saldo;

            if (Dispuesto.FirstOrDefault().Equals(null))
            {
                return (int)constantes.RegresarCero;
            }
            else { return Dispuesto.FirstOrDefault().Value; }
        }

        public string ObtenerDivisa(int Idcredito)
        {
            var iddivisa = from d in esquema.CRE_CREDITO
                           where d.idCredito == Idcredito
                           select d.idDivisa;
            
            var descripciondivisa = from d in esquema.PLD_COD_DIVISA
                                    where d.IdDivisa == iddivisa.FirstOrDefault().Value
                                    select d.Descripcion;

            if (descripciondivisa.Any())
            {
                return descripciondivisa.ToList().FirstOrDefault();
            }
            else { return ""; }
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
    }
}
