using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.PedidoItemRoot.Repository
{
    public interface IPedidoItemRepository : IRepository<PedidoItem>
    {
        int EExisteCadastroPedido(PedidoItem model);

        int EExisteCadastroProduto(PedidoItem model);
    }
}
