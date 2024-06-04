using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Application.ViewModels.Endereco;

namespace GestaoDePessoas.Application.ViewModels.Cliente
{
    public class ClienteAdicionarViewModel
    {
        public ClienteAdicionarViewModel()
        {
            Contatos = new List<ContatoAdicionarViewModel>();
            Enderecos = new List<EnderecoAddViewModel>();
        }

        [DisplayName("NOME")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string NOME { get; set; }

        [DisplayName("RAZÃO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string RAZAO { get; set; }

        [DisplayName("CNPJ/CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CNPJ_CPF { get; set; }

        public List<ContatoAdicionarViewModel> Contatos { get; set; }
        public List<EnderecoAddViewModel> Enderecos { get; set; }
    }
}
