using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        CompanyRepositoryContract Companies { get; }

        void BeginTransaction();

        void Commit();

        void Rowback();
    }
}