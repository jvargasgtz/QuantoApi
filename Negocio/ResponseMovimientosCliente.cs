﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ResponseMovimientosCliente
    {
        public string equivalencia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<InnerMovimientosCliente> Movimientos { get; set; }
    }
}
