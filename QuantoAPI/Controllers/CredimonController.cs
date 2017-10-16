using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Negocio;
using Modelos;

namespace QuantoAPI.Controllers
{
    public class CredimonController : ApiController
    {
        [HttpPost]
        public JsonResult<List<ResponseCredito>> operacionesactivas(Negocio.RequestActivo request)
        {
            OperacionesActivas OperacionBase = new OperacionesActivas();
            List<ResponseCredito> ResultantesActivas = OperacionBase.Procesar(request);

            return Json(ResultantesActivas);
        }

        [HttpPost]
        public JsonResult<List<ResponseEstadoCuenta>> EstadodeCuentaPorCliente(RequestEstadoCuenta request)
        {
            IConsultasCredito consutasCredito = new ConsultasCreditos();
            IEstadodeCuenta consultasEstadoDeCuenta = new ConsultasEstadoDeCuenta();
            IEnvioEstadoCuenta enviarestadocuenta = new EnviarEstadoDeCuenta();
            EstadoCuentaBase EstadoCuenta = new EstadoCuentaBase(consutasCredito , consultasEstadoDeCuenta, enviarestadocuenta);
            List<ResponseEstadoCuenta> ResultanteCuenta = EstadoCuenta.Proceso(request);
            return Json(ResultanteCuenta);
        }

        [HttpPost]
        public JsonResult<List<ResponseSaldosPorCliente>> SaldosPorCliente(RequestSaldosPorCliente request)
        {
            IConsultasCredito consutasCredito = new ConsultasCreditos();
            IEstadodeCuenta consultasEstadoDeCuenta = new ConsultasEstadoDeCuenta();
            Iconsultassaldos consultassaldos = new ConsultasSaldos();

            Saldos Saldos = new Saldos(consutasCredito, consultasEstadoDeCuenta, consultassaldos);
            List<ResponseSaldosPorCliente> ListSaldos = Saldos.Proceso(request);

            return Json(ListSaldos);
        }

        [HttpPost]
        public JsonResult<List<ResponseMovimientosCliente>> MovimientosPorCliente(RequestMovimientosCliente request)
        {
            IConsultasCredito consutasCredito = new ConsultasCreditos();
            IEstadodeCuenta consultasEstadoDeCuenta = new ConsultasEstadoDeCuenta();
            Iconsultassaldos consultassaldos = new ConsultasSaldos();
            IMovimientos consultamovimientos = new ConsultasMovimientos();

            MovimientosBase Movimiento = new MovimientosBase(consutasCredito, consultasEstadoDeCuenta, consultassaldos, consultamovimientos);
            List<ResponseMovimientosCliente> Movimientos = Movimiento.Proceso(request);

            return Json(Movimientos);
        }

        [HttpPost]
        public JsonResult<InnerCliente> ObtenerCliente(RequestCliente request)
        {
            IConsultasCredito consultasCredito = new ConsultasCreditos();
            IEstadodeCuenta consultasEstadoDeCuenta = new ConsultasEstadoDeCuenta();
            Icliente cliente = new consultascliente();
            ClienteBase Clientes = new ClienteBase(cliente, consultasCredito, consultasEstadoDeCuenta);

            InnerCliente intocliente = Clientes.Proceso(request);

            return Json(intocliente);
        }
    }
}