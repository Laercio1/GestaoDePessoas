using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestaoDePessoas.Application.ViewModels.PedidoItem;

namespace GestaoDePessoas.Application.ViewModels.Pedido
{
    public class PedidoAdicionarViewModel
    {
        public PedidoAdicionarViewModel()
        {
            PedidoItens = new List<PedidoItemAdicionarViewModel>();
        }

        [DisplayName("DESCONTO")]
        public decimal? DESCONTO { get; set; }

        [DisplayName("Cliente ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClienteID { get; set; }

        [DisplayName("FormaPagamento ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid FormaPagamentoID { get; set; }

        [DisplayName("PedidoStatus ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid PedidoStatusID { get; set; }

        [DisplayName("VALOR TOTAL")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal VALORTOTAL { get; set; }

        [DisplayName("VALOR FINAL")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal VALORFINAL { get; set; }

        [DisplayName("NÚMERO PEDIDO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double NUMEROPEDIDO { get; set; }

        [DisplayName("QUANTIDADE ITENS")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double QUANTIDADEITENS { get; set; }

        public List<PedidoItemAdicionarViewModel> PedidoItens { get; set; }
    }
}
