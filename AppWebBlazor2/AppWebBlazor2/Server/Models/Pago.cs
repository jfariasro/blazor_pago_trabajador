using System;
using System.Collections.Generic;

namespace AppWebBlazor2.Server.Models;

public partial class Pago
{
    public int Idpago { get; set; }

    public int? Idempleado { get; set; }

    public DateTime? Fechapago { get; set; }

    public decimal? Totalpago { get; set; }

    public virtual Empleado? IdempleadoNavigation { get; set; }
}
