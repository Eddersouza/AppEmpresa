using AppEmpresa.Domain.Contracts.Repositories.Base;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace AppEmpresa.Data.NHibernate.Repositories.Base
{
    public class BaseRepository<Entity> :
        BaseRepositoryContract<Entity> where Entity : class, new()
    {
        protected ISession _session = null;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        public async Task<Entity> Create(Entity entity)
        {
            await _session.SaveAsync(entity);
            return entity;
        }

        public async Task<Entity> Delete(Entity entity)
        {
            await _session.DeleteAsync(entity);
            return entity;
        }

        public async Task<Entity> Update(Entity entity)
        {
            await _session.UpdateAsync(entity);
            return entity;
        }
    }
}