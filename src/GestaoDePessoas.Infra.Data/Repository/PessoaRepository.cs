using GestaoDePessoas.Dominio;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Dominio.Core.Utils.StringUtils;

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

            var consulta = _consulta.Where(l => l.CNPJ_CPF == cpf_cnpj).FirstOrDefault();

            return consulta.Id;
        }

        public int EExisteCadastroMesmoCPFCNPJ(Pessoa model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => c.CNPJ_CPF.ToLower().Contains(StringUtils.ApenasNumeros(model.CNPJ_CPF.ToLower()))).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Pessoa>> ObterPorTodosFiltros(bool? ativo, int? pagina, int? tamanhoPagina, string filtro)
        {
            IQueryable<Pessoa> _consulta = Db.Pessoa;

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.Ativo == ativo.Value);

            if (!string.IsNullOrEmpty(filtro))
            {
                _consulta = _consulta.AsNoTracking()
                .Where(e => (e.NomeCompleto.ToLower().Contains(filtro.ToLower()) ||
                          e.CNPJ_CPF.ToLower() == StringUtils.ApenasNumeros(filtro.ToLower()) ||
                          e.Logradouro.ToLower() == filtro.ToLower() ||
                          e.Bairro.ToLower() == (filtro.ToLower())))
                .OrderBy(e => e.NomeCompleto);
            }

            _consulta = _consulta.OrderByNew(filtro);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Pessoa>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
