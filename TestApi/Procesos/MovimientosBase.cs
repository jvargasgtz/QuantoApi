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
    public class MovimientosBase
    {
        public List<ResponseMovimientosCliente> Proceso(RequestMovimientosCliente request)
        {
            IAuthenticate auth = new PlainAuthentication();
            List<ResponseMovimientosCliente> responseList = new List<ResponseMovimientosCliente>();

            if (auth.isAuthenticated(request.username, request.password))
            {
                ResponseMovimientosCliente Listresponse = new ResponseMovimientosCliente();

                Listresponse.Movimientos = new List<InnerMovimientosCliente>();
                for (int i = 0; i < 2; i++)
                {
                    InnerMovimientosCliente innerResponse = new InnerMovimientosCliente();

                    innerResponse.idCredito = 18;
                    innerResponse.Divisa = "PESOS";
                    innerResponse.Fecha = "31/10/2017";
                    innerResponse.Capital = 20000;
                    innerResponse.Interes = 1000;
                    innerResponse.Mora = 2000;
                    innerResponse.Cargos = 200;
                    innerResponse.Impuestos = 500;
                    innerResponse.Total = 23700;

                    Listresponse.Movimientos.Add(innerResponse);
                }
                Listresponse.IdCliente = request.IdCliente;
                Listresponse.FechaInicio = request.FechaInicio;
                Listresponse.FechaFin = request.FechaFin;

                responseList.Add(Listresponse);

                return responseList;
            }
            else { return responseList; }
        }
    }
}
