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
    public class SaldosBase
    {
        public List<ResponseSaldosPorCliente> Proceso(RequestSaldosPorCliente request)
        {
            IAuthenticate auth = new PlainAuthentication();
            List<ResponseSaldosPorCliente> responseList = new List<ResponseSaldosPorCliente>();

            if (auth.isAuthenticated(request.username, request.password))
            {
                ResponseSaldosPorCliente Listresponse = new ResponseSaldosPorCliente();

                Listresponse.Saldos = new List<InnerSaldosPorCliente>();
                for (int i = 0; i < 2; i++)
                {
                    InnerSaldosPorCliente innerResponse = new InnerSaldosPorCliente();

                    innerResponse.IdCredito = 18;
                    innerResponse.FechaDesembolso = "26/08/2017";
                    innerResponse.FechaVencimiento = "26/09/2017";
                    innerResponse.MontoDispuesto = 20000;
                    innerResponse.MontoaPagar = 22000;
                    innerResponse.SaldoalDia = 25000;
                    innerResponse.Divisa = "PESOS";
                    innerResponse.Estado = "ACTIVO";

                    Listresponse.Saldos.Add(innerResponse);
                }
                Listresponse.IdCliente = request.idCliente;
                Listresponse.FechaInicio = request.FechaInicio;
                Listresponse.FechaFin = request.FechaFin;

                responseList.Add(Listresponse);

                return responseList;
            }
            else { return responseList; }
        }
    }
}
