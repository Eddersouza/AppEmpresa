using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using System.Threading.Tasks;

namespace AppEmpresa.Tests.MockRepositories
{
    public class MockUnitOfWork : UnityOfWorkContract
    {
        public CompanyRepositoryContract _companies;

        public MockUnitOfWork(
            CompanyRepositoryContract companies)
        {
            _companies = companies;
        }

        public CompanyRepositoryContract Companies => _companies;

        public void BeginTransaction()
        {            
        }

        public void Commit()
        {           
        }

        public void Rowback()
        {            
        }
    }
}