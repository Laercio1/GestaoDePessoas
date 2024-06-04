using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.MarcaRoot.Repository
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<Guid> ObterId(string nome);

        int EExisteCadastroMesmoNOME(Marca model);

        Task<ListaPaginada<Marca>> ObterPorTodosFiltros(string nome, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
