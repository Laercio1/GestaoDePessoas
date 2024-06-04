using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Dominio.MarcaRoot.Validation;
using GestaoDePessoas.Application.ViewModels.Marca;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Marcas
{
    public interface IMarcaService : IBaseCadastroService<Marca,
        MarcaViewModel,
        MarcaAdicionarViewModel,
        MarcaAtualizarViewModel,
        MarcaValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
