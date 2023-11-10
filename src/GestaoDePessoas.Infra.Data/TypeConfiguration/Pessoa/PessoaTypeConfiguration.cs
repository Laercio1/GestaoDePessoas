using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PessoaRoot;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class PessoaTypeConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.NomeCompleto)
                .HasColumnName("nomecompleto")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.CNPJ_CPF)
                .HasColumnName("cnpj_cpf")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(12)");

            builder.Property(p => p.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(9)")
                .IsRequired();

            builder.Property(p => p.Estado)
               .HasColumnName("estado")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(p => p.Cidade)
               .HasColumnName("cidade")
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Bairro)
               .HasColumnName("bairro")
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(p => p.Numero)
               .HasColumnName("numero")
               .HasColumnType("varchar(50)");

            builder.Property(p => p.Logradouro)
               .HasColumnName("logradouro")
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DataCadastro)
               .HasColumnName("data_cadastro")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("Pessoa");
        }
    }
}
