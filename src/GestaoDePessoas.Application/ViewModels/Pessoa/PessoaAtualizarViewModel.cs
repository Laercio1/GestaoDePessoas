using GestaoDePessoas.Application.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePessoas.Application.ViewModels.Pessoa
{
    public class PessoaAtualizarViewModel : BaseViewModelCadastro
    {
        [Required(ErrorMessage = "Nome Completo é requerido")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "CNPJ/CPF é requerido")]
        [StringLength(18, MinimumLength = 11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Email é requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string? Telefone { get; set; }

        [Required(ErrorMessage = "CEP é requerido")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Estado é requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Cidade é requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Bairro é requerido")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Bairro { get; set; }

        public string? Numero { get; set; }

        [Required(ErrorMessage = "Logradouro é requerido")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Logradouro { get; set; }

        public bool Ativo { get; set; }
    }
}
