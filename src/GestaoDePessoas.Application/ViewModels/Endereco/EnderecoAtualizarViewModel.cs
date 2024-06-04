using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.Endereco
{
    public class EnderecoAtualizarViewModel : BaseViewModelCadastro
    {
        [DisplayName("ATIVO")]
        public bool ATIVO { get; set; }

        [DisplayName("NUMERO")]
        public double? NUMERO { get; set; }

        [DisplayName("CÓDIGO POSTAL")]
        public double? CODIGOPOSTAL { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string CEP { get; set; }

        [DisplayName("ESTADO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string ESTADO { get; set; }

        [DisplayName("CIDADE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string CIDADE { get; set; }

        [DisplayName("BAIRRO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string BAIRRO { get; set; }

        [DisplayName("RUA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string RUA { get; set; }
    }
}
