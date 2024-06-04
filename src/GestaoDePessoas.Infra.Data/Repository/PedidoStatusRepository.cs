using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.PedidoStatusRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class PedidoStatusRepository : Repository<PedidoStatus>, IPedidoStatusRepository
    {
        public PedidoStatusRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Guid>? ObterId(string descricao)
        {
            IQueryable<PedidoStatus> _consulta = Db.PedidoStatus.AsQueryable();

            _consulta = _consulta.Where(fp => fp.DESCRICAO.Equals(descricao));

            var consulta = _consulta.Where(c => EF.Functions.Like(c.DESCRICAO, descricao.ToScape())).FirstOrDefault();

            return consulta.ID;
        }

        public int EExisteCadastroMesmaDescricao(PedidoStatus model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.DESCRICAO, model.DESCRICAO.ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<PedidoStatus>> ObterPorTodosFiltros(string descricao, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<PedidoStatus> _consulta = Db.PedidoStatus;

            if (!string.IsNullOrEmpty(descricao)) _consulta = _consulta.Where(c => EF.Functions.Like(c.DESCRICAO, descricao.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<PedidoStatus>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
