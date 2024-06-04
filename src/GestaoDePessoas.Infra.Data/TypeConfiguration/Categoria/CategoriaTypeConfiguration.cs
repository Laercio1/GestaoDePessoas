using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.CategoriaRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class CategoriaTypeConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(pk => pk.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.NOME)
                .HasColumnName("NOME")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("CATEGORIA");
        }
    }
}
