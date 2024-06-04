using GestaoDePessoas.Application.ViewModels.Base;
using GestaoDePessoas.Application.ViewModels.Produto;

namespace GestaoDePessoas.Application.ViewModels.PedidoItem
{
    public class PedidoItemViewModel : BaseViewModelCadastro
    {
        public PedidoItemViewModel()
        {
            Produto = new ProdutoViewModel();
        }

        public bool ATIVO { get; set; }
        public double QUANTIDADE { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
