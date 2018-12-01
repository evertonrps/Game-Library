using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Data.Mappings
{
    public class PlatformTypeMapping : EntityTypeConfiguration<PlatformType>
    {
        public override void Map(EntityTypeBuilder<PlatformType> builder)
        {
            builder.Property(c => c.Description).HasColumnType("varchar(150)").IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("PlatformTypes");
        }
    }
}
