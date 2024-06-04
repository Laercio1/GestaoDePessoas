using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.Endereco
{
    public class EnderecoViewModel : BaseViewModelCadastro
    {
        public string ID { get; set; }
        public string RUA { get; set; }
        public string CEP { get; set; }
        public bool ATIVO { get; set; }
        public string ESTADO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public double NUMERO { get; set; }
        public double CODIGOPOSTAL { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
