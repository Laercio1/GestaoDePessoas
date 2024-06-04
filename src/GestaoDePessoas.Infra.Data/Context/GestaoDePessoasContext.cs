using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.MarcaRoot;
//using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Dominio.ContatoRoot;
using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Dominio.PedidoItemRoot;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Infra.Data.TypeConfiguration;
using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Dominio.PedidoStatusRoot;

namespace GestaoDePessoas.Infra.Data.Context
{
    public class GestaoDePessoasContext : DbContext
    {
        public GestaoDePessoasContext()
        {

        }

        public GestaoDePessoasContext(DbContextOptions<GestaoDePessoasContext> options) : base(options) { }
        public DbSet<Marca> Marca { get; set; }
        //public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<PedidoStatus> PedidoStatus { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarcaTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new PessoaTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoStatusTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoTypeConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DATAHORACADASTRO") != null))
            {
                if (entry.State == EntityState.Added) entry.Property("DATAHORACADASTRO").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified) entry.Property("DATAHORACADASTRO").IsModified = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}