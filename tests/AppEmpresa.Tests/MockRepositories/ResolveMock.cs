using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Tests.MockRepositories;

namespace AppEmpresa.Tests
{
    public class ResolveMock
    {
        public UnityOfWorkContract Resolve()
        {
            MockCompanyRepository repository = new MockCompanyRepository();

            UnityOfWorkContract unityOfWork = new MockUnitOfWork(repository.CreateCompanyRepository());

            return unityOfWork;
        }
    }
}