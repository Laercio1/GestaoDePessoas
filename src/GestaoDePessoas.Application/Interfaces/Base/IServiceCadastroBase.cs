using GestaoDePessoas.Application.ViewModels.Base;
using GestaoDePessoas.Dominio.Core.Models;

namespace GestaoDePessoas.Application.Interfaces.Base
{
    public interface IServiceCadastroBase<TModel, TViewModelAtualizar> : IDisposable
        where TModel : Entity, new()
        where TViewModelAtualizar : BaseViewModelCadastro, new()
    {
        Task<bool> Adicionar(TModel model);
        Task<bool> Atualizar(TViewModelAtualizar viewmodel);
        Task<bool> Remover(Guid id);
    }
}
