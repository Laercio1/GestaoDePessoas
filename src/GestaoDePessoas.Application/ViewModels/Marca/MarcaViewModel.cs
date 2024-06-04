using GestaoDePessoas.Application.ViewModels.Base;

namespace GestaoDePessoas.Application.ViewModels.Marca
{
    public class MarcaViewModel : BaseViewModelCadastro
    {
        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
