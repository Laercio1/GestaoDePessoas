using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.Contato
{
    public class ContatoViewModel : BaseViewModelCadastro
    {
        public string ID { get; set; }
        public bool ATIVO { get; set; }
        public string DESCRICAO { get; set; }
        public double TIPOCONTATO { get; set; }
        public string VALORCONTATO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
