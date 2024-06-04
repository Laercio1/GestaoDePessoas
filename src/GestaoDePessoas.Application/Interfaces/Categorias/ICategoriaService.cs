using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Application.ViewModels.Categoria;
using GestaoDePessoas.Dominio.CategoriaRoot.Validation;
using GestaoDePessoas.Application.Services.Base.Interfaces;

namespace GestaoDePessoas.Application.Interfaces.Categorias
{
    public interface ICategoriaService : IBaseCadastroService<Categoria,
        CategoriaViewModel,
        CategoriaAdicionarViewModel,
        CategoriaAtualizarViewModel,
        CategoriaValidation>,
        IDisposable
    {
        void LimparListaNotificacao();
    }
}
