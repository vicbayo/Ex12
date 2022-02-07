using Ex12.Entities.Entities;
using Ex12.Entities.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.RepositoryEFCore.EntitiesConfigurations
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Type).HasMaxLength(10);
            builder.Property(x => x.TableName).HasMaxLength(50);
            builder.Property(x => x.OldValues); // longitud máxima
            builder.Property(x => x.NewValues); // longitud máxima
            builder.Property(x => x.AffectedColumns); // longitud máxima
            builder.Property(x => x.PrimaryKey).HasMaxLength(100);
        }
    }
}
