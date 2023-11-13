using GestaoDePessoas.Application.ViewModels.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePessoas.Application.ViewModels.Pessoa
{
    public class PessoaAtualizarViewModel : BaseViewModelCadastro
    {
        [DisplayName("nome completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string NomeCompleto { get; set; }

        [DisplayName("CPF/CNPJ")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CNPJ_CPF { get; set; }

        [DisplayName("e-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string? Telefone { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string CEP { get; set; }

        [DisplayName("estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Estado { get; set; }

        [DisplayName("cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Cidade { get; set; }

        [DisplayName("bairro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Bairro { get; set; }

        public string? Numero { get; set; }

        [DisplayName("logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Logradouro { get; set; }

        public bool Ativo { get; set; }
    }
}
