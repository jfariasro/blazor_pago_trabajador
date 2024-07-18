using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWebBlazor2.Shared
{
    public class PagoDTO
    {
        public int Idpago { get; set; }

        public DateTime? Fechapago { get; set; }

        public decimal? Totalpago { get; set; }

        public virtual EmpleadoDTO? Empleado { get; set; }
    }
}
