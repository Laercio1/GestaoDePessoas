using System.ComponentModel;
using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.Contato
{
    public class ContatoAtualizarViewModel : BaseViewModelCadastro
    {
        [DisplayName("ATIVO")]
        public bool ATIVO { get; set; }

        [DisplayName("TIPO CONTATO")]
        public double TIPOCONTATO { get; set; }

        [DisplayName("VALOR CONTATO")]
        public string VALORCONTATO { get; set; }

        [DisplayName("DESCRIÇÃO")]
        public string? DESCRICAO { get; set; }
    }
}
