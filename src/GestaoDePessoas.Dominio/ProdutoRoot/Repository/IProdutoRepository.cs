using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.ProdutoRoot.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorId(Guid id);

        int EExisteCadastroMarca(Produto model);

        int EExisteCadastroCategoria(Produto model);

        int EExisteCadastroMesmoNOME(Produto model);

        Task<ListaPaginada<Produto>> ObterPorTodosFiltros(string nome, Guid? idMarca, Guid? idCategoria, string cbarra, string unidade, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
