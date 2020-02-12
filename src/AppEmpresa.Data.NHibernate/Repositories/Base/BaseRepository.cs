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

        public async Task<object> Create(Entity entity)
        {
            return _session.SaveAsync(entity);
        }

        public async Task<object> Delete(Entity entity)
        {
            return _session.DeleteAsync(entity);
        }

        public async Task<object> Update(Entity entity)
        {
            return _session.UpdateAsync(entity);
        }
    }
}