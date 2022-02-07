using Ex12.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.RepositoryEFCore.EntitiesConfigurations
{
    public class ProyectoConfiguration : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Clave).IsRequired();
            builder.HasIndex(x => x.Clave).IsUnique(true);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Notes).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Creador).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FechaCreacion).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Modificador).HasMaxLength(50);
            builder.Property(x => x.FechaAprobacion).IsRequired();
            builder.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasOne<ResponsablesDemarcacion>(x => x.ResponsablesDemarcacion)
                .WithOne()
                .HasForeignKey<ResponsablesDemarcacion>(x => x.Id);

            builder.HasOne<Declaracion>(x => x.Declaracion)
                .WithOne()
                .HasForeignKey<Declaracion>(x => x.Id)
                .IsRequired(false);
        }
    }
}
