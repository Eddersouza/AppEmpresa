using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface BaseRepositoryContract<Entity>
        where Entity : class
    {
        Task<Entity> Create(Entity entity);

        Task<Entity> Delete(Entity entity);

        Task<Entity> Update(Entity entity);
    }
}