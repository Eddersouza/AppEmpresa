using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        Task BeginTransaction();

        Task Commit();

        Task Rowback();
    }
}