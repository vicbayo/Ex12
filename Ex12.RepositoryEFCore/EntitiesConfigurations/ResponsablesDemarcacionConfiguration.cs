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
    public class ResponsablesDemarcacionConfiguration : IEntityTypeConfiguration<ResponsablesDemarcacion>
    {
        public void Configure(EntityTypeBuilder<ResponsablesDemarcacion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JefeDemarcacion).HasMaxLength(100);
            builder.Property(x => x.IngenerioCircumbalacion).HasMaxLength(100);
            builder.Property(x => x.PeritoDemarcacion).HasMaxLength(100);
            builder.Property(x => x.RepresentanteDemarcacion).HasMaxLength(100);
            builder.Property(x => x.IngenieroJefeArea).HasMaxLength(100);
            builder.Property(x => x.IngenieroJefe).HasMaxLength(100);
            builder.Property(x => x.Pagador).HasMaxLength(100);            
        }
    }
}
