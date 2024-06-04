using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.ContatoRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePessoas.Infra.Data.TypeConfiguration
{
    public class ContatoTypeConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(pk => pk.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.VALORCONTATO)
                .HasColumnName("VALORCONTATO")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.DESCRICAO)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.TIPOCONTATO)
               .HasColumnName("TIPOCONTATO")
               .HasColumnType("float");

            builder.Property(p => p.ATIVO)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(p => p.DATAHORACADASTRO)
               .HasColumnName("DATAHORACADASTRO")
               .HasColumnType("datetime")
               .IsRequired();

            builder.ToTable("CONTATO");
        }
    }
}
