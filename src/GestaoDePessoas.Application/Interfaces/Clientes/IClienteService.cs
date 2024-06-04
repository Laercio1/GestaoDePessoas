using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Dominio.ClienteRoot.Validation;
using GestaoDePessoas.Application.ViewModels.Cliente;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Clientes
{
    public interface IClienteService : IBaseCadastroService<Cliente,
        ClienteViewModel,
        ClienteAdicionarViewModel,
        ClienteAtualizarViewModel,
        ClienteValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
