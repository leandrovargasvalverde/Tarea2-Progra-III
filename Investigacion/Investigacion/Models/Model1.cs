using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Investigacion.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Table_Compañeros> Table_Compañeros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table_Compañeros>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Table_Compañeros>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Table_Compañeros>()
                .Property(e => e.Telefono)
                .IsUnicode(false);
        }
    }
}
