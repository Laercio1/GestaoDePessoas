using GestaoDePessoas.Dominio.PedidoStatusRoot;
using GestaoDePessoas.Application.ViewModels.PedidoStatus;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Validation;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.PedidosStatus
{
    public interface IPedidoStatusService : IBaseCadastroService<PedidoStatus,
        PedidoStatusViewModel,
        PedidoStatusAdicionarViewModel,
        PedidoStatusAtualizarViewModel,
        PedidoStatusValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
