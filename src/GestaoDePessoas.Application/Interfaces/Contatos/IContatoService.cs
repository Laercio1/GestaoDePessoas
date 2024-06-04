using GestaoDePessoas.Dominio.ContatoRoot;
using GestaoDePessoas.Dominio.ContatoRoot.Validation;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Contatos
{
    public interface IContatoService : IBaseCadastroService<Contato,
        ContatoViewModel,
        ContatoAdicionarViewModel,
        ContatoAtualizarViewModel,
        ContatoValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
