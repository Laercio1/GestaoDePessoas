using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.FormaPagamento
{
    public class FormaPagamentoViewModel : BaseViewModelCadastro
    {
        public string ID { get; set; }
        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public double TAXA { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
