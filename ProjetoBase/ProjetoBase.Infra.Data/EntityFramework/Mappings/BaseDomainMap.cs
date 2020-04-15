using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBase.Domain.Model;

namespace ProjetoBase.Infra.Data.EntityFramework.Mappings
{
    public abstract class BaseDomainMap<T> : IEntityTypeConfiguration<T> where T : BaseDomain
    {
        protected abstract string Table { get; }
        protected abstract string KeyColumn { get; }
        protected abstract string DescriptionColumn { get; }

        protected virtual string Schema => "dbo";
        protected virtual int MaxLength => 50;

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(Table, Schema);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName(KeyColumn)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnName(DescriptionColumn)
                .HasMaxLength(MaxLength)
                .IsRequired();
        }
    }
}
