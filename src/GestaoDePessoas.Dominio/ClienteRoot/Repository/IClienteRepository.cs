using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.ClienteRoot.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterPorId(Guid id);

        int EExisteCadastroMesmoCPFCNPJ(Cliente model);

        Task<ListaPaginada<Cliente>> ObterPorTodosFiltros(string nome, string cnpJ_CPF, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
