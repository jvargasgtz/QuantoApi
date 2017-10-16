using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QuantoAPI
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            // Configuración y servicios de API web

            // Rutas de API web
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            return config;
        }
    }
}
