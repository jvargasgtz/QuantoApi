using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Auth;
using TestApi.Inner;
using TestApi.Request;

namespace TestApi.Procesos
{
    public class ClienteBase
    {
        public InnerCliente Proceso(RequestCliente request)
        {
            IAuthenticate auth = new PlainAuthentication();
            InnerCliente innerResponse = new InnerCliente();

            if (auth.isAuthenticated(request.username, request.password))
            {
                innerResponse.NombreCliente = "Cayetano Gómez Mendoza";
                innerResponse.IdCliente = request.IdCliente;
                innerResponse.IdContrato = "U2014R0056";
                innerResponse.FechaVencimiento = "30/08/2017";

                return innerResponse;
            }
            else { return innerResponse; }
        }
    }
}
