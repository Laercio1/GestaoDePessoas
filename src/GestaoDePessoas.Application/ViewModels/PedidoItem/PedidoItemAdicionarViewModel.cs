using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePessoas.Application.ViewModels.PedidoItem
{
    public class PedidoItemAdicionarViewModel
    {
        [DisplayName("Produto ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProdutoID { get; set; }

        [DisplayName("QUANTIDADE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double QUANTIDADE { get; set; }
    }
}
