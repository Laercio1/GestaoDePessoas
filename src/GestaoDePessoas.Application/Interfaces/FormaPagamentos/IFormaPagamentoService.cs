using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Application.Services.Base.Interfaces;
using GestaoDePessoas.Application.ViewModels.FormaPagamento;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Validation;

namespace GestaoDePessoas.Application.Interfaces.FormaPagamentos
{
    public interface IFormaPagamentoService : IBaseCadastroService<FormaPagamento,
        FormaPagamentoViewModel,
        FormaPagamentoAdicionarViewModel,
        FormaPagamentoAtualizarViewModel,
        FormaPagamentoValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
