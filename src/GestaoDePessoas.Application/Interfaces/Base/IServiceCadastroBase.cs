using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Application.ViewModels.Base;

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
