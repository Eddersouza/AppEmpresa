using AppEmpresa.Domain.Entities;
using System.Threading.Tasks;

namespace AppEmpresa.Domain.Contracts.Services
{
    public interface CompanyServiceContract
    {
        Task CanCreateNewCompany(Company company);
    }
}