using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.Pessoa
{
    public class PessoaViewModel : BaseViewModelCadastro
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CNPJ_CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Logradouro { get; set; }
        public bool Ativo { get; set; }
    }
}
