using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.PedidoStatus
{
    public class PedidoStatusAtualizarViewModel : BaseViewModelCadastro
    {
        [DisplayName("ATIVO")]
        public bool ATIVO { get; set; }

        [DisplayName("CANCELADO")]
        public bool? CANCELADO { get; set; }

        [DisplayName("FINALIZADO")]
        public bool? FINALIZADO { get; set; }

        [DisplayName("DESCRIÇÃO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string DESCRICAO { get; set; }
    }
}
