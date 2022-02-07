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
    public class DeclaracionConfiguration : IEntityTypeConfiguration<Declaracion>
    {
        public void Configure(EntityTypeBuilder<Declaracion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descripcion).HasMaxLength(150);
            //builder.Property(x => x.FechaDeclaracion);
            builder.Property(x => x.Ley).HasMaxLength(50);
            //builder.Property(x => x.FechaLey);
            //builder.Property(x => x.Articulo);
            //builder.Property(x => x.BOE);
            //builder.Property(x => x.FechaBOE);
            builder.Property(x => x.UrlBOE).HasMaxLength(150);
        }
    }
}
