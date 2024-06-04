using GestaoDePessoas.Dominio.PedidoItemRoot;
using GestaoDePessoas.Application.ViewModels.PedidoItem;
using GestaoDePessoas.Dominio.PedidoItemRoot.Validation;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.PedidoItens
{
    public interface IPedidoItemService : IBaseCadastroService<PedidoItem,
        PedidoItemViewModel,
        PedidoItemAddViewModel,
        PedidoItemAtualizarViewModel,
        PedidoItemValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
