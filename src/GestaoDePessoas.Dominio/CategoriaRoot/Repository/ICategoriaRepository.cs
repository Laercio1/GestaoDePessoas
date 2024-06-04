using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.CategoriaRoot.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Guid> ObterId(string nome);

        int EExisteCadastroMesmoNOME(Categoria model);

        Task<ListaPaginada<Categoria>> ObterPorTodosFiltros(string nome, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
