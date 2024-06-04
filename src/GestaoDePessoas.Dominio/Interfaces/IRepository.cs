using System.Linq.Expressions;
using GestaoDePessoas.Dominio.Core.Models;

namespace GestaoDePessoas.Dominio.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Remover(Guid id);
        Task<int> SaveChanges();
        bool DominioExiste(Guid id);
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(Guid id);
        bool UpdateValeuWithViewModel(object model, object viewmodel);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
