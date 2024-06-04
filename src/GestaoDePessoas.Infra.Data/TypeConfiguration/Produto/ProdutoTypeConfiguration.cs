using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.ProdutoRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class ProdutoTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
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

            builder.Property(p => p.MarcaID)
                .HasColumnName("MarcaID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.CategoriaID)
                .HasColumnName("CategoriaID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.CBARRA)
                .HasColumnName("CBARRA")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.UNIDADE)
                .HasColumnName("UNIDADE")
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(p => p.PRECOUNITARIO)
                .HasColumnName("PRECOUNITARIO")
                .HasColumnType("decimal(15,5)")
                .IsRequired();

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("PRODUTO");
        }
    }
}
