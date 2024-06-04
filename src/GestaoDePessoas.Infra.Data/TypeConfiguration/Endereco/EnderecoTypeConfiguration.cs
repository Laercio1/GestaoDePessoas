using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.EnderecoRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class EnderecoTypeConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(pk => pk.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar(9)")
                .IsRequired();

            builder.Property(p => p.ESTADO)
               .HasColumnName("ESTADO")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(p => p.CIDADE)
               .HasColumnName("CIDADE")
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.BAIRRO)
               .HasColumnName("BAIRRO")
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(p => p.NUMERO)
               .HasColumnName("NUMERO")
               .HasColumnType("float");

            builder.Property(p => p.CODIGOPOSTAL)
               .HasColumnName("CODIGOPOSTAL")
               .HasColumnType("float");

            builder.Property(p => p.RUA)
               .HasColumnName("RUA")
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("ENDERECO");
        }
    }
}

