using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Modelos;
using Operacion;

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
            
            var ListaCreditos = _consultasCredito.ObtenerCreditosPorCliente(entidad);
            
            foreach (var item in ListaCreditos)
            {
                InnerMovimientosCliente innerResponse = new InnerMovimientosCliente();
                entidad.credito = item.idCredito;

                innerResponse.idCredito = item.idCredito;
                innerResponse.Capital = _consultasmovimientos.ObtenerDatosCrecredito(item.idCredito, (int)constantes.ConceptoCapital);
                innerResponse.Interes = _consultasmovimientos.ObtenerDatosCrecredito(item.idCredito, (int)constantes.ConceptoInteres);
                innerResponse.Mora = _consultasmovimientos.ObtenerDatosCrecredito(item.idCredito, (int)constantes.conceptoMoratorio);
                innerResponse.Impuestos = _consultasmovimientos.ObtenerDatosCrecredito(item.idCredito, (int)constantes.ConceptoIva);
                innerResponse.Cargos = _consultasmovimientos.ObtenerDatosCrecredito(item.idCredito, (int)constantes.ConceptoCargo);
                innerResponse.Total = _consultassaldos.ObtenerSaldoAlVencimiento(entidad, request.FechaInicio, request.FechaFin);
                innerResponse.Divisa = _consultasCredito.ObtenerDivisa(item.idCredito);
                innerResponse.FechaDePago = _consultasmovimientos.ObtenerFechaPago(item.idCredito);

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
