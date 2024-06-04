using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PedidoStatusRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class PedidoStatusTypeConfiguration : IEntityTypeConfiguration<PedidoStatus>
    {
        public void Configure(EntityTypeBuilder<PedidoStatus> builder)
        {
            builder.HasKey(pk => pk.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.DESCRICAO)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.CANCELADO)
               .HasColumnName("CANCELADO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.FINALIZADO)
               .HasColumnName("FINALIZADO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("PEDIDOSTATUS");
        }
    }
}
