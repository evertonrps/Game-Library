using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Data.Mappings
{
    public class GameMapping : EntityTypeConfiguration<Game>
    {
        public override void Map(EntityTypeBuilder<Game> builder)
        {
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Description)
            .IsRequired(false)
            .HasMaxLength(150)
            .HasColumnType("varchar(max)");

            builder.HasOne(c => c.Developer)
            .WithMany(y => y.Games)
            .HasForeignKey(c => c.DeveloperId);

            //builder.Ignore(e => e.ValidationResult);

            //builder.Ignore(e => e.CascadeMode);

            builder.Ignore(e => e.Erros);

            builder.ToTable("Jogos");
        }
    }
}