using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class EstadoCuentaBase
    {
        IEstadodeCuenta _consultasEstadoDeCuenta;
        IConsultasCredito _consultasCredito;
        IEnvioEstadoCuenta _envioestadocuenta;
        public EstadoCuentaBase(IConsultasCredito consutasCredito,IEstadodeCuenta consultasEstadodeCuenta, IEnvioEstadoCuenta enviarestadocuenta)
        {
            this._consultasEstadoDeCuenta = consultasEstadodeCuenta;
            this._consultasCredito = consutasCredito;
            this._envioestadocuenta = enviarestadocuenta;
        }
        public List<ResponseEstadoCuenta> Proceso(RequestEstadoCuenta request)
        {
            List<ResponseEstadoCuenta> responseList = new List<ResponseEstadoCuenta>();
            EntidadCreditoBase entidadCredito = new EntidadCreditoBase();
            ResponseEstadoCuenta Listresponse = new ResponseEstadoCuenta();
            entidadCredito.equivalencia = request.equivalencia;

            entidadCredito.Idcliente = _consultasCredito.ObtenerIdPersonaPorReferencia(entidadCredito);

            var EstadoDecuenta = _consultasEstadoDeCuenta.ObtenerEstadoDeCuenta(entidadCredito);
            entidadCredito.Nombre = _consultasEstadoDeCuenta.ObtenerNombreCliente(entidadCredito);
            entidadCredito.contrato = _consultasEstadoDeCuenta.ObtenerContrato(entidadCredito);

            foreach (var item in EstadoDecuenta)
            {
                InnerEstadoCuenta innerResponse = new InnerEstadoCuenta();
                innerResponse.MontonLinea = _consultasEstadoDeCuenta.ObtenerMontoLinea(entidadCredito);
                innerResponse.SaldoalCorte = _consultasEstadoDeCuenta.saldoalcorte(item.idCredito);
                innerResponse.CreditoDisponible = _consultasEstadoDeCuenta.CreditoDisponible(entidadCredito.Idcliente);
                innerResponse.SaldoInicial = _consultasEstadoDeCuenta.SaldoInicialConFecha(item.idCredito, request.FechaInicio, request.FechaFin);
                innerResponse.SaldoFinal = _consultasEstadoDeCuenta.SaldoFinalConFecha(item.idCredito, request.FechaInicio, request.FechaFin);

                Listresponse.EstadosCuentas.Add(innerResponse);
            }

            Listresponse.IdCliente = entidadCredito.Idcliente;
            Listresponse.NombreCliente = entidadCredito.Nombre;
            Listresponse.Contrato = entidadCredito.contrato;
            Listresponse.FechaInicio = request.FechaInicio;
            Listresponse.FechaFin = request.FechaFin;

            responseList.Add(Listresponse);

            entidadCredito.dtcreditos = new DataTable();
            entidadCredito.dtcreditos.Columns.Add("Monto En Linea");
            entidadCredito.dtcreditos.Columns.Add("Saldo Al Corte");
            entidadCredito.dtcreditos.Columns.Add("Credito Disponible");
            entidadCredito.dtcreditos.Columns.Add("Saldo Inicial");
            entidadCredito.dtcreditos.Columns.Add("Saldo Final");

            foreach (var item in Listresponse.EstadosCuentas)
            {
                entidadCredito.dtcreditos.Rows.Add
                (
                    item.MontonLinea,
                    item.SaldoalCorte,
                    item.CreditoDisponible,
                    item.SaldoInicial,
                    item.SaldoFinal
                );
            }

            _envioestadocuenta.EnviarEstadoCuentaPorCliente(entidadCredito);

            return responseList;
        }
    }
}
