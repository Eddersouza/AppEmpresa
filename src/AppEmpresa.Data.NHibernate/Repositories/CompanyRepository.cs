using AppEmpresa.Data.NHibernate.Repositories.Base;
using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Entities;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace AppEmpresa.Data.NHibernate.Repositories
{
    public class CompanyRepository
        : BaseRepository<Company>,
        CompanyRepositoryContract
    {
        public CompanyRepository(ISession session) : base(session)
        {
        }

        public Task<Company> Get(object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyList> Get(CompanyList companyList)
        {
            throw new NotImplementedException();
        }
    }
}