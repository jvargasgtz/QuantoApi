using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Auth;
using TestApi.Inner;
using TestApi.Request;
using TestApi.Response;

namespace TestApi.Procesos
{
    public class OperacionesActivas
    {
        public List<ResponseCredito> Procesar(RequestActivo request)
        {
            IAuthenticate auth = new PlainAuthentication();
            List<ResponseCredito> responseList = new List<ResponseCredito>();

            if (auth.isAuthenticated(request.username, request.password))
            {
                ResponseCredito Listresponse = new ResponseCredito();

                Listresponse.Creditos = new List<InnerActivo>();
                for (int i = 0; i < 2; i++)
                {
                    InnerActivo innerResponse = new InnerActivo();

                    innerResponse.idcliente = request.Equivalencia + i;
                    innerResponse.Nocredito = i;
                    innerResponse.FechaDesembolso = "20/08/2017";
                    innerResponse.FechaVencimiento = "22/09/2017";
                    innerResponse.MontoDispuesto = 2000;
                    innerResponse.MontoAPagar = 21000;
                    innerResponse.SaldoAlDia = 19000;
                    innerResponse.Divisa = "Pesos";

                    Listresponse.Creditos.Add(innerResponse);
                }

                Listresponse.Cliente = request.Equivalencia;
                responseList.Add(Listresponse);

                return responseList;
            }
            else { return responseList; }
        }
    }
}
