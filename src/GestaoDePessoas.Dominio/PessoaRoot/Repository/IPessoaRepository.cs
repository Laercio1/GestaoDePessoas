using GestaoDePessoas.Dominio.Interfaces;

namespace GestaoDePessoas.Dominio.PessoaRoot.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Guid> ObterId(string cpf_cnpj);

        int EExisteCadastroMesmoCPFCNPJ(Pessoa model);

        Task<ListaPaginada<Pessoa>> ObterPorTodosFiltros(string nomeCompleto, 
            string cnpJ_CPF, 
            string logradouro,
            string bairro, 
            bool? ativo, 
            int? pagina, 
            int? tamanhoPagina, 
            string order);
    }
}
