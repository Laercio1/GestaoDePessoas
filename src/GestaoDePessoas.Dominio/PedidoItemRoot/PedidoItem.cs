using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.PedidoItemRoot
{
    [Table("PEDIDOITEM")]
    public class PedidoItem : Entity
    {
        public PedidoItem() 
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public Guid PedidoID { get; set; }
        public Guid ProdutoID { get; set; }
        public double QUANTIDADE { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
