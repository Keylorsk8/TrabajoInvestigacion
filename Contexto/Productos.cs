namespace Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            OrdenDetalles = new HashSet<OrdenDetalles>();
        }

        [Key]
        public int ProductoID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductoNombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string ImagenPath { get; set; }

        public double? PrecioUnitario { get; set; }

        public int? CategoriaID { get; set; }

        public virtual Categorias Categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenDetalles> OrdenDetalles { get; set; }
    }
}
