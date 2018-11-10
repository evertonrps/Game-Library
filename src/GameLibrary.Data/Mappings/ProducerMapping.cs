using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Data.Mappings
{
    public class ProducerMapping : EntityTypeConfiguration<Producer>
    {
        public override void Map(EntityTypeBuilder<Producer> builder)
        {
            builder.Property(c => c.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(c => c.Founded)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(c => c.WebSite)
               .HasColumnType("varchar(150)")
               .IsRequired(false);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Producers");
        }
    }
}
