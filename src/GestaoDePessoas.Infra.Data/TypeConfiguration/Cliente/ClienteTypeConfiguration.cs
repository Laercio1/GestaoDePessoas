using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.ClienteRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class ClienteTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
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

            builder.Property(p => p.RAZAO)
                .HasColumnName("RAZAO")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.CNPJ_CPF)
                .HasColumnName("CNPJ_CPF")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("CLIENTE");
        }
    }
}
