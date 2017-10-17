using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TestApi.Inner;
using TestApi.Procesos;
using TestApi.Request;
using TestApi.Response;

namespace QuantoAPI.Controllers
{
    public class QuantoController : ApiController
    {
        [HttpPost]
        public JsonResult<List<ResponseCredito>> operacionesactivas(RequestActivo request)
        {
            OperacionesActivas OperacionBase = new OperacionesActivas();
            List<ResponseCredito> ResultantesActivas = OperacionBase.Procesar(request);

            return Json(ResultantesActivas);
        }

        [HttpPost]
        public JsonResult<List<ResponseEstadoCuenta>> EstadodeCuentaPorCliente(RequestEstadoCuenta request)
        {
            EstadoCuentaBase EstadoCuenta = new EstadoCuentaBase();
            List<ResponseEstadoCuenta> ResultanteCuenta = EstadoCuenta.Proceso(request);

            return Json(ResultanteCuenta);
        }

        [HttpPost]
        public JsonResult<List<ResponseSaldosPorCliente>> SaldosPorCliente(RequestSaldosPorCliente request)
        {
            SaldosBase Saldos = new SaldosBase();
            List<ResponseSaldosPorCliente> ListSaldos = Saldos.Proceso(request);

            return Json(ListSaldos);
        }

        [HttpPost]
        public JsonResult<List<ResponseMovimientosCliente>> MovimientosPorCliente(RequestMovimientosCliente request)
        {
            MovimientosBase Movimiento = new MovimientosBase();
            List<ResponseMovimientosCliente> Movimientos = Movimiento.Proceso(request);

            return Json(Movimientos);
        }

        [HttpPost]
        public JsonResult<InnerCliente> ObtenerCliente(RequestCliente request)
        {
            ClienteBase Clientes = new ClienteBase();

            InnerCliente intocliente = Clientes.Proceso(request);

            return Json(intocliente);
        }
    }
}