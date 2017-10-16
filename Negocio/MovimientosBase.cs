using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Modelos;

namespace Negocio
{
    public class MovimientosBase
    {
        IEstadodeCuenta _consultasEstadoDeCuenta;
        IConsultasCredito _consultasCredito;
        Iconsultassaldos _consultassaldos;
        IMovimientos _consultasmovimientos;

        public MovimientosBase(IConsultasCredito consutasCredito, IEstadodeCuenta consultasEstadodeCuenta, Iconsultassaldos consultassaldos, IMovimientos consultamovimientos)
        {
            this._consultasEstadoDeCuenta = consultasEstadodeCuenta;
            this._consultasCredito = consutasCredito;
            this._consultassaldos = consultassaldos;
            this._consultasmovimientos = consultamovimientos;
        }

        public List<ResponseMovimientosCliente> Proceso(RequestMovimientosCliente request)
        {
            EntidadCreditoBase entidad = new EntidadCreditoBase();

            List<ResponseMovimientosCliente> responseList = new List<ResponseMovimientosCliente>();

            ResponseMovimientosCliente Listresponse = new ResponseMovimientosCliente();

            Listresponse.Movimientos = new List<InnerMovimientosCliente>();

            entidad.equivalencia = request.equivalencia;

            entidad.idpersona = _consultasCredito.ObtenerIdPersonaPorReferencia(entidad);

            entidad.NLinea = _consultasEstadoDeCuenta.ObtenerLineas(entidad);

            var ministraciones = _consultasEstadoDeCuenta.MinistracionesPorLinea(entidad);

            var listaconceptos = _consultasmovimientos.ObtenerMovimientosAbonos(ministraciones);

            foreach (var item in listaconceptos)
            {
                InnerMovimientosCliente innerResponse = new InnerMovimientosCliente();
                entidad.credito = item;

                innerResponse.idCredito = item;
                innerResponse.Capital = _consultasmovimientos.ObtenerDatosCrecredito(item, 2);
                innerResponse.Interes = _consultasmovimientos.ObtenerDatosCrecredito(item, 3);
                innerResponse.Mora = _consultasmovimientos.ObtenerDatosCrecredito(item, 4);
                innerResponse.Impuestos = _consultasmovimientos.ObtenerDatosCrecredito(item, 7);
                innerResponse.Cargos = _consultasmovimientos.ObtenerDatosCrecredito(item, 6);
                innerResponse.Total = _consultassaldos.ObtenerSaldoAlVencimiento(entidad, request.FechaInicio, request.FechaFin);
                innerResponse.Divisa = "PESOS";
                innerResponse.FechaDePago = _consultasmovimientos.ObtenerFechaPago(item);

                Listresponse.Movimientos.Add(innerResponse);
            }
 
            Listresponse.equivalencia = request.equivalencia;
            Listresponse.FechaInicio = request.FechaInicio;
            Listresponse.FechaFin = request.FechaFin;

            responseList.Add(Listresponse);

            return responseList;
        }
    }
}
