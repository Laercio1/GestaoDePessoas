using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.CategoriaRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Guid>? ObterId(string nome)
        {
            IQueryable<Categoria> _consulta = Db.Categoria.AsQueryable();

            _consulta = _consulta.Where(fp => fp.NOME.Equals(nome));

            var consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape())).FirstOrDefault();

            return consulta.ID;
        }

        public int EExisteCadastroMesmoNOME(Categoria model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, model.NOME.ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Categoria>> ObterPorTodosFiltros(string nome, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Categoria> _consulta = Db.Categoria;

            if (!string.IsNullOrEmpty(nome)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Categoria>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
