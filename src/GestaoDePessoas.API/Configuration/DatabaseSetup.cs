using GestaoDePessoas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoDePessoas.API.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<GestaoDePessoasContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("GestaoDePessoasConnectionString")));
        }
    }
}
