using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestaoDePessoas.Application.ViewModels.Categoria;

namespace GestaoDePessoas.Application.ViewModels.Produto
{
    public class ProdutoAdicionarViewModel
    {
        [DisplayName("Marca ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid MarcaID { get; set; }

        [DisplayName("Categoria ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoriaID { get; set; }

        [DisplayName("PREÇO UNITÁRIO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal PRECOUNITARIO { get; set; }

        [DisplayName("UNIDADE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string UNIDADE { get; set; }

        [DisplayName("CBARRA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string CBARRA { get; set; }

        [DisplayName("NOME")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string NOME { get; set; }
    }
}
