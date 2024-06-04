using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class FormaPagamentoTypeConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
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

            builder.Property(p => p.DESCRICAO)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.TAXA)
               .HasColumnName("TAXA")
               .HasColumnType("float");

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("FORMAPAGAMENTO");
        }
    }
}
