using System;
using System.Collections.Generic;

namespace Datarial.Models
{
    public partial class FacturaDetalle
    {
        public int FacturaDetalleId { get; set; }
        public int? FacturaId { get; set; }
        public int? ProductoId { get; set; }
        public decimal? Precio { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
