using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;

namespace GestaoDePessoas.API.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddDbContext<GestaoDePessoasContext>(options => options
            //    .UseSqlServer(configuration.GetConnectionString("GestaoDePessoasConnectionString")));

            //services.AddDbContext<GestaoDePessoasContext>(options => options
            //    .UseSqlite("Data Source=GestaoDePessoas.db"));

            services.AddDbContextPool<GestaoDePessoasContext>(options => options
                .UseMySql(configuration.GetConnectionString("GestaoDePessoasConnectionString"), ServerVersion.AutoDetect(configuration.GetConnectionString("GestaoDePessoasConnectionString"))));
        }
    }
}
