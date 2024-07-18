using System;
using System.Collections.Generic;

namespace AppWebBlazor2.Server.Models;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public int? Idcargo { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public decimal? Salario { get; set; }

    public virtual Cargo? IdcargoNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
