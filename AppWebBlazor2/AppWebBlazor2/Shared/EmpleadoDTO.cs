using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWebBlazor2.Shared
{
    public class EmpleadoDTO
    {
        public int Idempleado { get; set; }

        public string? Nombre { get; set; }

        public int? Edad { get; set; }

        public decimal? Salario { get; set; }

        public virtual CargoDTO? Cargo { get; set; }
    }
}
