using AppEmpresa.Domain.Entities;

namespace AppEmpresa.Domain.Contracts.Apps
{
    public interface CompanyAppContract
    {
        Company Create(Company company);

        Company Delete(Company company);

        CompanyList Get();

        Company Update(Company company);
    }
}