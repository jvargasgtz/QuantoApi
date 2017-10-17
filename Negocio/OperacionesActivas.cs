using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Entidad;

namespace Negocio
{
    public class OperacionesActivas
    {
        IEstadodeCuenta _consultasEstadoDeCuenta;
        IConsultasCredito _consultasCredito;
        Iconsultassaldos _consultassaldos;

        public OperacionesActivas(IConsultasCredito consutasCredito, IEstadodeCuenta consultasEstadodeCuenta, Iconsultassaldos consultassaldos)
        {
            this._consultasEstadoDeCuenta = consultasEstadodeCuenta;
            this._consultasCredito = consutasCredito;
            this._consultassaldos = consultassaldos;
        }

        public List<ResponseCredito> Procesar(RequestActivo request)
        {
            EntidadCreditoBase entidadCredito = new EntidadCreditoBase();

            List<ResponseCredito> responseList = new List<ResponseCredito>();
            
            ResponseCredito Listresponse = new ResponseCredito();

            entidadCredito.equivalencia = request.Equivalencia;

            var listaCreditos = _consultasCredito.ObtenerCreditosPorCliente(entidadCredito);
            
            Listresponse.Creditos = new List<InnerActivo>();

            foreach (var item in listaCreditos)
            {
                entidadCredito.credito = item.idCredito;

                InnerActivo innerResponse = new InnerActivo();
                innerResponse.Nocredito = item.idCredito;
                innerResponse.FechaDesembolso = item.FechaDesembolso.Value;
                innerResponse.FechaVencimiento = item.FechaVencimiento.Value;
                innerResponse.MontoDispuesto = item.MontoDesembolsado.Value;
                innerResponse.MontoAPagar = _consultasCredito.ConsultasMontoAPagar(entidadCredito);
                innerResponse.SaldoAlDia = _consultasCredito.ConsultasCreCreditoConcepto(entidadCredito);
                innerResponse.Divisa = _consultasCredito.ObtenerDivisa(item.idCredito);

                Listresponse.Creditos.Add(innerResponse);
            }

            Listresponse.Cliente = int.Parse(request.Equivalencia);
            responseList.Add(Listresponse);

            return responseList;
        }
    }
}
