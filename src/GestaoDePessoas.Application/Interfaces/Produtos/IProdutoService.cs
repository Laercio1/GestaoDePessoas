using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.ProdutoRoot.Validation;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Produtos
{
    public interface IProdutoService : IBaseCadastroService<Produto,
        ProdutoViewModel,
        ProdutoAdicionarViewModel,
        ProdutoAtualizarViewModel,
        ProdutoValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
