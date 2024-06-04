using Microsoft.AspNetCore.Http;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Marcas;
using GestaoDePessoas.Dominio.MarcaRoot.Repository;
using GestaoDePessoas.Application.Services.Pedidos;
using GestaoDePessoas.Application.Interfaces.Marcas;
using GestaoDePessoas.Application.Services.Produtos;
using GestaoDePessoas.Application.Services.Clientes;
using GestaoDePessoas.Dominio.PedidoRoot.Repository;
using GestaoDePessoas.Application.Services.Enderecos;
using GestaoDePessoas.Dominio.ProdutoRoot.Repository;
using GestaoDePessoas.Dominio.ClienteRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Pedidos;
using GestaoDePessoas.Application.Interfaces.Produtos;
using GestaoDePessoas.Application.Interfaces.Clientes;
using GestaoDePessoas.Dominio.EnderecoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Enderecos;
using GestaoDePessoas.Application.Services.PedidoItens;
using GestaoDePessoas.Dominio.PedidoItemRoot.Repository;
using GestaoDePessoas.Application.Interfaces.PedidoItens;
using GestaoDePessoas.Dominio.ContatoRoot.Repository;
using GestaoDePessoas.Application.Services.Contatos;
using GestaoDePessoas.Application.Interfaces.Contatos;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.FormaPagamentos;
using GestaoDePessoas.Application.Services.FormaPagamentos;
using GestaoDePessoas.Dominio.CategoriaRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Categorias;
using GestaoDePessoas.Application.Services.Categorias;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Repository;
using GestaoDePessoas.Application.Services.PedidosStatus;
using GestaoDePessoas.Application.Interfaces.PedidosStatus;

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

            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IPedidoItemService, PedidoItemService>();
            services.AddScoped<IPedidoStatusService, PedidoStatusService>();
            services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();

            #endregion

            #region Repositories

            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
            services.AddScoped<IPedidoStatusRepository, PedidoStatusRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();

            #endregion

            // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}
