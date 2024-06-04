using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePessoas.Application.ViewModels.Contato
{
    public class ContatoAdicionarViewModel
    {
        [DisplayName("Cliente ID")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClienteID { get; set; }

        [DisplayName("TIPO CONTATO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double TIPOCONTATO { get; set; }

        [DisplayName("VALOR CONTATO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string VALORCONTATO { get; set; }

        [DisplayName("DESCRIÇÃO")]
        public string? DESCRICAO { get; set; }
    }
}
