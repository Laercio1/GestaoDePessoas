using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.ContatoRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.ContatoRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<ListaPaginada<Contato>> ObterPorTodosFiltros(string valorContato, double tipoContato, string descricao, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Contato> _consulta = Db.Contato;

            if (!string.IsNullOrEmpty(valorContato)) _consulta = _consulta.Where(c => EF.Functions.Like(c.VALORCONTATO, valorContato.ToScape()));

            if (tipoContato != 0) _consulta = _consulta.Where(c => EF.Functions.Like(c.TIPOCONTATO, tipoContato.ToString()));

            if (!string.IsNullOrEmpty(descricao)) _consulta = _consulta.Where(c => EF.Functions.Like(c.DESCRICAO, descricao.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Contato>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
