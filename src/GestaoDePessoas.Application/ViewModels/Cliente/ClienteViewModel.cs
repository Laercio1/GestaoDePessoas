using GestaoDePessoas.Application.ViewModels.Base;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Application.ViewModels.Endereco;

namespace GestaoDePessoas.Application.ViewModels.Cliente
{
    public class ClienteViewModel : BaseViewModelCadastro
    {
        public ClienteViewModel()
        {
            Contatos = new List<ContatoViewModel>();
            Enderecos = new List<EnderecoViewModel>();
        }

        public string ID { get; set; }
        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public string RAZAO { get; set; }
        public string CNPJ_CPF { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public List<ContatoViewModel> Contatos { get; set; }
        public List<EnderecoViewModel> Enderecos { get; set; }
    }
}
