using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Dominio.PedidoItemRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.PedidoItemRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class PedidoItemRepository : Repository<PedidoItem>, IPedidoItemRepository
    {
        public PedidoItemRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public int EExisteCadastroPedido(PedidoItem model)
        {
            IQueryable<Pedido> _consulta = Db.Pedido;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.PedidoID.ToString().ToScape())).ToList();

            return consulta.Count;
        }

        public int EExisteCadastroProduto(PedidoItem model)
        {
            IQueryable<Produto> _consulta = Db.Produto;

            var consulta = _consulta.Where(c => EF.Functions.Like(c.ID, model.ProdutoID.ToString().ToScape())).ToList();

            return consulta.Count;
        }
    }
}
