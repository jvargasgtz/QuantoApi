﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Modelos
{
    public interface Iconsultassaldos
    {
        decimal ObtenerSaldoAlVencimiento(EntidadCreditoBase entidad, DateTime FechaInicio, DateTime FechaFin);
    }
}
