using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface BaseRepositoryContract<Entity> : IDisposable
        where Entity : class
    {
        Task<Entity> Create(Entity entity);

        Task<Entity> Delete(Entity entity);

        Task Update(Entity entity);
    }
}