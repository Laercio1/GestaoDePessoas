using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.PedidoItem
{
    public class PedidoItemAtualizarViewModel : BaseViewModelCadastro
    {
        [DisplayName("ATIVO")]
        public bool ATIVO { get; set; }

        [DisplayName("Produto ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProdutoID { get; set; }

        [DisplayName("QUANTIDADE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double QUANTIDADE { get; set; }
    }
}
