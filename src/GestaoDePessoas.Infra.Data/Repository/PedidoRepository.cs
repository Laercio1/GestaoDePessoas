using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.PedidoRoot.Repository;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Dominio.PedidoStatusRoot;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            IQueryable<Pedido> _consulta = Db.Pedido.Include(x => x.Cliente)
                                                    .Include(x => x.PedidoItens)
                                                    .Include(x => x.PedidoStatus)
                                                    .Include(x => x.FormaPagamento)
                                                    .Include(x => x.Cliente).ThenInclude(r => r.Contatos)
                                                    .Include(x => x.Cliente).ThenInclude(r => r.Enderecos)
                                                    .Include(x => x.PedidoItens).ThenInclude(r => r.Produto)
                                                    .Include(x => x.PedidoItens).ThenInclude(r => r.Produto.Marca)
                                                    .Include(x => x.PedidoItens).ThenInclude(r => r.Produto.Categoria);

            _consulta = _consulta.Where(fp => fp.ID.Equals(id));
            _consulta = _consulta.OrderBy(e => e.ID);

            return _consulta.LastOrDefault();    
        }

        public int EExisteCadastroCliente(Pedido model)
        {
            IQueryable<Cliente> _consulta = Db.Cliente;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.ClienteID.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public int EExisteCadastroPedidoStatus(Pedido model)
        {
            IQueryable<PedidoStatus> _consulta = Db.PedidoStatus;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.PedidoStatusID.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public int EExisteCadastroProduto(Guid id)
        {
            IQueryable<Produto> _consulta = Db.Produto;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, id.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public int EExisteCadastroFormaPagamento(Pedido model)
        {
            IQueryable<FormaPagamento> _consulta = Db.FormaPagamento;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.FormaPagamentoID.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Pedido>> ObterPorTodosFiltros(Guid? idCliente, Guid? idFormaPagamento, Guid? idPedidoStatus, string numero, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Pedido> _consulta = Db.Pedido.Include(x => x.Cliente)
                                                    .Include(x => x.PedidoItens)
                                                    .Include(x => x.PedidoStatus)
                                                    .Include(x => x.FormaPagamento)
                                                    .Include(x => x.Cliente).ThenInclude(r => r.Contatos)
                                                    .Include(x => x.Cliente).ThenInclude(r => r.Enderecos)
                                                    .Include(x => x.PedidoItens).ThenInclude(r => r.Produto)
                                                    .Include(x => x.PedidoItens).ThenInclude(r => r.Produto.Marca)
                                                    .Include(x => x.PedidoItens).ThenInclude(r => r.Produto.Categoria);

            if (idCliente.HasValue) _consulta = _consulta.Where(p => p.ClienteID == idCliente.Value);

            if (idFormaPagamento.HasValue) _consulta = _consulta.Where(p => p.FormaPagamentoID == idFormaPagamento.Value);

            if (idPedidoStatus.HasValue) _consulta = _consulta.Where(p => p.PedidoStatusID == idPedidoStatus.Value);

            if (!string.IsNullOrEmpty(numero)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NUMEROPEDIDO, numero.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Pedido>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
