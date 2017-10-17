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
    public class EstadoCuentaBase
    {
        public List<ResponseEstadoCuenta> Proceso(RequestEstadoCuenta request)
        {
            IAuthenticate auth = new PlainAuthentication();
            List<ResponseEstadoCuenta> responseList = new List<ResponseEstadoCuenta>();

            if (auth.isAuthenticated(request.username, request.password))
            {
                ResponseEstadoCuenta Listresponse = new ResponseEstadoCuenta();

                Listresponse.EstadosCuentas = new List<InnerEstadoCuenta>();
                for (int i = 0; i < 2; i++)
                {
                    InnerEstadoCuenta innerResponse = new InnerEstadoCuenta();

                    innerResponse.NombreCliente = "CAYETANO GOMEZ MENDOZA";
                    innerResponse.IdCliente = request.idCliente;
                    innerResponse.IdContrato = "U2014R0056";
                    innerResponse.MontonLinea = 30000;
                    innerResponse.SaldoalCorte = 21000;
                    innerResponse.CreditoDisponible = 10000;
                    innerResponse.SaldoInicial = 20000;
                    innerResponse.SaldoFinal = 21000;

                    Listresponse.EstadosCuentas.Add(innerResponse);
                }

                Listresponse.Cliente = request.idCliente;
                Listresponse.FechaInicio = request.FechaInicio;
                Listresponse.FechaFin = request.FechaFin;

                responseList.Add(Listresponse);

                return responseList;
            }
            else { return responseList; }
        }
    }
}
