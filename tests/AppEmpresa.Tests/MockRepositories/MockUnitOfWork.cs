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

        public Task BeginTransaction()
        {
            return Task.Delay(1);
        }

        public Task Commit()
        {
            return Task.Delay(1);
        }

        public Task Rowback()
        {
            return Task.Delay(1);
        }
    }
}