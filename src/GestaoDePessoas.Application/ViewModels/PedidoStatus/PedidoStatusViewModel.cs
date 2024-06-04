using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.PedidoStatus
{
    public class PedidoStatusViewModel : BaseViewModelCadastro
    {
        public bool ATIVO { get; set; }
        public bool CANCELADO { get; set; }
        public bool FINALIZADO { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
