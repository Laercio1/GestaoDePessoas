using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.ContatoRoot.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<ListaPaginada<Contato>> ObterPorTodosFiltros(string valorContato, double tipoContato, string descricao, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
