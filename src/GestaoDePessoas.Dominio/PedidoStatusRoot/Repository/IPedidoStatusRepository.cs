using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.PedidoStatusRoot.Repository
{
    public interface IPedidoStatusRepository : IRepository<PedidoStatus>
    {
        Task<PedidoStatus> ObterPorId(Guid id);

        int EExisteCadastroMesmaDescricao(PedidoStatus model);

        Task<ListaPaginada<PedidoStatus>> ObterPorTodosFiltros(string descricao, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
