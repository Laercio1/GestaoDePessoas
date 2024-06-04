using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.ProdutoRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            IQueryable<Produto> _consulta = Db.Produto.Include(x => x.Marca)
                                                      .Include(x => x.Categoria);

            _consulta = _consulta.Where(fp => fp.ID.Equals(id));
            _consulta = _consulta.OrderBy(e => e.ID);

            return _consulta.LastOrDefault();
        }

        public int EExisteCadastroMarca(Produto model)
        {
            IQueryable<Marca> _consulta = Db.Marca;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.MarcaID.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public int EExisteCadastroCategoria(Produto model)
        {
            IQueryable<Categoria> _consulta = Db.Categoria;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.CategoriaID.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public int EExisteCadastroMesmoNOME(Produto model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, model.NOME.ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Produto>> ObterPorTodosFiltros(string nome, Guid? idMarca, Guid? idCategoria, string cbarra, string unidade, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Produto> _consulta = Db.Produto.Include(x => x.Marca)
                                                      .Include(x => x.Categoria);

            if (!string.IsNullOrEmpty(nome)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape()));

            if (idMarca.HasValue) _consulta = _consulta.Where(p => p.MarcaID == idMarca.Value);

            if (idCategoria.HasValue) _consulta = _consulta.Where(p => p.CategoriaID == idCategoria.Value);

            if (!string.IsNullOrEmpty(cbarra)) _consulta = _consulta.Where(c => EF.Functions.Like(c.CBARRA, cbarra.ToScape()));

            if (!string.IsNullOrEmpty(unidade)) _consulta = _consulta.Where(c => EF.Functions.Like(c.UNIDADE, unidade.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Produto>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
