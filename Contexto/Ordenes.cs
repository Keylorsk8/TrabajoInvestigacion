namespace Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ordenes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordenes()
        {
            OrdenDetalles = new HashSet<OrdenDetalles>();
        }

        [Key]
        public int OrdenId { get; set; }

        public DateTime OrdenFecha { get; set; }

        public string NombreCliente { get; set; }

        public decimal Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenDetalles> OrdenDetalles { get; set; }
    }
}
