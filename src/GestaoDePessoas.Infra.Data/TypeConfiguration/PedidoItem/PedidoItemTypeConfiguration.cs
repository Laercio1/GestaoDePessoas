using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PedidoItemRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class PedidoItemTypeConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(pk => pk.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.ProdutoID)
                .HasColumnName("ProdutoID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.QUANTIDADE)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("PEDIDOITEM");
        }
    }
}
