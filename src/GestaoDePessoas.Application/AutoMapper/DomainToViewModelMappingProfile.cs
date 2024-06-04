using AutoMapper;
using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Dominio.PedidoItemRoot;
using GestaoDePessoas.Application.ViewModels.Marca;
using GestaoDePessoas.Application.ViewModels.Pedido;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Application.ViewModels.Cliente;
using GestaoDePessoas.Application.ViewModels.Endereco;
using GestaoDePessoas.Application.ViewModels.PedidoItem;
using GestaoDePessoas.Dominio.ContatoRoot;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Application.ViewModels.FormaPagamento;
using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Application.ViewModels.Categoria;
using GestaoDePessoas.Dominio.PedidoStatusRoot;
using GestaoDePessoas.Application.ViewModels.PedidoStatus;

namespace GestaoDePessoas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Marca, MarcaAdicionarViewModel>().ReverseMap();
            CreateMap<Marca, MarcaAtualizarViewModel>().ReverseMap();
            CreateMap<Marca, MarcaViewModel>().ReverseMap();

            CreateMap<Pedido, PedidoAdicionarViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoAtualizarViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();

            CreateMap<Produto, ProdutoAdicionarViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoAtualizarViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

            CreateMap<Cliente, ClienteAdicionarViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteAtualizarViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            CreateMap<Contato, ContatoAdicionarViewModel>().ReverseMap();
            CreateMap<Contato, ContatoAtualizarViewModel>().ReverseMap();
            CreateMap<Contato, ContatoViewModel>().ReverseMap();

            CreateMap<Endereco, EnderecoAdicionarViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoAtualizarViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();

            CreateMap<Categoria, CategoriaAdicionarViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaAtualizarViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();

            CreateMap<PedidoItem, PedidoItemAdicionarViewModel>().ReverseMap();
            CreateMap<PedidoItem, PedidoItemAtualizarViewModel>().ReverseMap();
            CreateMap<PedidoItem, PedidoItemAddViewModel>().ReverseMap();
            CreateMap<PedidoItem, PedidoItemViewModel>().ReverseMap();

            CreateMap<PedidoStatus, PedidoStatusAdicionarViewModel>().ReverseMap();
            CreateMap<PedidoStatus, PedidoStatusAtualizarViewModel>().ReverseMap();
            CreateMap<PedidoStatus, PedidoStatusViewModel>().ReverseMap();

            CreateMap<FormaPagamento, FormaPagamentoAdicionarViewModel>().ReverseMap();
            CreateMap<FormaPagamento, FormaPagamentoAtualizarViewModel>().ReverseMap();
            CreateMap<FormaPagamento, FormaPagamentoViewModel>().ReverseMap();
        }
    }
}
