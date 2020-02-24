using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Contracts.Services;
using AppEmpresa.Domain.Entities;
using AppEmpresa.EventNotification.Entities;
using AppEmpresa.EventNotification.Entities.Levels;
using System.Threading.Tasks;

namespace AppEmpresa.Domain.Services
{
    public class CompanyService : CompanyServiceContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public CompanyService(UnityOfWorkContract unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task CanCreateNewCompany(Company company)
        {
            Company companyInSystem = await _unityOfWork.Companies.Get(company.PrimaryKeys);

            if (companyInSystem != null)
                company.EventNotification.Add(new EventNotificationDescription(
                    "Empresa já Cadastrada.",
                    new EventNotificationWarning()));
        }
    }
}