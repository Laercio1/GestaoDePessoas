using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.EnderecoRoot.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterPorId(Guid? id);

        Task<ListaPaginada<Endereco>> ObterPorTodosFiltros(Guid? idCliente, string cep, string rua, string bairro,
            string numero, string codigoPostal, bool? ativo, int? pagina, int? tamanhoPagina, string order);
    }
}
