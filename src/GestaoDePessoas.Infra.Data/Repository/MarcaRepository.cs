using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.MarcaRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Guid>? ObterId(string nome)
        {
            IQueryable<Marca> _consulta = Db.Marca.AsQueryable();

            _consulta = _consulta.Where(fp => fp.NOME.Equals(nome));

            var consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape())).FirstOrDefault();

            return consulta.ID;
        }

        public int EExisteCadastroMesmoNOME(Marca model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, model.NOME.ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Marca>> ObterPorTodosFiltros(string nome, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Marca> _consulta = Db.Marca;

            if (!string.IsNullOrEmpty(nome)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Marca>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
