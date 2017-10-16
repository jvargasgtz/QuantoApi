using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DatosOperacionesActivas
    {
        EsquemaBDDataContext esquema = new EsquemaBDDataContext();
        public void ArregloOperaciones()
        {
            var creditos = from c in esquema.CRE_CREDITO
                           where c.idPersonaSolicitante == 1
                           select c;
        }
    }
}

//public DatosOperacionesActivas(IConsultasCredito consultas)
//{
//    this.consultas = _consultas;
//}

