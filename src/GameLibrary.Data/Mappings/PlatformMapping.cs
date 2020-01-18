using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Data.Mappings
{
    public class PlatformMapping : EntityTypeConfiguration<Platform>
    {
        public override void Map(EntityTypeBuilder<Platform> builder)
        {
            builder.Property(c => c.Description).HasColumnType("varchar(150)").IsRequired();

            builder.HasOne(c => c.PlatFormType)
            .WithMany(y => y.Platforms)
            .HasForeignKey(c => c.PlatformTypeId);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.Ignore(e => e.GamePlatform);

            builder.ToTable("Platforms");
        }
    }
}