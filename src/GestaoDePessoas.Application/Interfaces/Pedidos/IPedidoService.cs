using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Dominio.PedidoRoot.Validation;
using GestaoDePessoas.Application.ViewModels.Pedido;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Pedidos
{
    public interface IPedidoService : IBaseCadastroService<Pedido,
        PedidoViewModel,
        PedidoAdicionarViewModel,
        PedidoAtualizarViewModel,
        PedidoValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
