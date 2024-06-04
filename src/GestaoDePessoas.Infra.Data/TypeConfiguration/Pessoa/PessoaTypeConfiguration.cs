//using Microsoft.EntityFrameworkCore;
//using GestaoDePessoas.Dominio.PessoaRoot;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace GestaoDePessoas.Infra.Data.TypeConfiguration
//{
//    public class PessoaTypeConfiguration : IEntityTypeConfiguration<Pessoa>
//    {
//        public void Configure(EntityTypeBuilder<Pessoa> builder)
//        {
//            builder.HasKey(pk => pk.ID);

//            builder.Property(p => p.ID)
//                .HasColumnName("ID")
//                .HasColumnType("char(36)")
//                .IsRequired();

//            builder.Property(p => p.NOMECOMPLETO)
//                .HasColumnName("NOMECOMPLETO")
//                .HasColumnType("varchar(250)")
//                .IsRequired();

//            builder.Property(p => p.CNPJ_CPF)
//                .HasColumnName("CNPJ_CPF")
//                .HasColumnType("varchar(14)")
//                .IsRequired();

//            builder.Property(p => p.ATIVO)
//               .HasColumnName("ATIVO")
//               .HasColumnType("bit")
//               .IsRequired();

//            builder.Property(p => p.DATAHORACADASTRO)
//               .HasColumnName("DATAHORACADASTRO")
//               .HasColumnType("datetime")
//               .IsRequired();

//            builder.ToTable("PESSOA");
//        }
//    }
//}
