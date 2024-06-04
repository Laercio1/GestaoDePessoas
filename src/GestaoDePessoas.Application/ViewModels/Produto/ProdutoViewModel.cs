using GestaoDePessoas.Application.ViewModels.Base;
using GestaoDePessoas.Application.ViewModels.Marca;
using GestaoDePessoas.Application.ViewModels.Categoria;

namespace GestaoDePessoas.Application.ViewModels.Produto
{
    public class ProdutoViewModel : BaseViewModelCadastro
    {
        public ProdutoViewModel()
        {
            Marca = new MarcaViewModel();
            Categoria = new CategoriaViewModel();
        }

        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public string CBARRA { get; set; }
        public string UNIDADE { get; set; }
        public decimal PRECOUNITARIO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public MarcaViewModel Marca { get; set; }
        public CategoriaViewModel Categoria { get; set; }
    }
}
