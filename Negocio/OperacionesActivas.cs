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
        public OperacionesActivas()
        { }

        public List<ResponseCredito> Procesar(RequestActivo request)
        {
            EntidadCreditoBase entidadCredito = new EntidadCreditoBase();

            List<ResponseCredito> responseList = new List<ResponseCredito>();
            
            ResponseCredito Listresponse = new ResponseCredito();

            ConsultasCreditos consultasCredito = new ConsultasCreditos();
            entidadCredito.equivalencia = request.Equivalencia;

            var listaCreditos =  consultasCredito.CreditosPorReferencia(entidadCredito);
            
            Listresponse.Creditos = new List<InnerActivo>();

            foreach (var item in listaCreditos)
            {
                entidadCredito.credito = item.idCredito;

                InnerActivo innerResponse = new InnerActivo();
                innerResponse.Nocredito = item.idCredito;
                innerResponse.FechaDesembolso = item.FechaDesembolso.Value;
                innerResponse.FechaVencimiento = item.FechaVencimiento.Value;
                innerResponse.MontoDispuesto = consultasCredito.MontoDispuesto(item.idCredito);
                innerResponse.MontoAPagar = consultasCredito.ConsultasCreCreditoConcepto(entidadCredito);
                innerResponse.SaldoAlDia = consultasCredito.ConsultasCreCreditoConcepto(entidadCredito);
                innerResponse.Divisa = "Pesos";

                Listresponse.Creditos.Add(innerResponse);
            }

            Listresponse.Cliente = int.Parse(request.Equivalencia);
            responseList.Add(Listresponse);

            return responseList;
        }
    }
}
