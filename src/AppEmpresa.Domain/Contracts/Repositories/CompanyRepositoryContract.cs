using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Entities;
using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Repositories
{
    public interface CompanyRepositoryContract
        : BaseRepositoryContract<Company>
    {
        Task<CompanyList> Get(CompanyList companyList);
    }
}