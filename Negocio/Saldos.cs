﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Entidad;

namespace Negocio
{
    public class Saldos
    {
        IEstadodeCuenta _consultasEstadoDeCuenta;
        IConsultasCredito _consultasCredito;
        Iconsultassaldos _consultassaldos;

        public Saldos(IConsultasCredito consutasCredito, IEstadodeCuenta consultasEstadodeCuenta, Iconsultassaldos consultassaldos)
        {
            this._consultasEstadoDeCuenta = consultasEstadodeCuenta;
            this._consultasCredito = consutasCredito;
            this._consultassaldos = consultassaldos;
        }

        public List<ResponseSaldosPorCliente> Proceso(RequestSaldosPorCliente request)
        {
            EntidadCreditoBase entidadbase = new EntidadCreditoBase();
            List<ResponseSaldosPorCliente> responseList = new List<ResponseSaldosPorCliente>();

            ResponseSaldosPorCliente Listresponse = new ResponseSaldosPorCliente();

            entidadbase.equivalencia = request.Equivalencia;

            entidadbase.idpersona = _consultasCredito.ObtenerIdPersonaPorReferencia(entidadbase);

            entidadbase.NLinea = _consultasEstadoDeCuenta.ObtenerLineas(entidadbase);

            var ministraciones = _consultasEstadoDeCuenta.MinistracionesPorLinea(entidadbase);

            Listresponse.Saldos = new List<InnerSaldosPorCliente>();

            foreach (var item in ministraciones)
            {
                InnerSaldosPorCliente innerResponse = new InnerSaldosPorCliente();
                entidadbase.credito = item.idCredito;
                innerResponse.IdCredito = item.idCredito;
                innerResponse.FechaDesembolso = item.FechaDesembolso.Value;
                innerResponse.FechaVencimiento = item.FechaVencimiento.Value;
                innerResponse.MontoDispuesto = item.Monto.Value;
                innerResponse.MontoaPagar = _consultassaldos.ObtenerSaldoAlVencimiento(entidadbase, request.FechaInicio, request.FechaFin);
                innerResponse.SaldoalDia = _consultasEstadoDeCuenta.saldoalcorte(item.idCredito);
                innerResponse.Divisa = "PESOS";
                innerResponse.Estado = _consultasEstadoDeCuenta.ObtenerEstado(item.idCredito);
                Listresponse.Saldos.Add(innerResponse);
            }

            Listresponse.Equivalencia = request.Equivalencia;
            Listresponse.FechaInicio = request.FechaInicio;
            Listresponse.FechaFin = request.FechaFin;

            responseList.Add(Listresponse);

            return responseList;
        }
    }
}
