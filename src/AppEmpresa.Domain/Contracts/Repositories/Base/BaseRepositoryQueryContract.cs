using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface BaseRepositoryQueryContract<Entity, EntityList>
        where Entity : class
    {
        Task<Entity> Get(object[] id);

        Task<EntityList> Get(EntityList companyList);
    }
}