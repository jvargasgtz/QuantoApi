using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Negocio;

namespace QuantoAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string hello()
        {
            return "hello";
        }
    }
}
