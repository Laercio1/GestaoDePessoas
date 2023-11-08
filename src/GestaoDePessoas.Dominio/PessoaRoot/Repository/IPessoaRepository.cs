using GestaoDePessoas.Dominio;
using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.PessoaRoot.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Guid> ObterId(string cpf_cnpj);

        Task<Pessoa> EExisteCadastroMesmoCPFCNPJ(Pessoa model);

        Task<ListaPaginada<Pessoa>> ObterPorTodosFiltros(bool? ativo, int? pagina, int? tamanhoPagina, string filtro);
    }
}
