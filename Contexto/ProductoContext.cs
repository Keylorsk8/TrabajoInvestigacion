namespace Contexto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductoContext : DbContext
    {
        public ProductoContext()
            : base("name=ProductoContext")
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<OrdenDetalles> OrdenDetalles { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordenes>()
                .HasMany(e => e.OrdenDetalles)
                .WithRequired(e => e.Ordenes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.OrdenDetalles)
                .WithRequired(e => e.Productos)
                .WillCascadeOnDelete(false);
        }
    }
}
