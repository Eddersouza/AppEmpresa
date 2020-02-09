using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        CompanyRepositoryContract Companies { get; }

        Task BeginTransaction();

        Task Commit();

        Task Rowback();
    }
}