using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        CompanyRepositoryContract companyRepository { get; }

        Task BeginTransaction();

        Task Commit();

        Task Rowback();
    }
}