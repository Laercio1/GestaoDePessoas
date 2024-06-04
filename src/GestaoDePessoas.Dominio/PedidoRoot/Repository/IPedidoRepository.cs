using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.PedidoRoot.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorId(Guid id);

        int EExisteCadastroProduto(Guid id);

        int EExisteCadastroCliente(Pedido model);

        int EExisteCadastroPedidoStatus(Pedido model);

        int EExisteCadastroFormaPagamento(Pedido model);

        Task<ListaPaginada<Pedido>> ObterPorTodosFiltros(Guid? idCliente, Guid? idFormaPagamento, Guid? idPedidoStatus, string numero, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
