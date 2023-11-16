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

            var consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, cpf_cnpj.ToScape()) ||
                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""), cpf_cnpj.ToScape())).FirstOrDefault();

            return consulta.Id;
        }

        public int EExisteCadastroMesmoCPFCNPJ(Pessoa model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, model.CNPJ_CPF.ToScape()) ||
                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""), model.CNPJ_CPF.ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Pessoa>> ObterPorTodosFiltros(string nomeCompleto,
            string cnpJ_CPF,
            string logradouro,
            string bairro, 
            bool? ativo, 
            int? pagina, 
            int? tamanhoPagina, 
            string order)
        {
            IQueryable<Pessoa> _consulta = Db.Pessoa;

            if (!string.IsNullOrEmpty(nomeCompleto))
                _consulta = _consulta.Where(c => EF.Functions.Like(c.NomeCompleto, nomeCompleto.ToScape()));

            if (!string.IsNullOrEmpty(cnpJ_CPF))
                _consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, cnpJ_CPF.ToScape()) ||
                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""), cnpJ_CPF.ToScape()));

            if (!string.IsNullOrEmpty(logradouro))
                _consulta = _consulta.Where(c => EF.Functions.Like(c.Logradouro, logradouro.ToScape()));

            if (!string.IsNullOrEmpty(bairro))
                _consulta = _consulta.Where(c => EF.Functions.Like(c.Bairro, bairro.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.Ativo == ativo.Value);

            _consulta = _consulta.OrderBy(e => e.Id);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Pessoa>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
