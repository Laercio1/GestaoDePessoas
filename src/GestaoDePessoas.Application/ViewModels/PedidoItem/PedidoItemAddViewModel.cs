using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePessoas.Application.ViewModels.PedidoItem
{
    public class PedidoItemAddViewModel
    {
        [DisplayName("ID PEDIDO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid PedidoID { get; set; }

        [DisplayName("Produto ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProdutoID { get; set; }

        [DisplayName("QUANTIDADE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double QUANTIDADE { get; set; }
    }
}
