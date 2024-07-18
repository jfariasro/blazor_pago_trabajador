using System;
using System.Collections.Generic;

namespace AppWebBlazor2.Server.Models;

public partial class Cargo
{
    public int Idcargo { get; set; }

    public string? Nombre { get; set; }

    public string? Desripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
