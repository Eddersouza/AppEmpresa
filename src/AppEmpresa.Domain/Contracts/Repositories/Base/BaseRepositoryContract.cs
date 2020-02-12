using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface BaseRepositoryContract<Entity>
        where Entity : class
    {
        Task<object> Create(Entity entity);

        Task<object> Delete(Entity entity);

        Task<object> Update(Entity entity);
    }
}