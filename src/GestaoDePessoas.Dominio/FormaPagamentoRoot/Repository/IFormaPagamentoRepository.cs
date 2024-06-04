using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.FormaPagamentoRoot.Repository
{
    public interface IFormaPagamentoRepository : IRepository<FormaPagamento>
    {
        Task<FormaPagamento> ObterPorId(Guid id);

        int EExisteCadastroMesmoNome(FormaPagamento model);

        Task<ListaPaginada<FormaPagamento>> ObterPorTodosFiltros(string nome, string descricao, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
