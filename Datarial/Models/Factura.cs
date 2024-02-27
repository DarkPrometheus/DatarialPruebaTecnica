using System;
using System.Collections.Generic;

namespace Datarial.Models
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int FacturaId { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
