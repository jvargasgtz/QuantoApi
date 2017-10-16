using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ResponseCredito
    {
        public int Cliente { get; set; }
        public List<InnerActivo> Creditos { get; set; }
    }
}
