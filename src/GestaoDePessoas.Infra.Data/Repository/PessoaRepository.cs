using GestaoDePessoas.Dominio;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Guid>? ObterId(string cpf_cnpj)
        {
            IQueryable<Pessoa> _consulta = Db.Pessoa.AsQueryable();

            _consulta = _consulta.Where(fp => fp.CNPJ_CPF.Equals(cpf_cnpj));

            var recebeu = _consulta.Where(l => l.CNPJ_CPF == cpf_cnpj).FirstOrDefault();

            return recebeu.Id;
        }

        public async Task<Pessoa> EExisteCadastroMesmoCPFCNPJ(Pessoa model)
        {
            var dependente = ReturnIQueryable();

            dependente = dependente.Where(c => c.CNPJ_CPF.ToLower().Contains(model.CNPJ_CPF.ToLower()));

            return await dependente.FirstOrDefaultAsync();
        }

        public async Task<ListaPaginada<Pessoa>> ObterPorTodosFiltros(bool? ativo, int? pagina, int? tamanhoPagina, string filtro)
        {
            IQueryable<Pessoa> _consulta = Db.Pessoa;

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.Ativo == ativo.Value);

            if (!string.IsNullOrEmpty(filtro))
            {
                    _consulta = _consulta.AsNoTracking()
                 .Where(e => (e.NomeCompleto.ToLower().Contains(filtro.ToLower()) ||
                              e.CNPJ_CPF.ToLower().Contains(filtro.ToLower()) ||
                              e.Logradouro.ToLower().Contains(filtro.ToLower()) ||
                              e.Bairro.ToLower().Contains(filtro.ToLower())))
                .OrderBy(e => e.NomeCompleto);
            }

            _consulta = _consulta.OrderByNew(filtro);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Pessoa>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
