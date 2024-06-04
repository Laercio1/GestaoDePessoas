using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePessoas.Application.ViewModels.FormaPagamento
{
    public class FormaPagamentoAdicionarViewModel
    {
        [DisplayName("Taxa")]
        public double? TAXA { get; set; }

        [DisplayName("NOME")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string NOME { get; set; }

        [DisplayName("DESCRIÇÃO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string DESCRICAO { get; set; }
    }
}
