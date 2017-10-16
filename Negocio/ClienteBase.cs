using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Entidad;

namespace Negocio
{
    public class ClienteBase
    {
        Icliente _cliente;
        IEstadodeCuenta _consultasEstadoDeCuenta;
        IConsultasCredito _consultasCredito;
        public ClienteBase(Icliente cliente, IConsultasCredito consutasCredito, IEstadodeCuenta consultasEstadodeCuenta)
        {
            this._cliente = cliente;
            this._consultasCredito = consutasCredito;
            this._consultasEstadoDeCuenta = consultasEstadodeCuenta;
        }
        public InnerCliente Proceso(RequestCliente request)
        {
            EntidadCreditoBase entidad = new EntidadCreditoBase();
            InnerCliente innerResponse = new InnerCliente();

            entidad.equivalencia = request.equivalencia;

            innerResponse.NombreCliente = _consultasEstadoDeCuenta.ObtenerNombreCliente(entidad);
            innerResponse.IdCliente = _consultasCredito.ObtenerIdPersonaPorReferencia(entidad);

            entidad.idpersona = _consultasCredito.ObtenerIdPersonaPorReferencia(entidad);

            var contratoyfecha = _cliente.ObtenerInformacionCliente(entidad);

            innerResponse.IdContrato = contratoyfecha[0].ToString();
            innerResponse.FechaVencimiento = contratoyfecha[1].ToString();

            return innerResponse;
        }
    }
}
