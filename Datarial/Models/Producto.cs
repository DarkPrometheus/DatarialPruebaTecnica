using System;
using System.Collections.Generic;

namespace Datarial.Models
{
    public partial class Producto
    {
        public Producto()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int ProductoId { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
