using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Modelos
{
    public class consultascliente : Icliente
    {
        public consultascliente()
        { }

        EsquemaBDDataContext esquema = new EsquemaBDDataContext();

        public List<string> ObtenerInformacionCliente(EntidadCreditoBase entidad)
        {
            List<string> lsresultante = new List<string>();
            var resultado = from c in esquema.CRE_CREDITO
                            where c.idPersonaSolicitante == entidad.idpersona
                            && c.idEstadoCredito == 4 && c.idTipoRegistro == 3 && c.idEstado == 1
                            select new { c.Contrato, c.FechaVencimiento };

            lsresultante.Add(resultado.ToList()[0].Contrato);
            lsresultante.Add(resultado.ToList()[0].FechaVencimiento.ToString());

            return lsresultante;
        }
    }
}
