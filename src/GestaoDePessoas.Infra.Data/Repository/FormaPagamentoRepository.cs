using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class FormaPagamentoRepository : Repository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<FormaPagamento> ObterPorId(Guid id)
        {
            IQueryable<FormaPagamento> _consulta = Db.FormaPagamento;

            _consulta = _consulta.Where(fp => fp.ID.Equals(id));
            _consulta = _consulta.OrderBy(e => e.ID);

            return _consulta.LastOrDefault();
        }

        public int EExisteCadastroMesmoNome(FormaPagamento model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, model.NOME.ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<FormaPagamento>> ObterPorTodosFiltros(string nome, string descricao, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<FormaPagamento> _consulta = Db.FormaPagamento;

            if (!string.IsNullOrEmpty(nome)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape()));

            if (!string.IsNullOrEmpty(descricao)) _consulta = _consulta.Where(c => EF.Functions.Like(c.DESCRICAO, descricao.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<FormaPagamento>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
