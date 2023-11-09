using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Pessoas;
using GestaoDePessoas.Application.Services.Pessoas;

namespace GestaoDePessoas.Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<GestaoDePessoasContext>();

            services.AddScoped<HttpClient>();

            //services.AddScoped<IMediator, Mediator>();

            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();

            #region Services

            services.AddScoped<IPessoaService, PessoaService>();

            #endregion

            #region Services

            services.AddScoped<IPessoaRepository, PessoaRepository>();

            #endregion

            // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}
