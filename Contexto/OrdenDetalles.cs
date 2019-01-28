namespace Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrdenDetalles
    {
        [Key]
        public int OrdenDetalleId { get; set; }

        public int OrdenId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public double? PrecioUnitario { get; set; }

        public virtual Ordenes Ordenes { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
