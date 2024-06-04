//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using GestaoDePessoas.Application.ViewModels.Contato;
//using GestaoDePessoas.Application.ViewModels.Endereco;

//namespace GestaoDePessoas.Application.ViewModels.Pessoa
//{
//    public class PessoaAdicionarViewModel
//    {
//        public PessoaAdicionarViewModel()
//        {
//            Contatos = new List<ContatoAdicionarViewModel>();
//            Enderecos = new List<EnderecoAdicionarViewModel>();
//        }

//        [DisplayName("NOME COMPLETO")]
//        [Required(ErrorMessage = "O campo {0} é obrigatório")]
//        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
//        public string NOMECOMPLETO { get; set; }

//        [DisplayName("CNPJ/CPF")]
//        [Required(ErrorMessage = "O campo {0} é obrigatório")]
//        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
//        public string CNPJ_CPF { get; set; }

//        public List<ContatoAdicionarViewModel> Contatos { get; set; }
//        public List<EnderecoAdicionarViewModel> Enderecos { get; set; }
//    }
//}
