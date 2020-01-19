using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Data.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.NomeUsuario).HasColumnType("varchar(150)").IsRequired();

            builder.Property(c => c.Email).HasMaxLength(150).IsRequired();

            builder.Property(c => c.CPF).HasMaxLength(11).IsRequired();

            builder.Property(c => c.SenhaHash).HasMaxLength(255).IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Usuarios");
        }
    }
}