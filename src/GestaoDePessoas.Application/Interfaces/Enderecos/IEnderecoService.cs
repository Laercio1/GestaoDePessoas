using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Application.ViewModels.Endereco;
using GestaoDePessoas.Dominio.EnderecoRoot.Validation;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Enderecos
{
    public interface IEnderecoService : IBaseCadastroService<Endereco,
        EnderecoViewModel,
        EnderecoAdicionarViewModel,
        EnderecoAtualizarViewModel,
        EnderecoValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
