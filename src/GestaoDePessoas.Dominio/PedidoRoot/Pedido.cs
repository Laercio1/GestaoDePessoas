using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.PedidoItemRoot;
using GestaoDePessoas.Dominio.Core.Annotations;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Dominio.PedidoStatusRoot;

namespace GestaoDePessoas.Dominio.PedidoRoot
{
    [Table("PEDIDO")]
    public class Pedido : Entity
    {
        public Pedido()
        {
            ATIVO = true;
            PedidoItens = new List<PedidoItem>();
        }

        public bool ATIVO { get; set; }
        public Guid ClienteID { get; set; }
        public decimal? DESCONTO { get; set; }
        public decimal VALORTOTAL { get; set; }
        public decimal VALORFINAL { get; set; }
        public double NUMEROPEDIDO { get; set; }
        public Guid PedidoStatusID { get; set; }
        public Guid FormaPagamentoID { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public double QUANTIDADEITENS { get; set; }
        public virtual Cliente Cliente { get; set; }
        public List<PedidoItem> PedidoItens { get; set; }
        public virtual PedidoStatus PedidoStatus { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
    }
}
