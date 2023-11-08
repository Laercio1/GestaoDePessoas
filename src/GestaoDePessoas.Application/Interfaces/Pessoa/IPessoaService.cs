using GestaoDePessoas.Application.Services.Base.Interfaces;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PessoaRoot.Validation;

namespace GestaoDePessoas.Application.Interfaces.Produtos
{
    public interface IPessoaService : IBaseCadastroService<Pessoa,
        PessoaViewModel,
        PessoaAdicionarViewModel,
        PessoaAtualizarViewModel,
        PessoaValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
