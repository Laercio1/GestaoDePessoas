using GestaoDePessoas.Infra.Data.TypeConfiguration;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PessoaRoot;

namespace GestaoDePessoas.Infra.Data.Context
{
    public class GestaoDePessoasContext : DbContext
    {
        public GestaoDePessoasContext()
        {

        }

        public GestaoDePessoasContext(DbContextOptions<GestaoDePessoasContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaTypeConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}