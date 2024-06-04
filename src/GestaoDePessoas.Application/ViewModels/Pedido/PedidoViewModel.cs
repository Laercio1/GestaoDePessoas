using GestaoDePessoas.Application.ViewModels.Base;
using GestaoDePessoas.Application.ViewModels.Cliente;
using GestaoDePessoas.Application.ViewModels.FormaPagamento;
using GestaoDePessoas.Application.ViewModels.PedidoItem;
using GestaoDePessoas.Application.ViewModels.PedidoStatus;

namespace GestaoDePessoas.Application.ViewModels.Pedido
{
    public class PedidoViewModel : BaseViewModelCadastro
    {
        public PedidoViewModel()
        {
            Cliente = new ClienteViewModel();
            PedidoItens = new List<PedidoItemViewModel>();
            FormaPagamento = new FormaPagamentoViewModel();
            PedidoStatus = new PedidoStatusViewModel();
        }

        public bool ATIVO { get; set; }
        public decimal? DESCONTO { get; set; }
        public decimal VALORTOTAL { get; set; }
        public decimal VALORFINAL { get; set; }
        public double NUMEROPEDIDO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public double QUANTIDADEITENS { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public FormaPagamentoViewModel FormaPagamento { get; set; }
        public PedidoStatusViewModel PedidoStatus { get; set; }
        public List<PedidoItemViewModel> PedidoItens { get; set; }
    }
}
