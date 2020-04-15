using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBase.Domain.Model.Usuarios;

namespace ProjetoBase.Infra.Data.EntityFramework.Mappings
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "dbo");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("cd_usuario");
            builder.Property(u => u.Nome)
                .HasColumnName("nm_usuario")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
