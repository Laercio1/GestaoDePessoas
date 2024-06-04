//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using GestaoDePessoas.Application.ViewModels.Base;
//using GestaoDePessoas.Application.ViewModels.Contato;
//using GestaoDePessoas.Application.ViewModels.Endereco;

//namespace GestaoDePessoas.Application.ViewModels.Pessoa
//{
//    public class PessoaAtualizarViewModel : BaseViewModelCadastro
//    {
//        public PessoaAtualizarViewModel()
//        {
//            Contatos = new List<ContatoAtualizarViewModel>();
//            Enderecos = new List<EnderecoAtualizarViewModel>();
//        }

//        [DisplayName("ATIVO")]
//        public bool ATIVO { get; set; }

//        [DisplayName("NOME COMPLETO")]
//        [Required(ErrorMessage = "O campo {0} é obrigatório")]
//        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
//        public string NOMECOMPLETO { get; set; }

//        [DisplayName("CNPJ/CPF")]
//        [Required(ErrorMessage = "O campo {0} é obrigatório")]
//        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
//        public string CNPJ_CPF { get; set; }

//        public List<ContatoAtualizarViewModel> Contatos { get; set; }
//        public List<EnderecoAtualizarViewModel> Enderecos { get; set; }
//    }
//}
