using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Entities;

namespace AppEmpresa.Domain.Contracts.Repositories
{
    public interface CompanyRepositoryContract
        : BaseRepositoryContract<Company>, 
        BaseRepositoryQueryContract<Company, CompanyList>
    {
    }
}