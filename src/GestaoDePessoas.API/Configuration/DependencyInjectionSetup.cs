using GestaoDePessoas.Infra.CrossCutting.Ioc;
using GestaoDePessoas.Infra.CrossCutting.Ioc;

namespace GestaoDePessoas.Services.API.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
