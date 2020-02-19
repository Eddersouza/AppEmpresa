using AppEmpresa.Data.NHibernate.Repositories.Base;
using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Entities;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace AppEmpresa.Data.NHibernate.Repositories
{
    public class CompanyRepository 
        : BaseRepository<Company>, CompanyRepositoryContract
    {
        public CompanyRepository(ISession session) : base(session)
        {
        }

        public Task<CompanyList> Get(CompanyList companyList)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Get(string cnpj)
        {
            throw new NotImplementedException();
        }
    }
}