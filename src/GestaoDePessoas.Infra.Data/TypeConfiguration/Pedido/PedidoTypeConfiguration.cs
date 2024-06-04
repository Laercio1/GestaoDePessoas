using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PedidoRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class PedidoTypeConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(pk => pk.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.ClienteID)
                .HasColumnName("ClienteID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.FormaPagamentoID)
                .HasColumnName("FormaPagamentoID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.PedidoStatusID)
                .HasColumnName("PedidoStatusID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.DESCONTO)
                .HasColumnName("DESCONTO")
                .HasColumnType("decimal(15,5)")
                .IsRequired();

            builder.Property(p => p.VALORTOTAL)
                .HasColumnName("VALORTOTAL")
                .HasColumnType("decimal(15,5)")
                .IsRequired();

            builder.Property(p => p.VALORFINAL)
                .HasColumnName("VALORFINAL")
                .HasColumnType("decimal(15,5)")
                .IsRequired();

            builder.Property(p => p.NUMEROPEDIDO)
                .HasColumnName("NUMEROPEDIDO")
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

            builder.ToTable("PEDIDO");
        }
    }
}
